Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class CourseInstructor
#Region "Campos"
        Private _CourseID As Integer
        Private _PersonID As Integer
#End Region
#Region "Propiedades"
        Public Overridable Property Course() As Course
        Public Overridable Property Person() As Person
        <Key, Column(Order:=0)>
        <ForeignKey("Course")>
        Public Property CourseID As Integer
            Get
                Return _CourseID
            End Get
            Set(value As Integer)
                _CourseID = value
            End Set
        End Property
        <Key, Column(Order:=1)>
        <ForeignKey("Person")>
        Public Property PersonID As Integer
            Get
                Return _PersonID
            End Get
            Set(value As Integer)
                _PersonID = value
            End Set
        End Property
    End Class
#End Region
End Namespace