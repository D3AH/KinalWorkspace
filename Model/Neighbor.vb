Imports System.ComponentModel.DataAnnotations

Namespace DiegoAuyon.EmetraApp2014277.Model
    Public Class Neighbor

#Region "Campos"
        Private _NIT As String
        Private _DPI As Long
        Private _FirstName As String
        Private _LastName As String
        Private _Address As String
        Private _Municipality As String
        Private _PostalCode As Integer
        Private _Telephone As Integer
#End Region

#Region "Propiedades"
        Public Overridable Property Vehicles() As ICollection(Of Vehicle)

        <Key>
        Public Property NIT() As String
            Get
                Return _NIT
            End Get
            Set(ByVal value As String)
                _NIT = value
            End Set
        End Property

        Public Property DPI As Long
            Get
                Return _DPI
            End Get
            Set(ByVal value As Long)
                _DPI = value
            End Set
        End Property

        Public Property FirstName() As String
            Get
                Return _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property

        Public Property Address() As String
            Get
                Return _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property

        Public Property Municipality() As String
            Get
                Return _Municipality
            End Get
            Set(ByVal value As String)
                _Municipality = value
            End Set
        End Property

        Public Property PostalCode() As Integer
            Get
                Return _PostalCode
            End Get
            Set(ByVal value As Integer)
                _PostalCode = value
            End Set
        End Property

        Public Property Telephone() As Integer
            Get
                Return _Telephone
            End Get
            Set(ByVal value As Integer)
                _Telephone = value
            End Set
        End Property
#End Region

    End Class
End Namespace
