Imports System.ComponentModel
Imports FarmaciaAppAuyonDiego.AuyonDiego.FarmaciaApp.Model

Public Class MedicineModelView
    Implements ICommand, IDataErrorInfo, INotifyPropertyChanged

    Private _MedicineName As String
    Private _Description As String
    Private _Telephone As String
    Private _LaboratoryID As Integer

    Private _ListMedicine As ICollection(Of Medicine)
    Private _ListLaboratory As ICollection(Of Laboratory)
    Private _Element As Medicine
    Private _Model As MedicineModelView
    Private _Laboratory As Laboratory

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
            NotificarCambio("MedicineName")
        End Set
    End Property

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
            NotificarCambio("Description")
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

    Public Property LaboratoryID As Integer
        Get
            Return _LaboratoryID
        End Get
        Set(value As Integer)
            _LaboratoryID = value
            NotificarCambio("LaboratoryID")
        End Set
    End Property

    Public Property ListMedicine As ICollection(Of Medicine)
        Get
            If _ListMedicine Is Nothing Then
                _ListMedicine = (From S As Medicine In DB.Medicines Select S).ToList
            End If
            Return _ListMedicine
        End Get
        Set(value As ICollection(Of Medicine))
            _ListMedicine = value
            NotificarCambio("ListMedicine")
        End Set
    End Property

    Public Property ListLaboratory As ICollection(Of Laboratory)
        Get
            If _ListLaboratory Is Nothing Then
                _ListLaboratory = (From S As Laboratory In DB.Laboratories Select S).ToList
            End If
            Return _ListLaboratory
        End Get
        Set(value As ICollection(Of Laboratory))
            _ListLaboratory = value
            NotificarCambio("ListLaboratory")
        End Set
    End Property

    Public Property Element As Medicine
        Get
            Return _Element
        End Get
        Set(value As Medicine)
            _Element = value
            NotificarCambio("Element")
            If Element IsNot Nothing Then
                Description = Element.Description
                Laboratory = Element.Laboratory
                MedicineName = Element.MedicineName
            End If
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

    Public Property Laboratory As Laboratory
        Get
            Return _Laboratory
        End Get
        Set(value As Laboratory)
            _Laboratory = value
            NotificarCambio("Laboratory")
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
                Dim Registro As New Medicine
                Registro.Description = Description
                Registro.LaboratoryID = Laboratory.LaboratoryID
                Registro.MedicineName = MedicineName
                DB.Medicines.Add(Registro)
                DB.SaveChanges()
                BtnNew = True
                BtnSave = False
                BtnDelete = True
                BtnUpdate = True
                MsgBox("Registro agregado exitosamente")
                Me.ListMedicine = (From N In DB.Medicines Select N).ToList
            Case "Update"
                If Element IsNot Nothing Then
                    Element.Description = Description
                    Element.LaboratoryID = Laboratory.LaboratoryID
                    Element.MedicineName = MedicineName
                    DB.Entry(Element).State = Data.Entity.EntityState.Modified
                    DB.SaveChanges()
                    MsgBox("Registro Actualizado", MsgBoxStyle.Information)
                    Me.ListMedicine = (From N In DB.Medicines Select N).ToList
                Else
                    MsgBox("Debe seleccionar un elemento")
                End If
            Case "Delete"
                If Element IsNot Nothing Then
                    Try
                        DB.Medicines.Remove(Element)
                        DB.SaveChanges()
                        MsgBox("Registro eliminado", MsgBoxStyle.Information)
                    Catch ex As Exception
                        MsgBox("No puedes eliminar este registro!")
                    End Try
                    Me.ListMedicine = (From N In DB.Medicines Select N).ToList
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
