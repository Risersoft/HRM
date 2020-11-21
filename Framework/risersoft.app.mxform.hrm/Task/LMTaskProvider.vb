Imports System.Configuration
Imports System.Reflection
Imports Newtonsoft.Json
Imports risersoft.app.mxent
Imports risersoft.app.reports.gst
Imports risersoft.shared
Imports risersoft.shared.cloud
Imports risersoft.shared.dal
Imports risersoft.shared.portable.Models.Auth

Public Class LMTaskProvider
    Inherits clsTaskProviderBase
    Public Overrides ReadOnly Property IsApiTask As Boolean = True

    Public Sub New(controller As clsAppController)
        MyBase.New(controller)
    End Sub

    Public Overrides Async Function ExecuteServer(rTask As DataRow, input As clsProcOutput) As Task(Of clsProcOutput)
        Dim oRet As New clsProcOutput
        Dim Params = JsonConvert.DeserializeObject(Of List(Of clsSQLParam))(myUtils.cStrTN(rTask("infojson")))
        Dim LeaveMasterID As Integer = myUtils.cValTN(myContext.SQL.ParamValue("@LeaveMasterID", Params))
        Dim mailer As New MailModuleBase(myContext), oRetMail As clsProcOutput
        Dim MailMessage As String = ""
        Select Case myUtils.cStrTN(rTask("actionsubtype")).Trim.ToLower
            Case "generateleavebal"
                Dim oMaster As New clsMasterDataHRP(myContext)
                Dim r1 As DataRow = oMaster.rLeaveMasterID(LeaveMasterID)
                Dim objLve As New clsLeaveBase(myContext)
                oRet = objLve.CalculateLeaveBalanceLM(r1)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Calculating Leave Balance", oRet.Message)
            Case "generatefy"
                Dim oMaster As New clsMasterDataHRP(myContext)
                Dim r1 As DataRow = oMaster.rLeaveMasterID(LeaveMasterID)
                Dim objLve As New clsLeaveBase(myContext)
                oRet = objLve.CalculateLeaveMasterAccVouch(r1)
                oRetMail = Await mailer.SendGenericMail(myUtils.cStrTN(rTask("username")), "Calculating Leave Balance", oRet.Message)
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
