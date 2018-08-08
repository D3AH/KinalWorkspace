Imports System.ComponentModel
Imports EmetraApp2014277

Public Class MainWindowModelView
    Implements INotifyPropertyChanged, ICommand

#Region "Campos"
    Private _Model As MainWindowModelView
#End Region

#Region "Propiedades"
    Public Property Model As MainWindowModelView
        Get
            Return _Model
        End Get
        Set(value As MainWindowModelView)
            _Model = value
            NotificarCambio("Model")
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        Model = Me
    End Sub
#End Region

#Region "INotify"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotificarCambio(ByVal Propiedad As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(Propiedad))
    End Sub
#End Region
#Region "ICommand"
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parametro As Object) Implements ICommand.Execute
        'Select Case here pls
        If parametro.Equals("neighbor") Then
            Dim x As New NeighborView
            x.Show()
        End If
    End Sub

    Public Function CanExecute(parametro As Object) As Boolean Implements ICommand.CanExecute
        Return True
    End Function
#End Region
End Class
