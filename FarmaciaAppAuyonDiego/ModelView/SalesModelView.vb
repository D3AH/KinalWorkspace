Imports System.ComponentModel
Imports FarmaciaAppAuyonDiego.AuyonDiego.FarmaciaApp.Model

Public Class SalesModelView
    Implements ICommand, IDataErrorInfo, INotifyPropertyChanged

    Private _SalesDate As Date
    Private _Price As Decimal
    Private _Amount As Decimal
    Private _Telephone As String
    Private _MedicineID As Integer

    Private _ListSales As ICollection(Of Sales)
    Private _Element As Sales
    Private _Model As SalesModelView

    Private _BtnNew = True
    Private _BtnSave = False
    Private _BtnEliminar = True
    Private _BtnUpdate = True

    Private DB As New FarmaciaAppDataContext

#Region "Propiedades"
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
#Region "SalesModelView"
    Public Property SalesDate As Date
        Get
            Return _SalesDate
        End Get
        Set(value As Date)
            _SalesDate = value
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return _Price
        End Get
        Set(value As Decimal)
            _Price = value
        End Set
    End Property

    Public Property Amount As Decimal
        Get
            Return _Amount
        End Get
        Set(value As Decimal)
            _Amount = value
        End Set
    End Property

    Public Property Telephone As String
        Get
            Return _Telephone
        End Get
        Set(value As String)
            _Telephone = value
        End Set
    End Property

    Public Property MedicineID As Integer
        Get
            Return _MedicineID
        End Get
        Set(value As Integer)
            _MedicineID = value
        End Set
    End Property

    Public Property ListSales As ICollection(Of Sales)
        Get
            If _ListSales Is Nothing Then
                _ListSales = (From DB.Sales )
            End If
            Return _ListSales
        End Get
        Set(value As ICollection(Of Sales))
            _ListSales = value
        End Set
    End Property

    Public Property Element As Sales
        Get
            Return _Element
        End Get
        Set(value As Sales)
            _Element = value
        End Set
    End Property

    Public Property Model As SalesModelView
        Get
            Return _Model
        End Get
        Set(value As SalesModelView)
            _Model = value
        End Set
    End Property

    Public Property BtnNew As Object
        Get
            Return _BtnNew
        End Get
        Set(value As Object)
            _BtnNew = value
        End Set
    End Property

    Public Property BtnSave As Object
        Get
            Return _BtnSave
        End Get
        Set(value As Object)
            _BtnSave = value
        End Set
    End Property

    Public Property BtnEliminar As Object
        Get
            Return _BtnEliminar
        End Get
        Set(value As Object)
            _BtnEliminar = value
        End Set
    End Property

    Public Property BtnUpdate As Object
        Get
            Return _BtnUpdate
        End Get
        Set(value As Object)
            _BtnUpdate = value
        End Set
    End Property
#End Region
#End Region
#Region "ICommand"
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Select Case parameter
            Case "New"
                MsgBox("Hola")
            Case "Update"
                MsgBox("Hola2")
            Case Else

        End Select
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region
#Region "INotifyPropertyChanged"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotificarCambio(ByVal parameter As String, ByVal e As PropertyChangedEventHandler)

    End Sub
#End Region
End Class
