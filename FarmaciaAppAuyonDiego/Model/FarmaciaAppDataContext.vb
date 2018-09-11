Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Data.Entity.Infrastructure
Imports System.Linq

Namespace AuyonDiego.FarmaciaApp.Model
    Public Class FarmaciaAppDataContext
        Inherits DbContext

        Public Property Sales As DbSet(Of Sales)
        Public Property Medicines As DbSet(Of Medicine)
        Public Property Laboratories As DbSet(Of Laboratory)

    End Class
End Namespace