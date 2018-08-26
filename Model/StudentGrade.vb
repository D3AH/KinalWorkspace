Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class StudentGrade
#Region "Campos"
        Private _EnrollmentID As Integer
        Private _CourseID As Integer
        Private _StudentID As Integer
        Private _Grade As Integer
#End Region
#Region "Propiedades"
        Public Overridable Property Person() As Person
        Public Overridable Property Course() As Course
        <Key>
        Public Property EnrollmentID As Integer
            Get
                Return _EnrollmentID
            End Get
            Set(value As Integer)
                _EnrollmentID = value
            End Set
        End Property
        <ForeignKey("Course")>
        Public Property CourseID As Integer
            Get
                Return _CourseID
            End Get
            Set(value As Integer)
                _CourseID = value
            End Set
        End Property
        <ForeignKey("Person")>
        Public Property StudentID As Integer
            Get
                Return _StudentID
            End Get
            Set(value As Integer)
                _StudentID = value
            End Set
        End Property

        Public Property Grade As Integer
            Get
                Return _Grade
            End Get
            Set(value As Integer)
                _Grade = value
            End Set
        End Property
#End Region
    End Class

End Namespace
