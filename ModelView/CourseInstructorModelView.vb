Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class CourseInstructorModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _PersonID As String
    Private _CourseID As Integer

    Private _ListCourseInstructors As New List(Of CourseInstructor) 'Lista de objetos
    Private _ListCourses As New List(Of Course)
    Private _ListPersons As New List(Of Person)
    Private _Element As CourseInstructor
    Private _Course As Course
    Private _Person As Person

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As CourseInstructorModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
    Public Property PersonID As String
        Get
            Return _PersonID
        End Get
        Set(value As String)
            _PersonID = value
            NotificarCambio("PersonID")
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

    Public Property ListCourseInstructors As List(Of CourseInstructor)
        Get
            If _ListCourseInstructors.Count = 0 Then
                _ListCourseInstructors = (From D In DB.CourseInstructors Select D).ToList
            End If
            Return _ListCourseInstructors
        End Get
        Set(value As List(Of CourseInstructor))
            _ListCourseInstructors = value
            NotificarCambio("ListCourseInstructors")
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
                _ListPersons = (From D In DB.Persons Where D.PersonType = "Profesor" Select D).ToList
            End If
            Return _ListPersons
        End Get
        Set(value As List(Of Person))
            NotificarCambio("ListPersons")
        End Set
    End Property

    Public Property Element As CourseInstructor
        Get
            Return _Element
        End Get
        Set(value As CourseInstructor)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.PersonID = _Element.PersonID
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

    Public Property Model As CourseInstructorModelView
        Get
            Return _Model
        End Get
        Set(value As CourseInstructorModelView)
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
                Dim Registro As New CourseInstructor With {
                    .PersonID = Me.Person.PersonID,
                    .CourseID = Me.Course.CourseID
                }
                DB.CourseInstructors.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListCourseInstructors = (From D In DB.CourseInstructors Select D).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro? Eliminara todos los registros hijos!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.CourseInstructors.Remove(Element)
                        DB.SaveChanges()
                        Me.ListCourseInstructors = (From N In DB.CourseInstructors Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.PersonID = PersonID
                    Element.CourseID = CourseID
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListCourseInstructors = (From N In DB.CourseInstructors Select N).ToList
                End If
        End Select
        Exit Sub
ErrorHandler:
        If Err.GetException().GetType.ToString = "System.NullReferenceException" Then
            MsgBox("Faltan algunos valores!")
        Else
            MsgBox("Ha ocurrido un error. Verifique que los campos son correctos y no duplicados. ExceptionType:" & Err.GetException().GetType.ToString, MsgBoxStyle.Critical, "Ups! Ocurrio un error!")
        End If
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

    Default Public ReadOnly Property Item(columnPersonID As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region
End Class
