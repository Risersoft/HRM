Imports CampusMap.Models
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Xml
Imports System.Xml.Serialization
Imports risersoft.shared.portable.Models.Config

Public Class FileStorage
    Private Shared folder As String = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/")

    Public Shared Sub SaveData(data As CampusInfo)
        Dim fileName = Path.Combine(FileStorage.folder, data.CampusName & ".xml")
        Serializer.SerializeObject(data, fileName)
    End Sub

    Public Shared Function GetData(name As String) As CampusInfo
        Dim result As CampusInfo = Nothing

        Dim fileName = Path.Combine(FileStorage.folder, name & ".xml")
        If File.Exists(fileName) Then
            Try
                result = Serializer.DeSerializeObject(Of CampusInfo)(fileName)
            Catch
            End Try
        End If

        Return result
    End Function

    Public Shared Function GetList() As List(Of String)
        Return Directory.GetFiles(FileStorage.folder).Where(Function(x) x.EndsWith(".xml")).[Select](Function(x) Path.GetFileNameWithoutExtension(x)).ToList()
    End Function

    Public Shared Sub Delete(name As String)
        Dim fileName = Path.Combine(FileStorage.folder, name & ".xml")
        Try
            File.Delete(fileName)
        Catch
        End Try
    End Sub
End Class

Class Serializer
    Public Shared Sub SerializeObject(Of T)(serializableObject As T, fileName As String)
        If serializableObject Is Nothing Then
            Return
        End If

        Try
            Dim xmlDocument As New XmlDocument()
            Dim serializer As New XmlSerializer(serializableObject.[GetType]())
            Using stream As New MemoryStream()
                serializer.Serialize(stream, serializableObject)
                stream.Position = 0
                xmlDocument.Load(stream)
                xmlDocument.Save(fileName)
                stream.Close()
            End Using
            'Log exception here
        Catch ex As Exception
        End Try
    End Sub


    ''' <summary>
    ''' Deserializes an xml file into an object list
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    Public Shared Function DeSerializeObject(Of T)(fileName As String) As T
        If String.IsNullOrEmpty(fileName) Then
            Return Nothing
        End If

        Dim objectOut As T = Nothing

        Try
            Dim xmlDocument As New XmlDocument()
            xmlDocument.Load(fileName)
            Dim xmlString As String = xmlDocument.OuterXml

            Using read As New StringReader(xmlString)
                Dim outType As Type = GetType(T)

                Dim serializer As New XmlSerializer(outType)
                Using reader As XmlReader = New XmlTextReader(read)
                    objectOut = DirectCast(serializer.Deserialize(reader), T)
                    reader.Close()
                End Using

                read.Close()
            End Using
            'Log exception here
        Catch ex As Exception
        End Try

        Return objectOut
    End Function
End Class

