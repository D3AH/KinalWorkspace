Imports System.ComponentModel.DataAnnotations

Namespace AuyonDiego.FarmaciaApp.Model
    Public Class Laboratory
#Region "Campos"
        Private _LaboratoryID As Integer
        Private _LaboratoryName As String
        Private _Address As String
        Private _Telephone As String
#End Region
#Region "Propiedades"
        Public Overridable Property Medicines() As ICollection(Of Medicine)

        <Key>
        Public Property LaboratoryID As Integer
            Get
                Return _LaboratoryID
            End Get
            Set(value As Integer)
                _LaboratoryID = value
            End Set
        End Property

        Public Property LaboratoryName As String
            Get
                Return _LaboratoryName
            End Get
            Set(value As String)
                _LaboratoryName = value
            End Set
        End Property

        Public Property Address As String
            Get
                Return _Address
            End Get
            Set(value As String)
                _Address = value
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
#End Region
    End Class
End Namespace