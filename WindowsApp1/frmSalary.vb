' ******************************************
' Chase Owens
' Final
' 8/17/21
' Salary Form for Payroll Program
' ******************************************

Public Class frmSalary
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' closes the program
        Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ' clears inputs and outputs
        txtFirstName.ResetText()
        txtLastName.ResetText()
        txtYearlySalary.ResetText()
        txtPreviousYTD.ResetText()

        lstOutput.Items.Clear()

        ' resets the radio buttons back to a specific selection
        radOhio.Checked = True
        radKentucky.Checked = False
        radIndiana.Checked = False

        ' changes background color back to white
        txtFirstName.BackColor = Color.White
        txtLastName.BackColor = Color.White
        txtYearlySalary.BackColor = Color.White
        txtPreviousYTD.BackColor = Color.White

        ' set focus to first name txt box
        txtFirstName.Focus()

    End Sub

    Private Sub btnCal_Click(sender As Object, e As EventArgs) Handles btnCal.Click

        ' Needed variables
        Dim strFirstName As String
        Dim strLastName As String
        Dim dblYearlySalary As Double
        Dim dblGrossPay As Double
        Dim dblPreviousYTD As Double
        Dim dblFICA As Double
        Dim dblStateTax As Double
        Dim dblFedTax As Double
        Dim dblNetPay As Double

        ' changes background color back to white
        txtFirstName.BackColor = Color.White
        txtLastName.BackColor = Color.White
        txtYearlySalary.BackColor = Color.White
        txtPreviousYTD.BackColor = Color.White

        If ValidInput(strFirstName, strLastName, dblYearlySalary, dblPreviousYTD) = True Then

            ' calculate the gross pay
            dblGrossPay = CalcGrossPay(dblYearlySalary)

            ' calculate the FICA
            dblFICA = CalcFICA(dblGrossPay, dblPreviousYTD)

            ' calculate the state tax
            dblStateTax = CalcStateTax(dblGrossPay)

            ' calculate the federal tax
            dblFedTax = CalcFedTax(dblGrossPay)

            ' calculate the net pay
            dblNetPay = CalcNetPay(dblGrossPay, dblFICA, dblStateTax, dblFedTax)

            ' call display procedure passing in all values
            Display(dblNetPay, dblFICA, dblStateTax, dblFedTax, dblGrossPay)

        End If

    End Sub

    Function ValidInput(ByRef FirstName As String, ByRef LastName As String, ByRef YearlySalary As Double, ByRef PreviousYTD As Double) As Boolean

        ' Validate Inputs
        If ValidateFirstName(FirstName) = True Then
            If ValidateLastName(LastName) = True Then
                If ValidateYearlySalary(YearlySalary) = True Then
                    If ValidatePreviousYTD(PreviousYTD) Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Function ValidateFirstName(ByRef FirstName As String) As Boolean

        ' validate input and put into a variable
        If txtFirstName.Text = "" Then
            txtFirstName.BackColor = Color.Yellow
            txtFirstName.Focus()
            MessageBox.Show("Please Enter Employees First Name.")
            Return False
        Else
            FirstName = txtFirstName.Text
            Return True
        End If

    End Function

    Function ValidateLastName(ByRef LastName As String) As Boolean

        ' validate input and put into a variable
        If txtLastName.Text = "" Then
            txtLastName.BackColor = Color.Yellow
            txtLastName.Focus()
            MessageBox.Show("Please Enter Employees Last Name.")
            Return False
        Else
            LastName = txtLastName.Text
            Return True
        End If

    End Function

    Function ValidateYearlySalary(ByRef YearlySalary As Double) As Boolean

        ' validating the yearly salary by checking if it is there or not, is numeric and greater than 0.
        If txtYearlySalary.Text = "" Then
            txtYearlySalary.BackColor = Color.Yellow
            txtYearlySalary.Focus()
            MessageBox.Show("Please Enter Yearly Salary.")
            Return False
        Else
            If IsNumeric(txtYearlySalary.Text) Then
                If txtYearlySalary.Text > 0 Then
                    YearlySalary = txtYearlySalary.Text
                    Return True
                Else
                    txtYearlySalary.BackColor = Color.Yellow
                    txtYearlySalary.Focus()
                    MessageBox.Show("Please Enter Numbers Greater than 0.")
                    Return False
                End If
            Else
                txtYearlySalary.BackColor = Color.Yellow
                txtYearlySalary.Focus()
                MessageBox.Show("Please Enter Numbers Only.")
                Return False
            End If
        End If

    End Function

    Function ValidatePreviousYTD(ByRef PreviousYTD As Double) As Boolean

        ' validating the PreviousYTD by checking if it is there or not, is numeric and greater than 0
        If txtPreviousYTD.Text = "" Then
            txtPreviousYTD.BackColor = Color.Yellow
            txtPreviousYTD.Focus()
            MessageBox.Show("Please Enter Previous YTD.")
            Return False
        Else
            If IsNumeric(txtPreviousYTD.Text) Then
                If txtPreviousYTD.Text > 0 Then
                    PreviousYTD = txtPreviousYTD.Text
                    Return True
                Else
                    txtPreviousYTD.BackColor = Color.Yellow
                    txtPreviousYTD.Focus()
                    MessageBox.Show("Please Enter Numbers Greater than 0.")
                    Return False
                End If
            Else
                txtPreviousYTD.BackColor = Color.Yellow
                txtPreviousYTD.Focus()
                MessageBox.Show("Please Enter Numbers Only.")
                Return False
            End If
        End If

    End Function

    Function CalcGrossPay(ByVal YearlySalary As Double) As Double

        ' create a local variable
        Dim GrossPay As Double

        ' creating a constant variable
        ' there are 52 payroll periods in a year
        Const PayrollsPerYear As Integer = 52

        ' the equation to get gross pay, using the variables
        GrossPay = YearlySalary / PayrollsPerYear

        ' returing gross pay
        Return GrossPay

    End Function

    Function CalcStateTax(ByVal GrossPay As Double) As Double

        ' create local variables
        Dim StateTax As Double

        ' calculate the tax
        If radOhio.Checked = True Then
            StateTax = GrossPay * 0.065
        ElseIf radKentucky.Checked = True Then
            StateTax = GrossPay * 0.06
        ElseIf radIndiana.Checked = True Then
            StateTax = GrossPay * 0.055
        End If

        ' return the state tax
        Return StateTax

    End Function

    Private Sub Display(ByVal NetPay As Double, ByVal FICA As Double, ByVal StateTax As Double, ByVal FedTax As Double, ByVal GrossPay As Double)

        'display the amounts formatted with headers and separaters
        lstOutput.Items.Add("Net Pay:    " & vbTab & vbTab & NetPay.ToString("c"))
        lstOutput.Items.Add("")
        lstOutput.Items.Add("FICA:       " & vbTab & vbTab & FICA.ToString("c"))
        lstOutput.Items.Add("")
        lstOutput.Items.Add("State Tax:  " & vbTab & vbTab & StateTax.ToString("c"))
        lstOutput.Items.Add("")
        lstOutput.Items.Add("Federal Tax:" & vbTab & vbTab & FedTax.ToString("c"))
        lstOutput.Items.Add("")
        lstOutput.Items.Add("Gross Pay:  " & vbTab & vbTab & GrossPay.ToString("c"))

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click

        ' call the clear button subroutine
        btnClear_Click(sender, e)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        ' call the exit button subroutine
        btnExit_Click(sender, e)

    End Sub

    Private Sub CalculateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateToolStripMenuItem.Click

        ' call the calculate button subroutine
        btnCal_Click(sender, e)

    End Sub
End Class