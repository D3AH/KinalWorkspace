Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class OfficeAssignmentModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _InstructorID As Integer
    Private _Location As String
    Private _TimeStamp As Byte

    Private _ListOfficeAssignments As New List(Of OfficeAssignment) 'Lista de objetos
    Private _ListPersons As New List(Of Person)
    Private _Element As OfficeAssignment
    Private _Person As Person

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As OfficeAssignmentModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
    Public Property Location As String
        Get
            Return _Location
        End Get
        Set(value As String)
            _Location = value
            NotificarCambio("Location")
        End Set
    End Property

    Public Property InstructorID As Integer
        Get
            Return _InstructorID
        End Get
        Set(value As Integer)
            _InstructorID = value
            NotificarCambio("InstructorID")
        End Set
    End Property

    Public Property TimeStamp As Byte
        Get
            Return _TimeStamp
        End Get
        Set(value As Byte)
            _TimeStamp = value
        End Set
    End Property

    Public Property ListOfficeAssignments As List(Of OfficeAssignment)
        Get
            If _ListOfficeAssignments.Count = 0 Then
                _ListOfficeAssignments = (From D In DB.OfficeAssignments Select D).ToList
            End If
            Return _ListOfficeAssignments
        End Get
        Set(value As List(Of OfficeAssignment))
            _ListOfficeAssignments = value
            NotificarCambio("ListOfficeAssignments")
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
            _ListPersons = value
            NotificarCambio("ListPersons")
        End Set
    End Property

    Public Property Element As OfficeAssignment
        Get
            Return _Element
        End Get
        Set(value As OfficeAssignment)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.Location = _Element.Location
                Me.TimeStamp = _Element.TimeStamp
                Me.InstructorID = _Element.InstructorID
            End If
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

    Public Property Model As OfficeAssignmentModelView
        Get
            Return _Model
        End Get
        Set(value As OfficeAssignmentModelView)
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
                Dim Registro As New OfficeAssignment With {
                    .Location = Me.Location,
                    .TimeStamp = Me.TimeStamp,
                    .InstructorID = Me.Person.PersonID
                }
                DB.OfficeAssignments.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListOfficeAssignments = (From D In DB.OfficeAssignments Select D).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro? Eliminara todos los registros hijos!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.OfficeAssignments.Remove(Element)
                        DB.SaveChanges()
                        Me.ListOfficeAssignments = (From N In DB.OfficeAssignments Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.Location = Location
                    Element.TimeStamp = TimeStamp
                    Element.InstructorID = InstructorID
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListOfficeAssignments = (From N In DB.OfficeAssignments Select N).ToList
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

    Default Public ReadOnly Property Item(columnLocation As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region
End Class
