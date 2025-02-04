Module DataStructures

    Public Structure Article
        Dim ID As Integer
        Dim Nom As String
        Dim Prix As Decimal
        Dim TVA As Decimal
        Dim Stock As Integer
    End Structure

    Public Structure Vente
        Dim ID As Integer
        Dim Articles As List(Of Article)
        Dim TotalHT As Decimal
        Dim TVA As Decimal
        Dim TotalTTC As Decimal
        Dim CaissierID As Integer
        Dim DateHeure As DateTime
    End Structure

    Public Structure Paiement
        Dim Montant As Decimal
        Dim Mode As String ' "Espèces", "CB", "Mixte"
        Dim RenduMonnaie As Decimal
    End Structure

    Public Structure Caisse
        Dim MontantInitial As Decimal
        Dim MontantActuel As Decimal
        Dim TotalTransactions As Decimal
        Dim RetraitsAjouts As List(Of Decimal)
    End Structure

    Public Structure Ticket
        Dim IDVente As Integer
        Dim Articles As List(Of Article)
        Dim MontantTotal As Decimal
        Dim ModePaiement As String
        Dim DateHeure As DateTime
    End Structure

    Public Structure Utilisateur
        Dim ID As Integer
        Dim Nom As String
        Dim Role As String ' "Caissier", "Admin"
        Dim HistoriqueVentes As List(Of Integer)
    End Structure

End Module
