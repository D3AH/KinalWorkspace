﻿Public Class NeighborView
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DataContext = New NeighborModelView
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles buttonMenu.Click
        Me.Close()
    End Sub
End Class
