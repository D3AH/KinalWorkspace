Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.EmetraApp2014277.Model
    Public Class Vehicle

#Region "Campos"
        Private _LicensePlate As String
        Private _NIT As String
        Private _Brand As String
        Private _ModelCar As String
        Private _TypeOfVehicle As String
        Private _Color As String
        Private _CirculationCard As Integer
#End Region
#Region "Propiedades"
        Public Overridable Property Remission() As Remission
        Public Overridable Property Remissions() As ICollection(Of Remission)

        <Key>
        Public Property LicensePlate As String
            Get
                Return _LicensePlate
            End Get
            Set(value As String)
                _LicensePlate = value
            End Set
        End Property

        'Llave foranea
        Public Property NIT As String
            Get
                Return _NIT
            End Get
            Set(value As String)
                _NIT = value
            End Set
        End Property

        Public Property Brand As String
            Get
                Return _Brand
            End Get
            Set(value As String)
                _Brand = value
            End Set
        End Property

        Public Property ModelCar As String
            Get
                Return _ModelCar
            End Get
            Set(value As String)
                _ModelCar = value
            End Set
        End Property

        Public Property TypeOfVehicle As String
            Get
                Return _TypeOfVehicle
            End Get
            Set(value As String)
                _TypeOfVehicle = value
            End Set
        End Property

        Public Property Color As String
            Get
                Return _Color
            End Get
            Set(value As String)
                _Color = value
            End Set
        End Property

        Public Property CirculationCard As Integer
            Get
                Return _CirculationCard
            End Get
            Set(value As Integer)
                _CirculationCard = value
            End Set
        End Property
#End Region

    End Class
End Namespace

