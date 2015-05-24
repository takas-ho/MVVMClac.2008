Namespace Model
    Public Class Calculator

        Private Shared ReadOnly calcMap As Dictionary(Of CalculateType, Func(Of Double, Double, Double))

        Shared Sub New()
            calcMap = New Dictionary(Of CalculateType, Func(Of Double, Double, Double))
            calcMap.Add(CalculateType.None, AddressOf CalcNone)
            calcMap.Add(CalculateType.Add, AddressOf CalcAdd)
            calcMap.Add(CalculateType.Sub, AddressOf CalcSub)
            calcMap.Add(CalculateType.Mul, AddressOf CalcMul)
            calcMap.Add(CalculateType.Div, AddressOf CalcDiv)
        End Sub

        Private Shared Function CalcNone(ByVal x As Double, ByVal y As Double) As Double
            Throw New InvalidOperationException
        End Function

        Private Shared Function CalcAdd(ByVal x As Double, ByVal y As Double) As Double
            Return x + y
        End Function

        Private Shared Function CalcSub(ByVal x As Double, ByVal y As Double) As Double
            Return x - y
        End Function

        Private Shared Function CalcMul(ByVal x As Double, ByVal y As Double) As Double
            Return x * y
        End Function

        Private Shared Function CalcDiv(ByVal x As Double, ByVal y As Double) As Double
            Return x / y
        End Function

        Public Function Execute(ByVal x As Double, ByVal y As Double, ByVal op As CalculateType) As Double
            Return calcMap(op)(x, y)
        End Function

    End Class
End Namespace