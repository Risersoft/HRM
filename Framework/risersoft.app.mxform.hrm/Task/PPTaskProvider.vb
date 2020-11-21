Imports System.Configuration
Imports System.Reflection
Imports Newtonsoft.Json
Imports risersoft.app.mxent
Imports risersoft.app.reports.gst
Imports risersoft.shared
Imports risersoft.shared.cloud
Imports risersoft.shared.dal
Imports risersoft.shared.portable.Models.Auth

Public Class PPTaskProvider
    Inherits clsTaskProviderBase
    Public Overrides ReadOnly Property IsApiTask As Boolean = True

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim Params = JsonConvert.DeserializeObject(Of List(Of clsSQLParam))(myUtils.cStrTN(rTask("infojson")))
        Dim PayPeriodID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@payperiodid", Params))
        Dim mailer As New MailModuleBase(myContext), oRetMail As clsProcOutput
        Dim MailMessage As String = ""
        Select Case myUtils.cStrTN(rTask("actionsubtype")).Trim.ToLower
            Case "calcppsal"
                Dim objPayPeriod As New clsPayPeriodBase(myContext)
                oRet = objPayPeriod.CalculatePayPeriodSal(PayPeriodID)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Calculated Salary", oRet.Message)
            Case "calcppinc"
                Dim objInc As New clsIncentiveProc(myContext)
                oRet = objInc.CalculateIncentivePayable(PayPeriodID, "")
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Calculated Incentive", oRet.Message)
            Case "calcppsumm"
                Dim objPayPeriod As New clsPayPeriodBase(myContext)
                oRet = objPayPeriod.CalculatePayPeriodSumm(PayPeriodID)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Calculated Salary Summary", oRet.Message)
            Case "calcincsumm"
                Dim objInc As New clsIncentiveProc(myContext)
                oRet = objInc.CalculateIncentivePayable(PayPeriodID, "0=1")
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Calculated Incentive Summary", oRet.Message)
            Case "uncalcppsal"
                Dim objPayPeriod As New clsPayPeriodBase(myContext)
                oRet = objPayPeriod.UnCalculatePayPeriodSal(PayPeriodID)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "UnCalculated Salary", oRet.Message)
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

