Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class StudentGradeModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _StudentID As String
    Private _CourseID As Integer
    Private _Grade As Integer

    Private _ListStudentGrades As New List(Of StudentGrade) 'Lista de objetos
    Private _ListCourses As New List(Of Course)
    Private _ListPersons As New List(Of Person)
    Private _Element As StudentGrade
    Private _Course As Course
    Private _Person As Person

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As StudentGradeModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
    Public Property StudentID As String
        Get
            Return _StudentID
        End Get
        Set(value As String)
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

    Public Property CourseID As Integer
        Get
            Return _CourseID
        End Get
        Set(value As Integer)
            _CourseID = value
            NotificarCambio("CourseID")
        End Set
    End Property

    Public Property ListStudentGrades As List(Of StudentGrade)
        Get
            If _ListStudentGrades.Count = 0 Then
                _ListStudentGrades = (From D In DB.StudentGrades Select D).ToList
            End If
            Return _ListStudentGrades
        End Get
        Set(value As List(Of StudentGrade))
            _ListStudentGrades = value
            NotificarCambio("ListStudentGrades")
        End Set
    End Property

    Public Property ListCourses As List(Of Course)
        Get
            If _ListCourses.Count = 0 Then
                _ListCourses = (From D In DB.Courses Select D).ToList
            End If
            Return _ListCourses
        End Get
        Set(value As List(Of Course))
            _ListCourses = value
            NotificarCambio("ListCourses")
        End Set
    End Property

    Public Property ListPersons As List(Of Person)
        Get
            If _ListPersons.Count = 0 Then
                _ListPersons = (From D In DB.Persons Select D).ToList
            End If
            Return _ListPersons
        End Get
        Set(value As List(Of Person))
            _ListPersons = value
            NotificarCambio("ListPersons")
        End Set
    End Property

    Public Property Element As StudentGrade
        Get
            Return _Element
        End Get
        Set(value As StudentGrade)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.StudentID = _Element.StudentID
                Me.Grade = _Element.Grade
                Me.CourseID = _Element.CourseID
            End If
        End Set
    End Property
    Public Property Course As Course
        Get
            Return _Course
        End Get
        Set(value As Course)
            _Course = value
            NotificarCambio("Course")
        End Set
    End Property

    Public Property Person As Person
        Get
            Return _Person
        End Get
        Set(value As Person)
            _Person = value
            NotificarCambio("Person")
        End Set
    End Property

    Public Property BtnNew As Boolean
        Get
            Return _BtnNew
        End Get
        Set(value As Boolean)
            _BtnNew = value
            NotificarCambio("BtnNew")
        End Set
    End Property

    Public Property BtnSave As Boolean
        Get
            Return _BtnSave
        End Get
        Set(value As Boolean)
            _BtnSave = value
            NotificarCambio("BtnSave")
        End Set
    End Property

    Public Property BtnDelete As Boolean
        Get
            Return _BtnDelete
        End Get
        Set(value As Boolean)
            _BtnDelete = value
            NotificarCambio("BtnDelete")
        End Set
    End Property

    Public Property BtnCancel As Boolean
        Get
            Return _BtnCancel
        End Get
        Set(value As Boolean)
            _BtnCancel = value
            NotificarCambio("BtnCancel")
        End Set
    End Property

    Public Property BtnUpdate As Boolean
        Get
            Return _BtnUpdate
        End Get
        Set(value As Boolean)
            _BtnUpdate = value
            NotificarCambio("BtnUpdate")
        End Set
    End Property

    Public Property Model As StudentGradeModelView
        Get
            Return _Model
        End Get
        Set(value As StudentGradeModelView)
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
            Case "New"
                Me.BtnNew = False
                Me.BtnSave = True
                Me.BtnDelete = False
                Me.BtnUpdate = False
                Me.BtnCancel = True
            Case "Save"
                Me.BtnNew = Not Me.BtnNew
                Me.BtnSave = Not Me.BtnSave
                Me.BtnDelete = Not Me.BtnDelete
                Me.BtnUpdate = Not Me.BtnUpdate
                Me.BtnCancel = Not Me.BtnCancel
                Dim Registro As New StudentGrade With {
                    .StudentID = Me.Person.PersonID,
                    .Grade = Me.Grade,
                    .CourseID = Me.Course.CourseID
                }
                DB.StudentGrades.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListStudentGrades = (From D In DB.StudentGrades Select D).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro? Eliminara todos los registros hijos!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.StudentGrades.Remove(Element)
                        DB.SaveChanges()
                        Me.ListStudentGrades = (From N In DB.StudentGrades Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.StudentID = StudentID
                    Element.Grade = Grade
                    Element.CourseID = CourseID
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListStudentGrades = (From N In DB.StudentGrades Select N).ToList
                End If
        End Select
        Exit Sub
ErrorHandler:
        MsgBox("Ha ocurrido un error. ErrorType: " & Err.GetException().GetType.ToString, MsgBoxStyle.Critical, "Ups! Ocurrio un error!")
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region
#Region "IDataErrorInfo"
    Public ReadOnly Property [Error] As String Implements IDataErrorInfo.Error
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Default Public ReadOnly Property Item(columnStudentID As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region
End Class
