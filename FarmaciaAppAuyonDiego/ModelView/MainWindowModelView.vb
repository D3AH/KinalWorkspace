Imports System.ComponentModel
Imports FarmaciaAppAuyonDiego

Public Class MainWindowModelView
    Implements IDataErrorInfo, ICommand, INotifyPropertyChanged

    Private _Model As MainWindowModelView

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

    Public Property Model As MainWindowModelView
        Get

            If _Model Is Nothing Then
                _Model = Me
            End If
            Return _Model
        End Get
        Set(value As MainWindowModelView)
            _Model = value
            NotificarCambio("Model")
        End Set
    End Property

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotificarCambio(ByVal parameter As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(parameter))
    End Sub

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Select Case parameter
            Case "Sales"
                Dim SalesWindow As New SalesView
                SalesWindow.ShowDialog()
            Case "Laboratory"
                Dim LaboratoryWindow As New LaboratoryView
                LaboratoryWindow.Show()
            Case "Medicine"
                Dim MedicineWindow As New MedicineView
                MedicineWindow.Show()
            Case "Help"
                Dim HelpWindow As New HelpView
                HelpWindow.Show()
            Case Else
                MsgBox("Operación invalida")
        End Select
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
End Class
