Imports System.ComponentModel
Imports FarmaciaAppAuyonDiego.AuyonDiego.FarmaciaApp.Model

Public Class SalesModelView
    Implements ICommand, IDataErrorInfo, INotifyPropertyChanged

    Private _SalesDate As Date = Date.Now
    Private _Price As Decimal
    Private _Amount As Decimal
    Private _Telephone As String
    Private _MedicineID As Integer

    Private _ListSales As ICollection(Of Sales)
    Private _ListMedicine As ICollection(Of Medicine)
    Private _Element As Sales
    Private _Model As SalesModelView
    Private _Medicine As Medicine

    Private _BtnNew = True
    Private _BtnSave = False
    Private _BtnDelete = True
    Private _BtnUpdate = True

    Private DB As New FarmaciaAppDataContext

#Region "Propiedades"
    Public Property SalesDate As Date
        Get
            Return _SalesDate
        End Get
        Set(value As Date)
            _SalesDate = value
            NotificarCambio("SalesDate")
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return _Price
        End Get
        Set(value As Decimal)
            _Price = value
            NotificarCambio("Price")
        End Set
    End Property

    Public Property Amount As Decimal
        Get
            Return _Amount
        End Get
        Set(value As Decimal)
            _Amount = value
            NotificarCambio("Amount")
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

    Public Property MedicineID As Integer
        Get
            Return _MedicineID
        End Get
        Set(value As Integer)
            _MedicineID = value
            NotificarCambio("MedicineID")
        End Set
    End Property

    Public Property ListSales As ICollection(Of Sales)
        Get
            If _ListSales Is Nothing Then
                _ListSales = (From S As Sales In DB.Sales Select S).ToList
            End If
            Return _ListSales
        End Get
        Set(value As ICollection(Of Sales))
            _ListSales = value
            NotificarCambio("ListSales")
        End Set
    End Property

    Public Property Element As Sales
        Get
            Return _Element
        End Get
        Set(value As Sales)
            _Element = value
            NotificarCambio("Element")
            If Element IsNot Nothing Then
                SalesDate = Element.SalesDate
                Price = Element.Price
                Amount = Element.Amount
                Telephone = Element.Telephone
                MedicineID = Element.MedicineID
            End If
        End Set
    End Property

    Public Property Model As SalesModelView
        Get
            If _Model Is Nothing Then
                _Model = Me
            End If
            Return _Model
        End Get
        Set(value As SalesModelView)
            _Model = value
            NotificarCambio("Model")
        End Set
    End Property

    Public Property ListMedicine As ICollection(Of Medicine)
        Get
            If _ListMedicine Is Nothing Then
                _ListMedicine = (From N In DB.Medicines Select N).ToList
            End If
            Return _ListMedicine
        End Get
        Set(value As ICollection(Of Medicine))
            _ListMedicine = value
            NotificarCambio("ListMedicine")
        End Set
    End Property

    Public Property Medicine As Medicine
        Get
            Return _Medicine
        End Get
        Set(value As Medicine)
            _Medicine = value
            NotificarCambio("Medicine")
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
                Dim Registro As New Sales
                Registro.Amount = Amount
                Registro.MedicineID = Medicine.MedicineID
                Registro.Price = Price
                Registro.Telephone = Telephone
                Registro.SalesDate = SalesDate
                DB.Sales.Add(Registro)
                DB.SaveChanges()
                BtnNew = True
                BtnSave = False
                BtnDelete = True
                BtnUpdate = True
                MsgBox("Registro agregado exitosamente")
                Me.ListSales = (From N In DB.Sales Select N).ToList
            Case "Update"
                If Element IsNot Nothing Then
                    Element.Amount = Amount
                    Element.MedicineID = Medicine.MedicineID
                    Element.Price = Price
                    Element.Telephone = Telephone
                    Element.SalesDate = SalesDate
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListSales = (From N In DB.Sales Select N).ToList
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Delete"
                If Element IsNot Nothing Then
                    Try
                        DB.Sales.Remove(Element)
                        DB.SaveChanges()
                        MsgBox("Registro eliminado", MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox("No puedes eliminar este registro!")
                    End Try
                    Me.ListSales = (From N In DB.Sales Select N).ToList
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
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
