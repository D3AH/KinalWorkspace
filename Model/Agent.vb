Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.EmetraApp2014277.Model
    Public Class Agent

#Region "Campos"
        Private _AgentID As Integer
        Private _AgentNumber As String
        Private _AgentName As String
        Private _AgentFirstName As String
        Private _AgentLastName As String
        Private _Charge As String
        Private _Salary As Integer
        Private _Commission As Integer
#End Region

#Region "Propiedades"
        Public Overridable Property Remissions() As ICollection(Of Remission)

        <Key>
        Public Property AgentID As Integer
            Get
                Return _AgentID
            End Get
            Set(value As Integer)
                _AgentID = value
            End Set
        End Property

        Public Property AgentNumber As String
            Get
                Return _AgentNumber
            End Get
            Set(value As String)
                _AgentNumber = value
            End Set
        End Property

        Public Property AgentName As String
            Get
                Return _AgentName
            End Get
            Set(value As String)
                _AgentName = value
            End Set
        End Property

        Public Property AgentFirstName As String
            Get
                Return _AgentFirstName
            End Get
            Set(value As String)
                _AgentFirstName = value
            End Set
        End Property

        Public Property AgentLastName As String
            Get
                Return _AgentLastName
            End Get
            Set(value As String)
                _AgentLastName = value
            End Set
        End Property

        Public Property Charge As String
            Get
                Return _Charge
            End Get
            Set(value As String)
                _Charge = value
            End Set
        End Property

        Public Property Salary As Integer
            Get
                Return _Salary
            End Get
            Set(value As Integer)
                _Salary = value
            End Set
        End Property

        Public Property Commission As Integer
            Get
                Return _Commission
            End Get
            Set(value As Integer)
                _Commission = value
            End Set
        End Property
#End Region

    End Class
End Namespace
