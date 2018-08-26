﻿Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class CourseModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _Title As String
    Private _Credits As Integer
    Private _DepartmentID As Integer

    Private _ListCourses As New List(Of Course) 'Lista de objetos
    Private _ListDepartments As New List(Of Department)
    Private _Element As Course

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As CourseModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
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

    Public Property ListDepartments As List(Of Department)
        Get
            If _ListDepartments.Count = 0 Then
                _ListDepartments = (From D In DB.Departments Select D).ToList
            End If
            Return _ListDepartments
        End Get
        Set(value As List(Of Department))
            _ListDepartments = value
            NotificarCambio("ListDepartments")
        End Set
    End Property

    Public Property Element As Course
        Get
            Return _Element
        End Get
        Set(value As Course)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.Title = _Element.Title
                Me.Credits = _Element.Credits
                Me.DepartmentID = _Element.DepartmentID
            End If
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

    Public Property Model As CourseModelView
        Get
            Return _Model
        End Get
        Set(value As CourseModelView)
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
                Dim Registro As New Course With {
                    .Title = Me.Title,
                    .Credits = Me.Credits,
                    .DepartmentID = Me.DepartmentID
                }
                DB.Courses.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListCourses = (From D In DB.Courses Select D).ToList
        End Select
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

    Default Public ReadOnly Property Item(columnTitle As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region
End Class
