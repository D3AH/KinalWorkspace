Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.EmetraApp2014277.Model
    Public Class SanctionType

#Region "Campos"
        Private _SanctionTypeID As Integer
        Private _Description As String
        Private _Import As Integer
#End Region

#Region "Propiedades"
        <Key>
        Public Property SanctionTypeID As Integer
            Get
                Return _SanctionTypeID
            End Get
            Set(value As Integer)
                _SanctionTypeID = value
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

        Public Property Import As Integer
            Get
                Return _Import
            End Get
            Set(value As Integer)
                _Import = value
            End Set
        End Property
#End Region

    End Class
End Namespace
