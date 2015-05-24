Imports MVVMCalc.Model
Imports MVVMCalc.Common

Namespace ViewModel
    Public Class MainViewModel : Inherits ViewModelBase

        Private _lhs As Double
        Private _rhs As Double
        Private _answer As Double
        Private _selectedCalculateType As CalculateTypeViewModel
        Private _calculateCommand As DelegateCommand

        Public Sub New()
            Me._CalculateTypes = CalculateTypeViewModel.Create()
            Me._selectedCalculateType = Me.CalculateTypes.First()
        End Sub

        Private _CalculateTypes As IEnumerable(Of CalculateTypeViewModel)
        Public ReadOnly Property CalculateTypes() As IEnumerable(Of CalculateTypeViewModel)
            Get
                Return _CalculateTypes
            End Get
        End Property

        Public Property SelectedCalculateType() As CalculateTypeViewModel
            Get
                Return _selectedCalculateType
            End Get
            Set(ByVal value As CalculateTypeViewModel)
                Me._selectedCalculateType = value
                Me.RaisePropertyChanged("SelectedCalculateType")
            End Set
        End Property

        Public Property Lhs() As Double
            Get
                Return _lhs
            End Get
            Set(ByVal value As Double)
                _lhs = value
                Me.RaisePropertyChanged("Lhs")
            End Set
        End Property

        Public Property Rhs() As Double
            Get
                Return _rhs
            End Get
            Set(ByVal value As Double)
                _rhs = value
                Me.RaisePropertyChanged("Rhs")
            End Set
        End Property

        Public Property Answer() As Double
            Get
                Return _answer
            End Get
            Set(ByVal value As Double)
                _answer = value
                Me.RaisePropertyChanged("Answer")
            End Set
        End Property

        Public ReadOnly Property CalculateCommand() As DelegateCommand
            Get
                If _calculateCommand Is Nothing Then
                    _calculateCommand = New DelegateCommand(AddressOf CalculateExecute, AddressOf CanCalculateExecute)
                End If
                Return _calculateCommand
            End Get
        End Property

        Private Sub CalculateExecute()
            Dim calc As New Calculator
            Answer = calc.Execute(Lhs, Rhs, SelectedCalculateType.CalculateType)
        End Sub

        Private Function CanCalculateExecute() As Boolean
            Return SelectedCalculateType.CalculateType <> CalculateType.None
        End Function

    End Class
End Namespace