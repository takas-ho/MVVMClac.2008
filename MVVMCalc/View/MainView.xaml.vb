Imports MVVMCalc.ViewModel

Namespace View
    Class MainView
        Public Sub New()

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            '' InitializeComponent() 呼び出しの後で初期化を追加します。
            'Me.DataContext = New MainViewModel
        End Sub
    End Class
End Namespace