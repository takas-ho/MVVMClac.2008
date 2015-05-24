Imports MVVMCalc.Model
Imports MVVMCalc.Common

Namespace ViewModel
    Public Class CalculateTypeViewModel : Inherits ViewModelBase

        Private Shared typeLabelMap As Dictionary(Of CalculateType, String)
        Shared Sub New()
            typeLabelMap = New Dictionary(Of CalculateType, String)
            typeLabelMap.Add(Model.CalculateType.None, "未選択")
            typeLabelMap.Add(Model.CalculateType.Add, "足し算")
            typeLabelMap.Add(Model.CalculateType.Sub, "引き算")
            typeLabelMap.Add(Model.CalculateType.Mul, "掛け算")
            typeLabelMap.Add(Model.CalculateType.Div, "割り算")
        End Sub

        Public Shared Function Create(ByVal type As CalculateType) As CalculateTypeViewModel
            Return New CalculateTypeViewModel(type, typeLabelMap(type))
        End Function

        Public Shared Function Create() As IEnumerable(Of CalculateTypeViewModel)
            Return (From e As CalculateType In [Enum].GetValues(GetType(CalculateType)).Cast(Of CalculateType)() Select Create(e))
        End Function

        Private _CalculateType As CalculateType
        Public ReadOnly Property CalculateType() As CalculateType
            Get
                Return _CalculateType
            End Get
        End Property

        Private _Label As String
        Public ReadOnly Property Label() As String
            Get
                Return _Label
            End Get
        End Property

        Public Sub New(ByVal calculateType As CalculateType, ByVal label As String)
            Me._CalculateType = calculateType
            Me._Label = label
        End Sub


    End Class
End Namespace