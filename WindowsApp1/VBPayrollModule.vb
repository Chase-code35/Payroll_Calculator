' ******************************************
' Chase Owens
' Final
' 8/17/21
' Module for Payroll Program
' ******************************************

Module VBPayrollModule

    Function CalcFICA(ByVal GrossPay As Double, ByVal PreviousYTD As Double) As Double

        ' create local variables
        Dim FICA As Double
        Dim SSTax As Double = 0
        Dim PercentOfGrossPay As Double

        ' if previous ytd is less than or equal to 125,000 then it is taxed if it is greater then it is not taxed
        If PreviousYTD <= 125000 Then
            SSTax += PreviousYTD * 0.062
        Else
            SSTax = SSTax
        End If

        ' getting the 1.45% from the gross pay
        PercentOfGrossPay = GrossPay * 0.0145

        ' adding those two together 
        FICA = PercentOfGrossPay + SSTax

        ' returing FICA
        Return FICA

    End Function

    Function CalcFedTax(ByVal GrossPay As Double) As Double

        ' create local variables
        Dim FedTax As Double

        ' determine federal tax using the gross pay 
        If GrossPay <= 50 Then
            FedTax = 0
        ElseIf GrossPay <= 500 Then
            FedTax = GrossPay * 0.1
        ElseIf GrossPay <= 2500 Then
            FedTax = 45 + GrossPay * 0.15
        ElseIf GrossPay <= 5000 Then
            FedTax = 345 + GrossPay * 0.2
        Else
            FedTax = 845 + GrossPay * 0.25
        End If

        Return FedTax

    End Function

    Function CalcNetPay(ByVal GrossPay As Double, ByVal FICA As Double, ByVal StateTax As Double, ByVal FedTax As Double) As Double

        ' create local variables
        Dim NetPay As Double

        ' calculate the net pay
        NetPay = GrossPay - FICA - StateTax - FedTax

        ' return net pay
        Return NetPay

    End Function

End Module
