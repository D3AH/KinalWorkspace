Imports System.ComponentModel
Imports EmetraApp2014277
Imports EmetraApp2014277.DiegoAuyon.EmetraApp2014277.Model

Public Class VehicleModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "General"
#Region "Campos"
    Private _LicensePlate As String
    Private _NIT As String
    Private _Brand As String
    Private _ModelCar As String
    Private _TypeOfVehicle As String
    Private _Color As String
    Private _CirculationCard As Integer
    ' *
    Private _Model As VehicleModelView
    Private _ListVehicle As New List(Of Vehicle)
    Private _Element As Vehicle
    ' Buttons
    Private _BtnNew As Boolean = True
    Private _BtnSave As Boolean = False
    Private _BtnDelete As Boolean = True
    Private _BtnUpdate As Boolean = True
    Private _BtnCancel As Boolean = False
    ' Database
    Private DB As New EmetraApp2014277DataContext
#End Region
#Region "Propiedades"
    Public Property LicensePlate As String
        Get
            Return _LicensePlate
        End Get
        Set(value As String)
            _LicensePlate = value
        End Set
    End Property

    Public Property NIT As String
        Get
            Return _NIT
        End Get
        Set(value As String)
            _NIT = value
        End Set
    End Property

    Public Property Brand As String
        Get
            Return _Brand
        End Get
        Set(value As String)
            _Brand = value
        End Set
    End Property

    Public Property ModelCar As String
        Get
            Return _ModelCar
        End Get
        Set(value As String)
            _ModelCar = value
        End Set
    End Property

    Public Property TypeOfVehicle As String
        Get
            Return _TypeOfVehicle
        End Get
        Set(value As String)
            _TypeOfVehicle = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return _Color
        End Get
        Set(value As String)
            _Color = value
        End Set
    End Property

    Public Property CirculationCard As Integer
        Get
            Return _CirculationCard
        End Get
        Set(value As Integer)
            _CirculationCard = value
        End Set
    End Property

    Public Property Model As VehicleModelView
        Get
            Return _Model
        End Get
        Set(value As VehicleModelView)
            _Model = value
        End Set
    End Property

    Public Property ListVehicle As List(Of Vehicle)
        Get
            If _ListVehicle.Count = 0 Then
                _ListVehicle = (From N In DB.Vehicles Select N).ToList
            End If
            Return _ListVehicle
        End Get
        Set(value As List(Of Vehicle))
            _ListVehicle = value
            NotificarCambio("ListVehicle")
        End Set
    End Property

    Public Property Element As Vehicle
        Get
            Return _Element
        End Get
        Set(value As Vehicle)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.LicensePlate = _Element.LicensePlate
                Me.NIT = _Element.NIT
                Me.Brand = _Element.Brand
                Me.ModelCar = _Element.ModelCar
                Me.TypeOfVehicle = _Element.TypeOfVehicle
                Me.Color = _Element.Color
                Me.CirculationCard = _Element.CirculationCard
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

    Public Property BtnUpdate As Boolean
        Get
            Return _BtnUpdate
        End Get
        Set(value As Boolean)
            _BtnUpdate = value
            NotificarCambio("BtnUpdate")
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
#End Region
#Region "Constructor"
    Public Sub New()
        Me.Model = Me
    End Sub
#End Region
#End Region

#Region "Interfaces"
#Region "INotifyProperty"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotificarCambio(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
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
                Dim Registro As New Vehicle
                Registro.LicensePlate = Me.LicensePlate
                Registro.NIT = Me.NIT
                Registro.Brand = Me.Brand
                Registro.ModelCar = Me.ModelCar
                Registro.TypeOfVehicle = Me.TypeOfVehicle
                Registro.Color = Me.Color
                Registro.CirculationCard = Me.CirculationCard
                DB.Vehicles.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro almacenado!")
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

    Default Public ReadOnly Property Item(columnName As String) As String Implements IDataErrorInfo.Item
        Get
            Throw New NotImplementedException()
        End Get
    End Property

#End Region
#End Region

End Class