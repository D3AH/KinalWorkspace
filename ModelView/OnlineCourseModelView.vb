Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class OnlineCourseModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _URL As String
    Private _CourseID As Integer

    Private _ListOnlineCourses As New List(Of OnlineCourse) 'Lista de objetos
    Private _ListCourses As New List(Of Course)
    Private _Element As OnlineCourse
    Private _Course As Course

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As OnlineCourseModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
    Public Property URL As String
        Get
            Return _URL
        End Get
        Set(value As String)
            _URL = value
            NotificarCambio("URL")
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

    Public Property ListOnlineCourses As List(Of OnlineCourse)
        Get
            If _ListOnlineCourses.Count = 0 Then
                _ListOnlineCourses = (From D In DB.OnlineCourses Select D).ToList
            End If
            Return _ListOnlineCourses
        End Get
        Set(value As List(Of OnlineCourse))
            _ListOnlineCourses = value
            NotificarCambio("ListOnlineCourses")
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

    Public Property Element As OnlineCourse
        Get
            Return _Element
        End Get
        Set(value As OnlineCourse)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.URL = _Element.URL
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

    Public Property Model As OnlineCourseModelView
        Get
            Return _Model
        End Get
        Set(value As OnlineCourseModelView)
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
                Dim Registro As New OnlineCourse With {
                    .URL = Me.URL,
                    .CourseID = Me.Course.CourseID
                }
                DB.OnlineCourses.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListOnlineCourses = (From D In DB.OnlineCourses Select D).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro? Eliminara todos los registros hijos!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.OnlineCourses.Remove(Element)
                        DB.SaveChanges()
                        Me.ListOnlineCourses = (From N In DB.OnlineCourses Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.URL = URL
                    Element.CourseID = CourseID
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListOnlineCourses = (From N In DB.OnlineCourses Select N).ToList
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

    Default Public ReadOnly Property Item(columnURL As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region
End Class
