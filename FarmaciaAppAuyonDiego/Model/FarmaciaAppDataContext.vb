Imports System.Data.Entity

Namespace AuyonDiego.FarmaciaApp.Model
    Public Class FarmaciaAppDataContext
        Inherits DbContext

        Public Overridable Property Sales As DbSet(Of Sales)
        Public Overridable Property Medicines As DbSet(Of Medicine)
        Public Overridable Property Laboratories As DbSet(Of Laboratory)
    End Class
End Namespace