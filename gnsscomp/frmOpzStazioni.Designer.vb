<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOpzStazioni
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpzStazioni))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnStazMeno = New System.Windows.Forms.Button()
        Me.btnStazPiu = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAvantiStazioni = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblContaStaz1 = New System.Windows.Forms.Label()
        Me.chkGra1 = New System.Windows.Forms.CheckBox()
        Me.txtRemPath1 = New System.Windows.Forms.TextBox()
        Me.txtStaz1 = New System.Windows.Forms.TextBox()
        Me.txtSrvFTP1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(770, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 20)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Aggiungi/ Rimuovi"
        '
        'btnStazMeno
        '
        Me.btnStazMeno.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnStazMeno.Location = New System.Drawing.Point(858, 44)
        Me.btnStazMeno.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStazMeno.Name = "btnStazMeno"
        Me.btnStazMeno.Size = New System.Drawing.Size(40, 40)
        Me.btnStazMeno.TabIndex = 36
        Me.btnStazMeno.Text = "-"
        Me.btnStazMeno.UseVisualStyleBackColor = True
        '
        'btnStazPiu
        '
        Me.btnStazPiu.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnStazPiu.Location = New System.Drawing.Point(787, 44)
        Me.btnStazPiu.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStazPiu.Name = "btnStazPiu"
        Me.btnStazPiu.Size = New System.Drawing.Size(40, 40)
        Me.btnStazPiu.TabIndex = 35
        Me.btnStazPiu.Text = "+"
        Me.btnStazPiu.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(636, 80)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = resources.GetString("Label5.Text")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(358, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(233, 23)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Opzioni 2 - Stazioni GNSS"
        '
        'btnAvantiStazioni
        '
        Me.btnAvantiStazioni.Location = New System.Drawing.Point(787, 90)
        Me.btnAvantiStazioni.Name = "btnAvantiStazioni"
        Me.btnAvantiStazioni.Size = New System.Drawing.Size(111, 44)
        Me.btnAvantiStazioni.TabIndex = 49
        Me.btnAvantiStazioni.Text = "Avanti"
        Me.btnAvantiStazioni.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(332, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 20)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "(NB: Usa i caratteri speciali)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(714, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 25)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Grafici"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(332, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 25)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Directory remota"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(178, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 25)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Stazione GNSS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(58, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 25)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Server FTP"
        '
        'lblContaStaz1
        '
        Me.lblContaStaz1.AutoSize = True
        Me.lblContaStaz1.Location = New System.Drawing.Point(26, 219)
        Me.lblContaStaz1.Name = "lblContaStaz1"
        Me.lblContaStaz1.Size = New System.Drawing.Size(20, 20)
        Me.lblContaStaz1.TabIndex = 43
        Me.lblContaStaz1.Text = "1."
        '
        'chkGra1
        '
        Me.chkGra1.AutoSize = True
        Me.chkGra1.Location = New System.Drawing.Point(749, 220)
        Me.chkGra1.Name = "chkGra1"
        Me.chkGra1.Size = New System.Drawing.Size(18, 17)
        Me.chkGra1.TabIndex = 42
        Me.chkGra1.UseVisualStyleBackColor = True
        '
        'txtRemPath1
        '
        Me.txtRemPath1.Location = New System.Drawing.Point(332, 214)
        Me.txtRemPath1.Name = "txtRemPath1"
        Me.txtRemPath1.Size = New System.Drawing.Size(360, 27)
        Me.txtRemPath1.TabIndex = 41
        '
        'txtStaz1
        '
        Me.txtStaz1.Location = New System.Drawing.Point(178, 214)
        Me.txtStaz1.Name = "txtStaz1"
        Me.txtStaz1.Size = New System.Drawing.Size(138, 27)
        Me.txtStaz1.TabIndex = 40
        '
        'txtSrvFTP1
        '
        Me.txtSrvFTP1.Location = New System.Drawing.Point(58, 214)
        Me.txtSrvFTP1.Name = "txtSrvFTP1"
        Me.txtSrvFTP1.Size = New System.Drawing.Size(100, 27)
        Me.txtSrvFTP1.TabIndex = 39
        '
        'frmOpzStazioni
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(932, 403)
        Me.Controls.Add(Me.lblContaStaz1)
        Me.Controls.Add(Me.chkGra1)
        Me.Controls.Add(Me.txtRemPath1)
        Me.Controls.Add(Me.btnAvantiStazioni)
        Me.Controls.Add(Me.txtStaz1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSrvFTP1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnStazMeno)
        Me.Controls.Add(Me.btnStazPiu)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmOpzStazioni"
        Me.Text = "Opzioni - Stazioni"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label8 As Label
    Friend WithEvents btnStazMeno As Button
    Friend WithEvents btnStazPiu As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAvantiStazioni As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblContaStaz1 As Label
    Friend WithEvents chkGra1 As CheckBox
    Friend WithEvents txtRemPath1 As TextBox
    Friend WithEvents txtStaz1 As TextBox
    Friend WithEvents txtSrvFTP1 As TextBox
End Class
