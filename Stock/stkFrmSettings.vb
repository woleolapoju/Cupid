Imports System.Data.SqlClient
Public Class stkFrmSettings

    Private Sub FrmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo handler

        lblHeader.BackColor = HeaderTheme
        Me.BackColor = MainTheme

        cmdOk.Enabled = ModuleAdd
        cboTransType.SelectedIndex = 0
        cPOS.Items.Add("WinPrn")
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cPOS.Items.Add(sp)
            cPole.Items.Add(sp)
        Next

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand
        Dim drSQL As SqlDataReader

        'cnSQL.Open()

        cmSQL.CommandText = "FetchAllSystemParameters"
        cmSQL.CommandType = CommandType.StoredProcedure
        drSQL = cmSQL.ExecuteReader()
        If drSQL.HasRows = False Then
            MsgBox("Invalid System Parameter", MsgBoxStyle.Information, strApptitle)
            End
        Else
            If drSQL.Read Then

                tVat.Text = IIf(IsDBNull(drSQL.Item("Vat")), 0, drSQL.Item("Vat"))
                tDiscount.Text = IIf(IsDBNull(drSQL.Item("Discount")), 0, drSQL.Item("Discount"))

                cPOS.Text = drSQL.Item("POSPrinter")
                cPole.Text = drSQL.Item("POSPole")
                chkPrint.Checked = drSQL.Item("PrintInvoice")
                cInvoiceType.Text = drSQL.Item("InvoiceType")
                txtDebitNote.Text = drSQL.Item("DebitNoticeBody")
                chkStoreAssignment.Checked = drSQL.Item("IgnoreStoreAssignment")
                cboTransType.Text = drSQL.Item("TransType")
                cSalesInputLayout.Text = drSQL.Item("SalesInputLayout")
                On Error Resume Next
                tDateDurationValidation.Text = Val(ChkNull(drSQL.Item("DateDurationValidation")))
                On Error GoTo handler

            End If
        End If
        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        drSQL.Close()
        'cnSQL.Close()
        'cnSQL.Dispose()


        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo handler

        'Dim cnSQL As SqlConnection = New SqlConnection(strConnect)
        Dim cmSQL As SqlCommand = cnSQL.CreateCommand

        'cnSQL.Open()

        cmSQL.CommandText = "UpdateSysParam4Settings"
        cmSQL.CommandType = CommandType.StoredProcedure


        cmSQL.Parameters.AddWithValue("@DebitNoticeBody", txtDebitNote.Text)
        cmSQL.Parameters.AddWithValue("@POSPole", cPole.Text)
        cmSQL.Parameters.AddWithValue("@POSPrinter", cPOS.Text)
        cmSQL.Parameters.AddWithValue("@Vat", Val(tVat.Text))
        cmSQL.Parameters.AddWithValue("@Discount", Val(tDiscount.Text))

        cmSQL.Parameters.AddWithValue("@PrintInvoice", chkPrint.Checked)
        cmSQL.Parameters.AddWithValue("@InvoiceType", cInvoiceType.Text)
        cmSQL.Parameters.AddWithValue("@IgnoreStoreAssignment", chkStoreAssignment.Checked)
        cmSQL.Parameters.AddWithValue("@TransType", cboTransType.Text)
        cmSQL.Parameters.AddWithValue("@SalesInputLayout", cSalesInputLayout.Text)
        cmSQL.Parameters.AddWithValue("@DateDurationValidation", tDateDurationValidation.Text)

        cmSQL.ExecuteNonQuery()

        'cmSQL.Connection.Close()
        cmSQL.Dispose()
        'cnSQL.Close()
        'cnSQL.Dispose()

        InitialiseEntireSystem()

        Me.Close()


        Exit Sub
        Resume
handler:
        MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


    Private Sub chkPrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrint.CheckedChanged
        Pan.Visible = chkPrint.Checked
    End Sub

    Private Sub txtDebitNote_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDebitNote.Enter
        Dim childform As New stkFrmText
        childform.frmParent = txtDebitNote
        childform.txt.Text = txtDebitNote.Text
        childform.Text = "Debit Note Text"
        childform.ShowDialog()
    End Sub

End Class