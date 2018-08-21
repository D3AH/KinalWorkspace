Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class Course
#Region "Campos"
        Private _CourseID As Integer
        Private _Title As String
        Private _Credits As Integer
        Private _DepartmentID As Integer
#End Region
#Region "Propiedades"
        <Key>
        Public Property CourseID As Integer
            Get
                Return _CourseID
            End Get
            Set(value As Integer)
                _CourseID = value
            End Set
        End Property

        Public Property Title As String
            Get
                Return _Title
            End Get
            Set(value As String)
                _Title = value
            End Set
        End Property

        Public Property Credits As Integer
            Get
                Return _Credits
            End Get
            Set(value As Integer)
                _Credits = value
            End Set
        End Property

        Public Property DepartmentID As Integer
            Get
                Return _DepartmentID
            End Get
            Set(value As Integer)
                _DepartmentID = value
            End Set
        End Property
#End Region
    End Class

End Namespace
