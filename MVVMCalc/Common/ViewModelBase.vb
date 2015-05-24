Imports System.ComponentModel

Namespace Common
    Public Class ViewModelBase : Implements INotifyPropertyChanged

        ''' <summary>プロパティの変更があったときに発行されます。 </summary>
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        ''' <summary>
        ''' PropertyChangedイベントを発行します。 
        ''' </summary>
        ''' <param name="propertyName">プロパティ名</param>
        ''' <remarks></remarks>
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
            'If Me.PropertyChanged IsNot Nothing Then
            '    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
            'End If
        End Sub

    End Class
End Namespace