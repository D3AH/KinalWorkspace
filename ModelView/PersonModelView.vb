Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class PersonModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _LastName As String
    Private _FirstName As String
    Private _HireDate As Date
    Private _EnrollmentDate As Date

    Private _ListPersons As New List(Of Person) 'Lista de objetos
    Private _Element As Person

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As PersonModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
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

    Public Property HireDate As Date
        Get
            Return _HireDate
        End Get
        Set(value As Date)
            _HireDate = value
        End Set
    End Property

    Public Property EnrollmentDate As Date
        Get
            Return _EnrollmentDate
        End Get
        Set(value As Date)
            _EnrollmentDate = value
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

    Public Property Element As Person
        Get
            Return _Element
        End Get
        Set(value As Person)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.LastName = _Element.LastName
                Me.FirstName = _Element.FirstName
                Me.HireDate = _Element.HireDate
                Me.EnrollmentDate = _Element.EnrollmentDate
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

    Public Property Model As PersonModelView
        Get
            Return _Model
        End Get
        Set(value As PersonModelView)
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
                Dim Registro As New Person
                Registro.PersonID = 100
                Registro.LastName = Me.LastName
                Registro.FirstName = Me.FirstName
                Registro.HireDate = Date.Now
                Registro.EnrollmentDate = Date.Now
                DB.Persons.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListPersons = (From D In DB.Persons Select D).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro? Eliminara todos los registros hijos!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.Persons.Remove(Element)
                        DB.SaveChanges()
                        Me.ListPersons = (From N In DB.Persons Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.LastName = LastName
                    Element.FirstName = FirstName
                    Element.HireDate = HireDate
                    Element.EnrollmentDate = EnrollmentDate
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListPersons = (From N In DB.Persons Select N).ToList
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

    Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property
#End Region
End Class
