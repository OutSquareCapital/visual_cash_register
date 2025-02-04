Imports System.IO

Public Class ForMain
    Private Sub ForMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cheminArticles As String = "C:\Users\stett\source\repos\visual_cash_register\Src\DataBase\articles.json"

        If Not File.Exists(cheminArticles) Then
            MessageBox.Show("Le fichier JSON est introuvable : " & cheminArticles)

            Exit Sub
        End If

        ' 📌 TEST LECTURE JSON
        Dim data As Object = JsonHandler.ChargerJSON(cheminArticles)
        If data IsNot Nothing AndAlso data.ContainsKey("Articles") Then
            Dim articles As Object = data("Articles")

            If articles.Count > 0 Then
                MessageBox.Show("Articles chargés : " & articles(0)("Nom") & " - Stock : " & articles(0)("Stock"))

                ' 📌 TEST MODIFICATION STOCK
                articles(0)("Stock") -= 5
                Dim resultat As Boolean = JsonHandler.EnregistrerJSON(cheminArticles, data)

                If resultat Then
                    MessageBox.Show("Stock mis à jour : " & articles(0)("Stock"))
                Else
                    MessageBox.Show("Erreur lors de l'enregistrement JSON.")
                End If
            Else
                MessageBox.Show("Aucun article trouvé dans le fichier JSON.")
            End If
        Else
            MessageBox.Show("Échec de la lecture JSON.")
        End If

    End Sub
End Class
