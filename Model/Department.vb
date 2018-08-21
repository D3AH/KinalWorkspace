Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Namespace DiegoAuyon.CETKinal2014277.Model

    Public Class Department
#Region "Campos"
        Private _DepartmentID As Integer
        Private _Name As String
        Private _Budget As Decimal
        Private _StartDate As DateTime
        Private _Administrator As Integer
#End Region
#Region "Propiedades"
        <Key>
        Public Property DepartmentID As Integer
            Get
                Return _DepartmentID
            End Get
            Set(value As Integer)
                _DepartmentID = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property

        Public Property Budget As Decimal
            Get
                Return _Budget
            End Get
            Set(value As Decimal)
                _Budget = value
            End Set
        End Property

        Public Property StartDate As Date
            Get
                Return _StartDate
            End Get
            Set(value As Date)
                _StartDate = value
            End Set
        End Property

        Public Property Administrator As Integer
            Get
                Return _Administrator
            End Get
            Set(value As Integer)
                _Administrator = value
            End Set
        End Property
#End Region
    End Class

End Namespace