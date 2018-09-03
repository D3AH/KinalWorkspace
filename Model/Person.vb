Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class Person
#Region "Campos"
        Private _PersonID As Integer
        Private _LastName As String
        Private _FirstName As String
        Private _HireDate As DateTime
        Private _EnrollmentDate As DateTime
#End Region
#Region "Propiedades"
        Public Overridable Property CourseInstructors() As ICollection(Of CourseInstructor)
        Public Overridable Property StudentGrades() As ICollection(Of StudentGrade)
        Public Overridable Property OfficeAssignment() As OfficeAssignment

        '<DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property PersonID As Integer
            Get
                Return _PersonID
            End Get
            Set(value As Integer)
                _PersonID = value
            End Set
        End Property

        Public Property LastName As String
            Get
                Return _LastName
            End Get
            Set(value As String)
                _LastName = value
            End Set
        End Property

        Public Property FirstName As String
            Get
                Return _FirstName
            End Get
            Set(value As String)
                _FirstName = value
            End Set
        End Property

        Public Property HireDate As DateTime
            Get
                Return _HireDate
            End Get
            Set(value As DateTime)
                _HireDate = value
            End Set
        End Property

        Public Property EnrollmentDate As DateTime
            Get
                Return _EnrollmentDate
            End Get
            Set(value As DateTime)
                _EnrollmentDate = value
            End Set
        End Property
#End Region
    End Class

End Namespace
