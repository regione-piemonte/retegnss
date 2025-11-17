<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAvanzate
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAvanzate))
        Me.btnFineAvanz = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPathFix = New System.Windows.Forms.TextBox()
        Me.txtIPFix = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkEmail = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtSMTP = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblAstr = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsogEN = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtsogQ = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnFineAvanz
        '
        Me.btnFineAvanz.Location = New System.Drawing.Point(787, 681)
        Me.btnFineAvanz.Name = "btnFineAvanz"
        Me.btnFineAvanz.Size = New System.Drawing.Size(111, 40)
        Me.btnFineAvanz.TabIndex = 74
        Me.btnFineAvanz.Text = "Fine"
        Me.btnFineAvanz.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(871, 60)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(395, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 23)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Opzioni Avanzate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Coordinate di vincolo"
        '
        'txtPathFix
        '
        Me.txtPathFix.Location = New System.Drawing.Point(224, 206)
        Me.txtPathFix.Name = "txtPathFix"
        Me.txtPathFix.Size = New System.Drawing.Size(505, 27)
        Me.txtPathFix.TabIndex = 77
        Me.txtPathFix.Text = "/EUREF/products/WWWW/EUR0OPSSNX_YYYYDDD0000_07D_07D_SOL.SNX.gz"
        '
        'txtIPFix
        '
        Me.txtIPFix.Location = New System.Drawing.Point(12, 206)
        Me.txtIPFix.Name = "txtIPFix"
        Me.txtIPFix.Size = New System.Drawing.Size(153, 27)
        Me.txtIPFix.TabIndex = 76
        Me.txtIPFix.Text = "igs-ftp.bkg.bund.de"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 615)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(886, 20)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Se vuoi ricevere una notifica via e-mail al termine del processo di calcolo, inse" &
    "risci il server SMTP e la casella postale di destinazione." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(12, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 17)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "IP"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(224, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 17)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Directory remota"
        '
        'chkEmail
        '
        Me.chkEmail.AutoSize = True
        Me.chkEmail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEmail.Font = New System.Drawing.Font("Segoe UI", 10.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.chkEmail.Location = New System.Drawing.Point(12, 583)
        Me.chkEmail.Name = "chkEmail"
        Me.chkEmail.Size = New System.Drawing.Size(214, 29)
        Me.chkEmail.TabIndex = 82
        Me.chkEmail.Text = "Attiva notifica E-mail"
        Me.chkEmail.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(224, 647)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 17)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Indirizzo E-mail"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(12, 647)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Server SMTP"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Location = New System.Drawing.Point(224, 667)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(166, 27)
        Me.txtEmail.TabIndex = 84
        '
        'txtSMTP
        '
        Me.txtSMTP.Enabled = False
        Me.txtSMTP.Location = New System.Drawing.Point(12, 667)
        Me.txtSMTP.Name = "txtSMTP"
        Me.txtSMTP.Size = New System.Drawing.Size(153, 27)
        Me.txtSMTP.TabIndex = 83
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(13, 438)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 25)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Dati astronomici"
        '
        'lblAstr
        '
        Me.lblAstr.AutoSize = True
        Me.lblAstr.Location = New System.Drawing.Point(13, 474)
        Me.lblAstr.Name = "lblAstr"
        Me.lblAstr.Size = New System.Drawing.Size(766, 100)
        Me.lblAstr.TabIndex = 87
        Me.lblAstr.Text = resources.GetString("lblAstr.Text")
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "7z.exe"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(344, 174)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(200, 20)
        Me.Label10.TabIndex = 89
        Me.Label10.Text = "(NB: Usa i caratteri speciali)"
        '
        'txtsogEN
        '
        Me.txtsogEN.Location = New System.Drawing.Point(127, 334)
        Me.txtsogEN.Name = "txtsogEN"
        Me.txtsogEN.Size = New System.Drawing.Size(38, 27)
        Me.txtsogEN.TabIndex = 92
        Me.txtsogEN.Text = "2.0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(12, 264)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(178, 25)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "Soglia di ripetibilità"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 300)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(809, 20)
        Me.Label12.TabIndex = 90
        Me.Label12.Text = "Indicare nelle seguenti caselle le soglie di ripetibilità (settimanale) massima p" &
    "er considerare valide le coordinate stimate." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label13.Location = New System.Drawing.Point(12, 344)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 17)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Est/Nord [mm]"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label14.Location = New System.Drawing.Point(12, 387)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 17)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Quota [mm]"
        '
        'txtsogQ
        '
        Me.txtsogQ.Location = New System.Drawing.Point(127, 377)
        Me.txtsogQ.Name = "txtsogQ"
        Me.txtsogQ.Size = New System.Drawing.Size(38, 27)
        Me.txtsogQ.TabIndex = 95
        Me.txtsogQ.Text = "5.0"
        '
        'frmAvanzate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(932, 453)
        Me.Controls.Add(Me.txtsogQ)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtsogEN)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblAstr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtSMTP)
        Me.Controls.Add(Me.chkEmail)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPathFix)
        Me.Controls.Add(Me.txtIPFix)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFineAvanz)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmAvanzate"
        Me.Text = "frmAvanzate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFineAvanz As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPathFix As TextBox
    Friend WithEvents txtIPFix As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents chkEmail As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtSMTP As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblAstr As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label10 As Label
    Friend WithEvents txtsogEN As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtsogQ As TextBox
End Class
