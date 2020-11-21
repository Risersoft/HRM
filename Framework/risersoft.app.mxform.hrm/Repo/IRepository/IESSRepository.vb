Imports System.IO
Imports System.Net
Imports risersoft.shared.portable.Model
Imports risersoft.shared.portable.Models
Imports risersoft.shared.portable.Models.HR
Imports risersoft.shared.cloud.IRepository

Public Interface IESSRepository
    Inherits IRepositoryBase(Of EmployeeInfo, Integer, EmployeeInfo, Boolean, RSCallerInfo, HttpStatusCode)

    Function GetMyEmployeeInfo() As Task(Of ResultInfo(Of EmployeeInfo, HttpStatusCode))
    Function GetMyLeaveBalance() As ResultInfo(Of List(Of LeaveBalanceInfo), HttpStatusCode)
    Function GetMyLeaveApplication() As ResultInfo(Of LeaveAppInfo, HttpStatusCode)
    Function CancelMyLeaveApplication() As ResultInfo(Of Boolean, HttpStatusCode)
    Function AddMyLeaveApplication(info As LeaveAppInfo) As ResultInfo(Of Integer, HttpStatusCode)
    Function GetSubordinateApplication(LeaveAppId As Integer) As ResultInfo(Of LeaveAppInfo, HttpStatusCode)
    Function GetSubordinateApplications() As ResultInfo(Of List(Of LeaveAppInfo), HttpStatusCode)
    Function GetSubordinateBalance(employeeid As Integer) As ResultInfo(Of List(Of LeaveBalanceInfo), HttpStatusCode)
    Function SaveSubordinateApplication(LeaveAppId As Integer, Accepted As Boolean, Comments As String) As ResultInfo(Of Boolean, HttpStatusCode)
    Function GetMyPayslips() As ResultInfo(Of List(Of PayslipInfo), HttpStatusCode)
    Function GetPayslip(ID As Integer) As Stream
    Function GetMyPersonInfo() As ResultInfo(Of PersonInfo, HttpStatusCode)
    Function SaveMyAddress(info As AddressInfo) As ResultInfo(Of Boolean, HttpStatusCode)
    Function SaveMyEducation(info As PersEduInfo) As ResultInfo(Of Integer, HttpStatusCode)
    Function SaveMyFamily(info As PersFamilyInfo) As ResultInfo(Of Integer, HttpStatusCode)
    Function GetMyPunches() As ResultInfo(Of List(Of GeoCoordinate), HttpStatusCode)
    Function GetMyLocation(Lat As Double, Lng As Double) As Task(Of ResultInfo(Of String, HttpStatusCode))
    Function PostMyPunch(location As GeoCoordinate) As Task(Of ResultInfo(Of Integer, HttpStatusCode))
    Function GetUploadURL() As ResultInfo(Of String, HttpStatusCode)
    Function ConfirmURL(url As String) As ResultInfo(Of Boolean, HttpStatusCode)
End Interface
