Imports System.ComponentModel
Imports CETKinal2014277

Public Class MainWindowModelView
    Implements INotifyPropertyChanged
    Implements ICommand
#Region "Campos"
    Private _Model As MainWindowModelView
#End Region
#Region "Propiedades"
    Public Property Model As MainWindowModelView
        Get
            Return _Model
        End Get
        Set(value As MainWindowModelView)
            _Model = value
            NotificarCambio("Model")
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        Me.Model = Me
    End Sub
#End Region
#Region "INotifyPropertyChanged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotificarCambio(ByVal parameter As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(parameter))
    End Sub
#End Region
#Region "ICommand"
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        On Error GoTo ErrorHandler
        Select Case parameter
            Case "Department"
                Dim WindowDepartment = New DepartmentView
                WindowDepartment.Show()
            Case "Course"
                Dim WindowCourse = New CourseView
                WindowCourse.Show()
            Case "Person"
                Dim WindowPerson = New PersonView
                WindowPerson.Show()
            Case "OnlineCourse"
                Dim WindowOnlineCourse = New OnlineCourseView
                WindowOnlineCourse.Show()
            Case "OnSiteCourse"
                Dim WindowOnSiteCourse = New OnSiteCourseView
                WindowOnSiteCourse.Show()
            Case "CourseInstructor"
                Dim WindowCourseInstructor = New CourseInstructorView
                WindowCourseInstructor.Show()
        End Select
        Exit Sub
ErrorHandler:
        MsgBox("Ha ocurrido un error. ErrorType: " & Err.GetException().GetType.ToString, MsgBoxStyle.Critical, "Ups! Ocurrio un error!")
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region
End Class
