Namespace Common
    Public Class DelegateCommand : Implements ICommand

        Private _execute As Action
        Private _canExecute As Func(Of Boolean)

        Public Sub New(ByVal execute As Action)
            Me.New(execute, Function() True)
        End Sub

        Public Sub New(ByVal execute As Action, ByVal canExecute As Func(Of Boolean))
            If execute Is Nothing Then
                Throw New ArgumentNullException("execute")
            End If
            If canExecute Is Nothing Then
                Throw New ArgumentNullException("canExecute")
            End If
            Me._execute = execute
            Me._canExecute = canExecute
        End Sub

        Public Sub Execute()
            Me._execute()
        End Sub

        Public Function CanExecute() As Boolean
            Return Me._canExecute()
        End Function

        Private _CanExecuteChanged As EventHandler
        Public Custom Event CanExecuteChanged As EventHandler _
                                    Implements ICommand.CanExecuteChanged
            AddHandler(ByVal value As EventHandler)
                Me._CanExecuteChanged = _
                     CType(System.Delegate.Combine(Me._CanExecuteChanged, value), EventHandler)
                AddHandler CommandManager.RequerySuggested, Me._CanExecuteChanged
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
                Me._CanExecuteChanged = _
                     CType(System.Delegate.Remove(Me._CanExecuteChanged, value), EventHandler)
                RemoveHandler CommandManager.RequerySuggested, Me._CanExecuteChanged
            End RemoveHandler
            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
                If (Not Me._CanExecuteChanged Is Nothing) Then
                    Me._CanExecuteChanged(sender, e)
                End If
            End RaiseEvent
        End Event
        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
            Me.Execute()
        End Sub

        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return Me.CanExecute
        End Function
    End Class
End Namespace