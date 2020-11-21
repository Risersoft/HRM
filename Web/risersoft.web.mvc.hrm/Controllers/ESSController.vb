Imports risersoft.shared.portable.Model
Imports System.Web.Http
Imports risersoft.shared.portable.Models.HR
Imports risersoft.shared
Imports System.Net.Http
Imports System.Net
Imports risersoft.shared.portable.Models
Imports System.Web.Http.Controllers
Imports risersoft.shared.portable.Models.Nav
Imports risersoft.shared.web.Controllers
Imports risersoft.app.mxform
Imports risersoft.shared.web
Imports risersoft.app.mxform.hrm
Imports System.Threading.Tasks
Imports risersoft.shared.cloud
Imports risersoft.shared.agent
''' <summary>
''' ESS Controller
''' </summary>
''' <remarks></remarks>
<RoutePrefix("api/ESS")>
Public Class ESSController
    Inherits ServerApiController(Of EmployeeInfo, Integer, EmployeeInfo, Boolean, HttpStatusCode, IESSRepository)

    Public Sub New(repository As IESSRepository)
        MyBase.New(repository)
    End Sub

    Public Overrides Sub OnActionExecuting(actionContext As HttpActionContext)
        MyBase.OnActionExecuting(actionContext)
        Dim EssAppCode = myUtils.Coalesce(ConfigurationManager.AppSettings("essappcode"), "ess")
        repository.WebController.CheckInitModel(New clsAppInfo With {.AppCode = EssAppCode},
                                                True)

    End Sub
    <HttpGet>
    <Route("Clear")>
    Public Function ClearAuthInfo() As IHttpActionResult
        Dim oRet As clsProcOutput = AgentAuthProvider.ClearCache
        If oRet.Success Then Return Ok("Done") Else Return Ok(oRet.Message)

    End Function
    <HttpGet>
    <Route("MyEmp")>
    Public Async Function GetMyEmployeeInfo() As Task(Of IHttpActionResult)
        Dim result = Await repository.GetMyEmployeeInfo()
        Return Ok(result)
    End Function

    <HttpGet>
    <Route("MyLeaves")>
    Public Function GetMyLeaveBalance() As IHttpActionResult
        Dim result = repository.GetMyLeaveBalance()
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("MyLeaveApp")>
    Public Function GetMyLeaveApplication() As IHttpActionResult
        Dim result = repository.GetMyLeaveApplication()
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("CancelMyLeaveApp")>
    Public Function CancelMyLeaveApplication() As IHttpActionResult
        Dim result = repository.CancelMyLeaveApplication()
        Return Ok(result)
    End Function

    <HttpPost>
    <Route("MyLeaveApp")>
    Public Function PostLeaveApplication(info As LeaveAppInfo) As IHttpActionResult
        Dim result = repository.AddMyLeaveApplication(info)
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("SubLeaveApp")>
    Public Function GetSubordinateApplication(leaveappid As Integer) As IHttpActionResult
        Dim result = repository.GetSubordinateApplication(leaveappid)
        Return Ok(result)
    End Function

    <HttpGet>
    <Route("SubLeaveApps")>
    Public Function GetSubordinateApplications() As IHttpActionResult
        Dim result = repository.GetSubordinateApplications
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("SubLeaveBalance")>
    Public Function GetSubordinateBalance(employeeid As Integer) As IHttpActionResult
        Dim result = repository.GetSubordinateBalance(employeeid)
        Return Ok(result)
    End Function
    <HttpPost>
    <Route("SubLeaveApp")>
    Public Function SaveSubordinateApplication(data As Dictionary(Of String, Object)) As IHttpActionResult
        Dim LeaveAppId As Integer = CInt(myUtils.cValTN(data("LeaveAppId")))
        Dim Accepted As Boolean = CInt(myUtils.cValTN(data("Accepted")))
        Dim Comments As String = myUtils.cStrTN(data("Comments"))
        Dim result = repository.SaveSubordinateApplication(LeaveAppId, Accepted, Comments)
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("MyPayslips")>
    Public Function GetMyPayslips() As IHttpActionResult
        Dim result = repository.GetMyPayslips()
        Return Ok(result)

    End Function
    <HttpGet>
    <Route("Payslip")>
    Public Function GetMyPayslip(ID As Integer) As HttpResponseMessage
        Dim result As HttpResponseMessage = Nothing
        ' Serve the file to the client
        result = Request.CreateResponse(HttpStatusCode.OK)
        result.Content = New StreamContent(repository.GetPayslip(ID))
        result.Content.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        result.Content.Headers.ContentDisposition.FileName = Me.repository.fncUser.Invoke.UserAccount.FullName & "_payslip_" & ID & ".pdf"

        Return result

    End Function
    <HttpGet>
    <Route("MyPerson")>
    Public Function GetMyPersonInfo() As IHttpActionResult
        Dim result = repository.GetMyPersonInfo()
        Return Ok(result)
    End Function

    <HttpPost>
    <Route("MyAddress")>
    Public Function PostAddress(info As AddressInfo) As IHttpActionResult
        Dim result = repository.SaveMyAddress(info)
        Return Ok(result)
    End Function
    <HttpPost>
    <Route("MyEdu")>
    Public Function PostEdu(info As PersEduInfo) As IHttpActionResult
        Dim result = repository.SaveMyEducation(info)
        Return Ok(result)
    End Function
    <HttpPost>
    <Route("MyFam")>
    Public Function PostFam(info As PersFamilyInfo) As IHttpActionResult
        Dim result = repository.SaveMyFamily(info)
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("MyPunches")>
    Public Function GetMyPunches() As IHttpActionResult
        Dim result = repository.GetMyPunches()
        Return Ok(result)

    End Function
    <HttpGet>
    <Route("MyLocation")>
    Public Async Function GetMyLocation(Lat As Double, Lng As Double) As Task(Of IHttpActionResult)
        Dim result = Await repository.GetMyLocation(Lat, Lng)
        Return Ok(result)

    End Function
    <HttpPost>
    <Route("MyPunch")>
    Public Async Function PostPunch(info As GeoCoordinate) As Task(Of IHttpActionResult)
        Dim result = Await repository.PostMyPunch(info)
        Return Ok(result)
    End Function
    <HttpGet>
    <Route("UploadURL")>
    Public Function GetUploadURL() As IHttpActionResult
        Dim result = repository.GetUploadURL()
        Return Ok(result)

    End Function
    <HttpGet>
    <Route("ConfirmURL")>
    Public Function ConfirmURL(url As String) As IHttpActionResult
        Dim result = repository.ConfirmURL(url)
        Return Ok(result)

    End Function

End Class
'http://stackoverflow.com/questions/24080018/download-file-from-an-asp-net-web-api-method-using-angularjs
