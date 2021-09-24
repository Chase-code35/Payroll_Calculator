' ******************************************
' Chase Owens
' Final
' 8/17/21
' Main Menu Form for Payroll Program
' ******************************************

Public Class frmMain
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' closes the program
        Close()

    End Sub

    Private Sub btnHourly_Click(sender As Object, e As EventArgs) Handles btnHourly.Click

        ' create new instance of frmHourly
        Dim Hourly As New frmHourly

        ' show the form modally
        Hourly.ShowDialog()

    End Sub

    Private Sub btnSalary_Click(sender As Object, e As EventArgs) Handles btnSalary.Click

        ' create new instance of frmHourly
        Dim Salary As New frmSalary

        ' show the form modally
        Salary.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        ' call the exit button subroutine
        btnExit_Click(sender, e)

    End Sub
End Class