Class MainWindow
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DataContext = New MainWindowModelView

    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim x As New NeighborView
        x.Show()
    End Sub

    Private Sub button_Copy_Click(sender As Object, e As RoutedEventArgs) Handles button_Copy.Click
        Dim x As New VehicleView
        x.Show()
    End Sub

    Private Sub button_Copy1_Click(sender As Object, e As RoutedEventArgs) Handles button_Copy1.Click
        Dim x As New RemissionView
        x.Show()
    End Sub
End Class
