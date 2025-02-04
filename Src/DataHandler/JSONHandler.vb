Imports System.IO
Imports System.Xml
Imports Newtonsoft.Json

Module JsonHandler
    Function ChargerJSON(fichier As String) As Dictionary(Of String, List(Of Dictionary(Of String, Object)))
        If Not File.Exists(fichier) Then Return New Dictionary(Of String, List(Of Dictionary(Of String, Object)))

        Dim contenu As String = File.ReadAllText(fichier)
        Return JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of Dictionary(Of String, Object))))(contenu)
    End Function

    Function EnregistrerJSON(fichier As String, data As Dictionary(Of String, List(Of Dictionary(Of String, Object)))) As Boolean
        Try
            Dim json As String = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented)
            File.WriteAllText(fichier, json)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
