Imports System.ComponentModel
Imports FarmaciaAppAuyonDiego.AuyonDiego.FarmaciaApp.Model

Public Class MedicineModelView
    Implements ICommand, IDataErrorInfo, INotifyPropertyChanged

    Private _MedicineName As String
    Private _Description As String
    Private _Telephone As String
    Private _LaboratoryID As Integer

    Private _ListMedicine As ICollection(Of Medicine)
    Private _Element As Medicine
    Private _Model As MedicineModelView

    Private _BtnNew = True
    Private _BtnSave = False
    Private _BtnDelete = True
    Private _BtnUpdate = True

    Private DB As New FarmaciaAppDataContext

#Region "Propiedades"
    Public Property MedicineName As String
        Get
            Return _MedicineName
        End Get
        Set(value As String)
            _MedicineName = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
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

    Public Property LaboratoryID As Integer
        Get
            Return _LaboratoryID
        End Get
        Set(value As Integer)
            _LaboratoryID = value
        End Set
    End Property

    Public Property ListMedicine As ICollection(Of Medicine)
        Get
            If _ListMedicine Is Nothing Then
                '_ListMedicine = (From S As Medicine In DB.Medicines Select S).ToList
            End If
            Return _ListMedicine
        End Get
        Set(value As ICollection(Of Medicine))
            _ListMedicine = value
        End Set
    End Property

    Public Property Element As Medicine
        Get
            Return _Element
        End Get
        Set(value As Medicine)
            _Element = value
        End Set
    End Property

    Public Property Model As MedicineModelView
        Get
            If _Model Is Nothing Then
                _Model = Me
            End If
            Return _Model
        End Get
        Set(value As MedicineModelView)
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

    Public Property BtnDelete As Object
        Get
            Return _BtnDelete
        End Get
        Set(value As Object)
            _BtnDelete = value
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
                Dim Registro As New Medicine
                Registro.Description = Description
                Registro.LaboratoryID = LaboratoryID
                Registro.MedicineName = MedicineName
                DB.Medicines.Add(Registro)
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
