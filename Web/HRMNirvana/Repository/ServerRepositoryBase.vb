﻿Imports System.Net
Imports risersoft.app.mxform.gst
Imports risersoft.app.mxform.hrm
Imports risersoft.shared.cloud
Imports risersoft.shared.portable.Model
Imports risersoft.shared.web
Imports risersoft.shared.cloud.Repository
Imports risersoft.shared.agent
Imports System.Data.Entity

''' <summary>
''' Base Server Repository
''' </summary>
''' <typeparam name="T"></typeparam>
''' <typeparam name="TId"></typeparam>
''' <remarks></remarks>
Public Class ServerRepositoryBase(Of TGet As BaseInfo, TId, TPost, TResult)
    Inherits RepositoryBase(Of TGet, TId, TPost, TResult, RSCallerInfo, HttpStatusCode)
    Protected Function GetServerEntity() As DbContext
        Dim strconn = AgentAuthProvider.CalculateConnectionString(Me.User, "mxentdb", "Nirvana")
        'Return New mxentdbEntities(strconn.ConnectionString, Me.User)
    End Function

    Protected Overrides Function GetStatus(IsError As Boolean) As HttpStatusCode
        If IsError Then Return HttpStatusCode.InternalServerError Else Return HttpStatusCode.OK
    End Function

    Protected Function GetStorageAccount() As String
        Dim strConn As String = Me.User.Account.StorageAccount
        Return strConn
    End Function
End Class
