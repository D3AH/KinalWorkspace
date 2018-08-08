Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.EmetraApp2014277.Model
    Public Class Remission

#Region "Campos"
        Private _RemissionID As Integer
        Private _SanctionTypeID As Integer
        Private _RemissionDate As DateTime
        Private _Hour As String
        Private _Place As String
        Private _AgentID As Integer
        Private _LicensePlate As String
#End Region

#Region "Propiedades"
        Public Overridable Property Vehicle() As Vehicle
        Public Overridable Property Agent() As Agent
        Public Overridable Property SanctionType() As SanctionType

        <Key>
        Public Property RemissionID As Integer
            Get
                Return _RemissionID
            End Get
            Set(value As Integer)
                _RemissionID = value
            End Set
        End Property

        <ForeignKey("SanctionType")>
        Public Property SanctionTypeID As Integer
            Get
                Return _SanctionTypeID
            End Get
            Set(value As Integer)
                _SanctionTypeID = value
            End Set
        End Property

        Public Property RemissionDate As Date
            Get
                Return _RemissionDate
            End Get
            Set(value As Date)
                _RemissionDate = value
            End Set
        End Property

        Public Property Hour As String
            Get
                Return _Hour
            End Get
            Set(value As String)
                _Hour = value
            End Set
        End Property

        Public Property Place As String
            Get
                Return _Place
            End Get
            Set(value As String)
                _Place = value
            End Set
        End Property

        Public Property AgentID As Integer
            Get
                Return _AgentID
            End Get
            Set(value As Integer)
                _AgentID = value
            End Set
        End Property

        <ForeignKey("Vehicle")>
        Public Property LicensePlate As String
            Get
                Return _LicensePlate
            End Get
            Set(value As String)
                _LicensePlate = value
            End Set
        End Property
#End Region

    End Class
End Namespace

