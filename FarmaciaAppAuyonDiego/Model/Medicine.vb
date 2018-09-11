Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace AuyonDiego.FarmaciaApp.Model
    Public Class Medicine
#Region "Campos"
        Private _MedicineID As Integer
        Private _MedicineName As String
        Private _Description As String
        Private _LaboratoryID As Integer
#End Region
#Region "Propiedades"
        Public Overridable Property Laboratory As Laboratory
        Public Overridable Property Sales As ICollection(Of Sales)

        <Key>
        Public Property MedicineID As Integer
            Get
                Return _MedicineID
            End Get
            Set(value As Integer)
                _MedicineID = value
            End Set
        End Property

        Public Property MedicineName As String
            Get
                Return _MedicineName
            End Get
            Set(value As String)
                _MedicineName = value
            End Set
        End Property

        Public Property Description As String
            Get
                Return _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <ForeignKey("Laboratory")>
        Public Property LaboratoryID As Integer
            Get
                Return _LaboratoryID
            End Get
            Set(value As Integer)
                _LaboratoryID = value
            End Set
        End Property
#End Region
    End Class
End Namespace