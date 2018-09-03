Imports System.ComponentModel
Imports CETKinal2014277
Imports CETKinal2014277.DiegoAuyon.CETKinal2014277.Model

Public Class DepartmentModelView
    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "Campos"
    Private _Name As String
    Private _Budget As Decimal
    Private _Administrator As Integer
    Private _StartDate As Date = Date.Now

    Private _ListDepartments As New List(Of Department) 'Lista de objetos
    Private _Element As Department

    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnCancel As Boolean = False
    Private _BtnUpdate As Boolean = True

    Private _Model As DepartmentModelView

    Private DB As New CETKinal2014277DataContext
#End Region
#Region "Propiedades"
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
            NotificarCambio("Name")
        End Set
    End Property

    Public Property Budget As Decimal
        Get
            Return _Budget
        End Get
        Set(value As Decimal)
            _Budget = value
            NotificarCambio("Budget")
        End Set
    End Property

    Public Property Administrator As Integer
        Get
            Return _Administrator
        End Get
        Set(value As Integer)
            _Administrator = value
            NotificarCambio("Administrator")
        End Set
    End Property

    Public Property StartDate As Date
        Get
            Return _StartDate
        End Get
        Set(value As Date)
            _StartDate = value
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

    Public Property Element As Department
        Get
            Return _Element
        End Get
        Set(value As Department)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.Name = _Element.Name
                Me.Budget = _Element.Budget
                Me.Administrator = _Element.Administrator
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

    Public Property Model As DepartmentModelView
        Get
            Return _Model
        End Get
        Set(value As DepartmentModelView)
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
        'On Error GoTo ErrorHandler
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
                Dim Registro As New Department
                Registro.Name = Me.Name
                Registro.Budget = Me.Budget
                Registro.StartDate = Me.StartDate.Date.ToLocalTime
                Registro.Administrator = Me.Administrator
                DB.Departments.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro Almacenado")
                Me.ListDepartments = (From D In DB.Departments Select D).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro? Eliminara todos los registros hijos!", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.Departments.Remove(Element)
                        DB.SaveChanges()
                        Me.ListDepartments = (From N In DB.Departments Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.Name = Name
                    Element.Budget = Budget
                    Element.Administrator = Administrator
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListDepartments = (From N In DB.Departments Select N).ToList
                Else
                    MsgBox("Debe selecionar un registro")
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
