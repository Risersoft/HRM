Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports risersoft.app.mxent
Imports risersoft.shared
Imports risersoft.shared.portable.Model
Imports risersoft.shared.portable.Models.Config
Imports risersoft.shared.portable.Models.HR
Imports risersoft.shared.web

Namespace Controllers
    Public Class frmCampusAreaController
        Inherits clsMvcControllerBase
        Public Function Index() As ActionResult
            ViewBag.CampusList = FileStorage.GetList()
            Return View()
        End Function

        Public Function AddCampus() As ActionResult
            Dim model = New CampusInfo()
            model.CampusName = "Campus"

            ViewBag.Title = "Add campus"

            ViewBag.isEdit = False

            Return View(model)
        End Function
        <Authorize> <HostActionFilter>
        <HttpGet> <ActionName("Edit")>
        Public Async Function GetEdit(id As Integer) As Task(Of ActionResult)
            If Await Me.myWebController.CheckInitModel(Me.myWebController.GetAppInfo, True) Then
                Dim sql As String = "select * from mmlistcampus() where campusid=" & id
                Dim dt1 As DataTable = Me.myWebController.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                If dt1.Rows.Count > 0 Then
                    Dim model As New CampusInfo With {.CampusId = dt1.Rows(0)("campusId"), .CampusName = dt1.Rows(0)("dispname"), .StartingAddress = myUtils.cStrTN(dt1.Rows(0)("campusaddress"))}
                    ViewBag.Title = "Edit campus"
                    ViewBag.areasJSON = myUtils.cStrTN(dt1.Rows(0)("geoarealist"))
                    ViewBag.isEdit = True

                    Return View("Edit", model)

                End If
            End If

            Return RedirectToAction("Index", "App")

        End Function
        <Authorize> <HostActionFilter>
        <HttpPost> <ActionName("Edit")>
        Public Async Function PostEdit(id As Integer) As Task(Of ActionResult)
            If Await Me.myWebController.CheckInitModel(Me.myWebController.GetAppInfo, True) Then
                Dim collection = Me.Request.Form
                Dim areasJSON = collection("areas")
                Dim areasData = JsonConvert.DeserializeObject(Of List(Of CampusAreaInfo))(areasJSON, New JsonSerializerSettings() With {
                .FloatParseHandling = FloatParseHandling.[Decimal]
            })

                Dim sql As String = "select campusid, geoarealist from campus where campusid=" & id
                Dim dt1 As DataTable = Me.myWebController.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                dt1.Rows(0)("geoarealist") = areasJSON
                Me.myWebController.DataProvider.objSQLHelper.SaveResults(dt1, sql)
                'Dim data = New CampusInfo() With {
                '    .CampusName = collection("CampusName"),
                '    .StartingAddress = collection("StartingAddress"),
                '    .Areas = areasData
                '}

                'FileStorage.SaveData(data)

                Return RedirectToAction("Index", "App")

            End If

        End Function

        <Authorize> <HostActionFilter>
        <HttpGet> <ActionName("Clear")>
        Public Async Function GetClear(id As Integer) As Task(Of ActionResult)
            If Await Me.myWebController.CheckInitModel(Me.myWebController.GetAppInfo, True) Then
                Dim sql As String = "select campusid, geoarealist from campus where campusid=" & id
                Dim dt1 As DataTable = Me.myWebController.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                dt1.Rows(0)("geoarealist") = ""
                Me.myWebController.DataProvider.objSQLHelper.SaveResults(dt1, sql)
                Return RedirectToAction("Edit", New With {.id = id})

            End If

            Return RedirectToAction("Index", "App")

        End Function
        Public Function IsPointInCampus(name As String, lat As Decimal, lng As Decimal) As ActionResult
            Dim result = False

            Dim campus = FileStorage.GetData(name)

            If campus IsNot Nothing Then
                result = SpatialLibrary.IsPointInCampus(campus.Areas, New GeoCoordinate() With {
                    .Latitude = lat,
                    .Longitude = lng
                })
            End If

            Return Content(result.ToString())
        End Function

        Public Function Employees() As ActionResult
            Dim employees__1 = New List(Of EmployeeInfo)() From {
                New EmployeeInfo() With {
                    .EmpCode = "A",
                    .FullName = "Jonh",
                    .Place = New GeoCoordinate() With {
                        .Latitude = 28.9949283D,
                        .Longitude = 77.3732757D
                    }
                },
                New EmployeeInfo() With {
                    .EmpCode = "B",
                    .FullName = "Sam",
                    .Place = New GeoCoordinate() With {
                        .Latitude = 29.055569473942022D,
                        .Longitude = 77.46803283691406D
                    }
                },
                New EmployeeInfo() With {
                    .EmpCode = "C",
                    .FullName = "Michael",
                    .Place = New GeoCoordinate() With {
                        .Latitude = 28.936655405241098D,
                        .Longitude = 77.55043029785156D
                    }
                }
            }

            Return Json(employees__1, JsonRequestBehavior.AllowGet)
        End Function
    End Class
End Namespace