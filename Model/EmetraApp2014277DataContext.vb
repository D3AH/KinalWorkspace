Imports System.Data.Entity
Imports System.Data.SqlClient
Imports System.Data.Entity.ModelConfiguration.Conventions

Namespace DiegoAuyon.EmetraApp2014277.Model
    Public Class EmetraApp2014277DataContext
        Inherits DbContext
        Public Property Agents() As DbSet(Of Agent)
        Public Property Neighbors() As DbSet(Of Neighbor)
        Public Property Remissions() As DbSet(Of Remission)
        Public Property SanctionTypes() As DbSet(Of SanctionType)
        Public Property Vehicles() As DbSet(Of Vehicle)
    End Class
End Namespace