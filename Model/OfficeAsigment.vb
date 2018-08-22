Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class OfficeAsigment
#Region "Campos"
        Private _InstructorID As Integer
        Private _Location As String
        Private _TimeStamp As Byte
#End Region
#Region "Propiedades"
        <Key>
        Public Property InstructorID As Integer
            Get
                Return _InstructorID
            End Get
            Set(value As Integer)
                _InstructorID = value
            End Set
        End Property

        Public Property Location As String
            Get
                Return _Location
            End Get
            Set(value As String)
                _Location = value
            End Set
        End Property

        Public Property TimeStamp As Byte
            Get
                Return _TimeStamp
            End Get
            Set(value As Byte)
                _TimeStamp = value
            End Set
        End Property
#End Region
    End Class

End Namespace