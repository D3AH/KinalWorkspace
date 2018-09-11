Imports System.Data.Entity

Namespace AuyonDiego.FarmaciaApp.Model
    Public Class FarmaciaAppDataContext
        Inherits DbContext

        Public Overridable Property Sales As DbSet(Of Sales)
        Public Overridable Property Medicines As DbSet(Of Sales)
        Public Overridable Property Laboratories As DbSet(Of Sales)
    End Class
End Namespace