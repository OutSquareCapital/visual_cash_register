Imports System.IO
Imports visual_cash_register.DataStructures

Public Class ForMain
    Private Sub ForMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cheminCSV As String = "C:\Users\stett\source\repos\visual_cash_register\Src\DataBase\transactions.csv"

        If Not File.Exists(cheminCSV) Then
            MessageBox.Show("Le fichier CSV est introuvable : " & cheminCSV)
            Exit Sub
        End If

        ' 📌 TEST LECTURE CSV - Conversion en Liste de Vente
        Dim transactionsCSV As List(Of String()) = CsvHandler.LoadCSV(cheminCSV)
        Dim transactions As New List(Of Vente)

        For Each ligne As String() In transactionsCSV.Skip(1) ' On ignore l'en-tête CSV
            Dim vente As New Vente With {
                .ID = CInt(ligne(0)),
                .Articles = New List(Of Article) From {
                    New Article With {
                        .Nom = ligne(2),
                        .Stock = CInt(ligne(3)),
                        .Prix = CDec(ligne(4))
                    }
                },
                .TotalHT = CDec(ligne(4)),
                .TVA = 0.2D * CDec(ligne(4)),
                .TotalTTC = CDec(ligne(4)) * 1.2D,
                .CaissierID = 1,
                .DateHeure = DateTime.Parse(ligne(1))
            }
            transactions.Add(vente)
        Next

        If transactions.Count > 0 Then
            Dim premiereVente As Vente = transactions(0)
            MessageBox.Show("Transactions chargées : " & premiereVente.Articles(0).Nom & " - Quantité : " & premiereVente.Articles(0).Stock)

            ' 📌 TEST AJOUT TRANSACTION
            Dim nouvelleVente As New Vente With {
                .ID = transactions.Count + 1,
                .Articles = New List(Of Article) From {
                    New Article With {
                        .Nom = "Café",
                        .Stock = 1,
                        .Prix = 2D
                    }
                },
                .TotalHT = 2D,
                .TVA = 0.4D,
                .TotalTTC = 2.4D,
                .CaissierID = 1,
                .DateHeure = DateTime.Now
            }
            transactions.Add(nouvelleVente)

            ' 📌 Conversion en format CSV et sauvegarde
            Dim transactionsCSVModifie As New List(Of String()) From {
                New String() {"ID", "Date", "Article", "Quantité", "Total"}
            }

            For Each vente As Vente In transactions
                transactionsCSVModifie.Add(New String() {
                    vente.ID.ToString(),
                    vente.DateHeure.ToString("yyyy-MM-dd HH:mm:ss"),
                    vente.Articles(0).Nom,
                    vente.Articles(0).Stock.ToString(),
                    vente.TotalHT.ToString("0.00")
                })
            Next

            Dim resultat As Boolean = CsvHandler.SaveCSV(cheminCSV, transactionsCSVModifie)

            If resultat Then
                MessageBox.Show("Nouvelle transaction ajoutée : " & nouvelleVente.Articles(0).Nom & " - Quantité : " & nouvelleVente.Articles(0).Stock)
            Else
                MessageBox.Show("Erreur lors de l'enregistrement CSV.")
            End If
        Else
            MessageBox.Show("Aucune transaction trouvée dans le fichier CSV.")
        End If
    End Sub
End Class
