Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace AuyonDiego.FarmaciaApp.Model
    Public Class Sales
#Region "Campos"
        Private _SalesID As Integer
        Private _SalesDate As Date
        Private _Price As Decimal
        Private _Amount As Decimal
        Private _Telephone As String
        Private _MedicineID As Integer
#End Region
#Region "Propiedades"
        Public Overridable Property Medicine As Medicine

        <Key>
        Public Property SalesID As Integer
            Get
                Return _SalesID
            End Get
            Set(value As Integer)
                _SalesID = value
            End Set
        End Property

        Public Property SalesDate As Date
            Get
                Return _SalesDate
            End Get
            Set(value As Date)
                _SalesDate = value
            End Set
        End Property

        Public Property Price As Decimal
            Get
                Return _Price
            End Get
            Set(value As Decimal)
                _Price = value
            End Set
        End Property

        Public Property Amount As Decimal
            Get
                Return _Amount
            End Get
            Set(value As Decimal)
                _Amount = value
            End Set
        End Property

        Public Property Telephone As String
            Get
                Return _Telephone
            End Get
            Set(value As String)
                _Telephone = value
            End Set
        End Property
        <ForeignKey("Medicine")>
        Public Property MedicineID As Integer
            Get
                Return _MedicineID
            End Get
            Set(value As Integer)
                _MedicineID = value
            End Set
        End Property
#End Region
    End Class
End Namespace