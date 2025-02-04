Imports System.IO

Module CsvHandler
    Function LireCSV(fichier As String) As List(Of String())
        Dim lignes As New List(Of String())

        If Not File.Exists(fichier) Then Return lignes

        Using lecteur As New StreamReader(fichier)
            While Not lecteur.EndOfStream
                lignes.Add(lecteur.ReadLine().Split(","c))
            End While
        End Using

        Return lignes
    End Function

    Function EcrireCSV(fichier As String, lignes As List(Of String())) As Boolean
        Try
            Using writer As New StreamWriter(fichier, False)
                For Each ligne As String() In lignes
                    writer.WriteLine(String.Join(",", ligne))
                Next
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
