Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Data.SqlClient

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class CETKinal2014277DataContext
        Inherits DbContext
        Public Property Courses() As DbSet(Of Course)
        Public Property Departments() As DbSet(Of Department)
        Public Property OfficeAssignments() As DbSet(Of OfficeAssignment)
        Public Property OnlineCourses() As DbSet(Of OnlineCourse)
        Public Property OnSiteCourses() As DbSet(Of OnSiteCourse)
        Public Property Persons() As DbSet(Of Person)
        Public Property StudentGrades() As DbSet(Of StudentGrade)
        Public Property CourseInstructors() As DbSet(Of CourseInstructor)

        'Elimina plurilizacion
        'Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        '    modelBuilder.Conventions.Remove(Of PluralizingEntitySetNameConvention)()
        'End Sub
    End Class

End Namespace
