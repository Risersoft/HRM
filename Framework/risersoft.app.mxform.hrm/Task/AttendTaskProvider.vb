Imports System.Configuration
Imports System.Reflection
Imports Newtonsoft.Json
Imports risersoft.app.mxent
Imports risersoft.app.reports.gst
Imports risersoft.shared
Imports risersoft.shared.cloud
Imports risersoft.shared.dal
Imports risersoft.shared.portable.Models.Auth

Public Class AttendTaskProvider
    Inherits clsTaskProviderBase
    Public Overrides ReadOnly Property IsApiTask As Boolean = True

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim Params = JsonConvert.DeserializeObject(Of List(Of clsSQLParam))(myUtils.cStrTN(rTask("infojson")))
        Dim employeeid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@employeeid", Params))
        Dim payperiodid As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@payperiodid", Params))
        Dim mailer As New MailModuleBase(myContext), oRetMail As clsProcOutput
        Dim MailMessage As String = ""
        Select Case myUtils.cStrTN(rTask("actionsubtype")).Trim.ToLower
            Case "punch"
                Dim oMaster As New clsMasterDataHRP(myContext)
                Dim rPP As DataRow = oMaster.rPayPeriodID(payperiodid)
                Dim Dated As DateTime = rPP("sdate")
                Dim strFilter As String = "employeeid=" & employeeid
                Dim oProc As New CLSProcessPunch(myContext)
                While Dated <= rPP("edate")
                    oRet = oRet + oProc.processPunch(Dated, strFilter)
                    Dated = Dated.AddDays(1)
                End While
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Process Punch", oRet.Message)
            Case "punchday"
                Dim dated As DateTime = myContext.SQL.ParamValue("@dated", Params)
                Dim oProc As New CLSProcessPunch(myContext)
                oRet = oProc.processPunchDay(dated)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Process Punch DayWise", oRet.Message)
            Case "punchattend"
                Dim dated As DateTime = myContext.SQL.ParamValue("@dated", Params)
                Dim oProc As New CLSProcessPunch(myContext)
                oRet = oProc.processPunchEmp(dated, employeeid)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Process Punch DayWise", oRet.Message)
        End Select
        If Not oRetMail Is Nothing Then
            If oRetMail.Success Then
                oRet.AddMessage("Sent Message: " & oRetMail.Message & ", " & MailMessage)
            Else
                Dim mailerMessage = String.Format("Message from SendGenericMailMandrill Message='{0}' StackTrace='{1}'", oRetMail.Message, oRetMail.StackTrace)
                oRet.AddMessage(mailerMessage)
            End If
        End If
        Return oRet
    End Function


End Class
