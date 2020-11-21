Imports System.Net
Imports risersoft.shared.portable.Model
Imports risersoft.shared.web
Imports risersoft.shared.cloud
Imports risersoft.shared.cloud.Repository

''' <summary>
''' Base Server Repository
''' </summary>
''' <typeparam name="T"></typeparam>
''' <typeparam name="TId"></typeparam>
''' <remarks></remarks>
Public Class ServerRepositoryBase(Of T As BaseInfo, TId)
    Inherits RepositoryBase(Of T, TId, T, Boolean, RSCallerInfo, HttpStatusCode)

    Protected Overrides Function GetStatus(IsError As Boolean) As HttpStatusCode
        If IsError Then Return HttpStatusCode.InternalServerError Else Return HttpStatusCode.OK
    End Function

End Class
