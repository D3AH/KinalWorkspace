Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class OnSiteCourse
#Region "Campos"
        Private _CourseID As Integer
        Private _Location As String
        Private _Days As String
        Private _Time As Date
#End Region
#Region "Propiedades"
        Public Overridable Property Course() As Course
        <Key>
        <ForeignKey("Course")>
        Public Property CourseID As Integer
            Get
                Return _CourseID
            End Get
            Set(value As Integer)
                _CourseID = value
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

        Public Property Days As String
            Get
                Return _Days
            End Get
            Set(value As String)
                _Days = value
            End Set
        End Property

        Public Property Time As Date
            Get
                Return _Time
            End Get
            Set(value As Date)
                _Time = value
            End Set
        End Property
#End Region
    End Class

End Namespace