Imports System.ComponentModel
Imports EmetraApp2014277
Imports EmetraApp2014277.DiegoAuyon.EmetraApp2014277.Model

Public Class NeighborModelView

    Implements INotifyPropertyChanged, ICommand, IDataErrorInfo

#Region "General"
#Region "Campos"
    Private _NIT As String
    Private _DPI As Long
    Private _FirstName As String
    Private _LastName As String
    Private _Address As String
    Private _Municipality As String
    Private _PostalCode As Integer
    Private _Telephone As Integer
    ' *
    Private _Model As NeighborModelView
    Private _ListNeighbor As New List(Of Neighbor)
    Private _Element As Neighbor
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
    Public Property NIT As String
        Get
            Return _NIT
        End Get
        Set(value As String)
            _NIT = value
            NotificarCambio("NIT")
        End Set
    End Property

    Public Property DPI As Long
        Get
            Return _DPI
        End Get
        Set(value As Long)
            _DPI = value
            NotificarCambio("DPI")
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            _FirstName = value
            NotificarCambio("FirstName")
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            _LastName = value
            NotificarCambio("LastName")
        End Set
    End Property

    Public Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            _Address = value
            NotificarCambio("Address")
        End Set
    End Property

    Public Property Municipality As String
        Get
            Return _Municipality
        End Get
        Set(value As String)
            _Municipality = value
            NotificarCambio("Municipality")
        End Set
    End Property

    Public Property PostalCode As Integer
        Get
            Return _PostalCode
        End Get
        Set(value As Integer)
            _PostalCode = value
            NotificarCambio("PostalCode")
        End Set
    End Property

    Public Property Telephone As Integer
        Get
            Return _Telephone
        End Get
        Set(value As Integer)
            _Telephone = value
            NotificarCambio("Telephone")
        End Set
    End Property

    Public Property Model As NeighborModelView
        Get
            Return _Model
        End Get
        Set(value As NeighborModelView)
            _Model = value
        End Set
    End Property

    Public Property ListNeighbor As List(Of Neighbor)
        Get
            If _ListNeighbor.Count = 0 Then
                _ListNeighbor = (From N In DB.Neighbors Select N).ToList
            End If
            Return _ListNeighbor
        End Get
        Set(value As List(Of Neighbor))
            _ListNeighbor = value
            NotificarCambio("ListNeighbor")
        End Set
    End Property

    Public Property Element As Neighbor
        Get
            Return _Element
        End Get
        Set(value As Neighbor)
            _Element = value
            NotificarCambio("Element")
            If value IsNot Nothing Then
                Me.NIT = _Element.NIT
                Me.DPI = _Element.DPI
                Me.FirstName = _Element.FirstName
                Me.LastName = _Element.LastName
                Me.Municipality = _Element.Municipality
                Me.PostalCode = _Element.PostalCode
                Me.Telephone = _Element.Telephone
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
                Dim Registro As New Neighbor
                Registro.NIT = Me.NIT
                Registro.DPI = Me.DPI
                Registro.FirstName = Me.FirstName
                Registro.LastName = Me.LastName
                Registro.Municipality = Me.Municipality
                Registro.PostalCode = Me.PostalCode
                Registro.Telephone = Me.Telephone
                Registro.Address = Me.Address
                DB.Neighbors.Add(Registro)
                DB.SaveChanges()
                MsgBox("Registro almacenado!")
                Me.ListNeighbor = (From N In DB.Neighbors Select N).ToList
            Case "Delete"
                If Element IsNot Nothing Then
                    Dim Respuesta As MsgBoxResult = MsgBoxResult.No
                    Respuesta = MsgBox("¿Está seguro de eliminar el registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Eliminar")
                    If Respuesta = MsgBoxResult.Yes Then
                        DB.Neighbors.Remove(Element)
                        DB.SaveChanges()
                        Me.ListNeighbor = (From N In DB.Neighbors Select N).ToList
                    End If
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Update"
                If Element IsNot Nothing Then
                    Element.NIT = NIT
                    Element.DPI = DPI
                    Element.FirstName = FirstName
                    Element.LastName = LastName
                    Element.Address = Address
                    Element.Municipality = Municipality
                    Element.PostalCode = PostalCode
                    Element.Telephone = Telephone
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    Me.ListNeighbor = (From N In DB.Neighbors Select N).ToList
                End If
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