Public Class OfficeAssignmentView
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.DataContext = New OfficeAssignmentModelView

    End Sub
End Class
