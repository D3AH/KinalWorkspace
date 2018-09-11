Imports System.ComponentModel
Imports FarmaciaAppAuyonDiego.AuyonDiego.FarmaciaApp.Model

Public Class LaboratoryModelView
    Implements ICommand, IDataErrorInfo, INotifyPropertyChanged

    Private _LaboratoryName As String
    Private _Address As String
    Private _Telephone As String

    Private _ListLaboratory As ICollection(Of Laboratory)
    Private _Element As Laboratory
    Private _Model As LaboratoryModelView

    Private _BtnNew = True
    Private _BtnSave = False
    Private _BtnDelete = True
    Private _BtnUpdate = True

    Private DB As New FarmaciaAppDataContext

#Region "Propiedades"
    Public Property LaboratoryName As String
        Get
            Return _LaboratoryName
        End Get
        Set(value As String)
            _LaboratoryName = value
            NotificarCambio("LaboratoryName")
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

    Public Property Telephone As String
        Get
            Return _Telephone
        End Get
        Set(value As String)
            _Telephone = value
            NotificarCambio("Telephone")
        End Set
    End Property

    Public Property ListLaboratory As ICollection(Of Laboratory)
        Get
            If _ListLaboratory Is Nothing Then
                '_ListLaboratory = (From S As Laboratory In DB.Laboratories Select S).ToList
            End If
            Return _ListLaboratory
        End Get
        Set(value As ICollection(Of Laboratory))
            _ListLaboratory = value
            NotificarCambio("ListLaboratory")
        End Set
    End Property

    Public Property Element As Laboratory
        Get
            Return _Element
        End Get
        Set(value As Laboratory)
            _Element = value
            NotificarCambio("Element")
        End Set
    End Property

    Public Property Model As LaboratoryModelView
        Get
            If _Model Is Nothing Then
                _Model = Me
            End If
            Return _Model
        End Get
        Set(value As LaboratoryModelView)
            _Model = value
            NotificarCambio("Model")
        End Set
    End Property

    Public Property BtnNew As Object
        Get
            Return _BtnNew
        End Get
        Set(value As Object)
            _BtnNew = value
            NotificarCambio("BtnNew")
        End Set
    End Property

    Public Property BtnSave As Object
        Get
            Return _BtnSave
        End Get
        Set(value As Object)
            _BtnSave = value
            NotificarCambio("BtnSave")
        End Set
    End Property

    Public Property BtnDelete As Object
        Get
            Return _BtnDelete
        End Get
        Set(value As Object)
            _BtnDelete = value
            NotificarCambio("BtnDelete")
        End Set
    End Property

    Public Property BtnUpdate As Object
        Get
            Return _BtnUpdate
        End Get
        Set(value As Object)
            _BtnUpdate = value
            NotificarCambio("BtnUpdate")
        End Set
    End Property
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
#Region "ICommand"
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Select Case parameter
            Case "New"
                BtnNew = False
                BtnSave = True
                BtnDelete = False
                BtnUpdate = False
            Case "Save"
                MsgBox(ListLaboratory)
                Dim Registro As New Laboratory
                Registro.Address = Address
                Registro.LaboratoryName = LaboratoryName
                Registro.Telephone = Telephone
                DB.Laboratories.Add(Registro)
                DB.SaveChanges()
                BtnNew = True
                BtnSave = False
                BtnDelete = True
                BtnUpdate = True
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

    Public Sub NotificarCambio(ByVal parameter As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(parameter))
    End Sub
#End Region
End Class