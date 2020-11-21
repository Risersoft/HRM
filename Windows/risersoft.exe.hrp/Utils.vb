Imports Infragistics.Shared
Imports risersoft.shared.win
Imports risersoft.shared
Imports risersoft.app.hrp
Imports risersoft.app.shared
Imports risersoft.app2.shared
Imports risersoft.shared.dotnetfx
Imports risersoft.app.mxform.hrm
Imports risersoft.shared.portable.Models.Nav
Imports Newtonsoft.Json

Public Class Utils
    Public Shared Sub Main(ByVal args() As String)
        myApp = New clsRSWinCloudApp(New clsExtendAppHRM)
        myWinApp.CheckInitConsole(args)
        Dim fMain As frmMax = AppStarter.StartWinFormApp(args)
        If Not fMain Is Nothing Then
            'GetForm12BBdata()
            'TestImportAttendance()

            Application.Run(fMain)
        End If
    End Sub

    Private Shared Sub TestImportAttendance()
        Dim importer As New Import_AttendanceTaskProvider(myApp.Controller)
        importer.ExecuteImport("E:\Import Test Files\HRM Nirvana Import Files\Attendance.xlsx", "info@risersoft.com", Guid.NewGuid.ToString)
    End Sub

    Private Shared Sub GetForm12BBdata()
        Dim dic As New clsCollecString(Of String)
        dic.Add("form12bb", "select employees.empcode, form12bb.* from form12bb inner join employees on form12bb.employeeid = employees.employeeid and form12bb.tenantid = employees.tenantid")
        dic.Add("form12bbitem", "select * from form12bbitem")
        Dim ds = SQLHelper.ExecuteDataset(CommandType.Text, dic)
        Dim str1 = JsonConvert.SerializeObject(ds)
        My.Computer.FileSystem.WriteAllText("C:\form12bb.json", str1, False)

    End Sub

End Class
