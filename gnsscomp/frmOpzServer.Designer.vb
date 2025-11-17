<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpzServer
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpzServer))
        Me.lblContaStaz1 = New System.Windows.Forms.Label()
        Me.btnFineServer = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblContaStaz1
        '
        Me.lblContaStaz1.AutoSize = True
        Me.lblContaStaz1.Location = New System.Drawing.Point(-24, 319)
        Me.lblContaStaz1.Name = "lblContaStaz1"
        Me.lblContaStaz1.Size = New System.Drawing.Size(20, 20)
        Me.lblContaStaz1.TabIndex = 59
        Me.lblContaStaz1.Text = "1."
        '
        'btnFineServer
        '
        Me.btnFineServer.Location = New System.Drawing.Point(793, 67)
        Me.btnFineServer.Name = "btnFineServer"
        Me.btnFineServer.Size = New System.Drawing.Size(111, 44)
        Me.btnFineServer.TabIndex = 65
        Me.btnFineServer.Text = "Fine"
        Me.btnFineServer.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(366, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 25)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Nome Utente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(187, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 25)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Indirizzo IP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(58, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 25)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Server FTP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(660, 60)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(370, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(210, 23)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Opzioni 3 - Server FTP "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(544, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 25)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Password"
        '
        'frmOpzServer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(932, 403)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblContaStaz1)
        Me.Controls.Add(Me.btnFineServer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmOpzServer"
        Me.Text = "frmOpzServer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblContaStaz1 As Label
    Friend WithEvents txtUtente1 As TextBox
    Friend WithEvents btnFineServer As Button
    Friend WithEvents txtIP1 As TextBox
    Friend WithEvents txtSrvFTP1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents txtPassword1 As TextBox
    Friend WithEvents Label7 As Label
End Class
