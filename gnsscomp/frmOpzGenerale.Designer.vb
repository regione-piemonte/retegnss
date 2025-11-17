<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOpzGenerale
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
        Me.txtNomeCamp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDataInizio = New System.Windows.Forms.TextBox()
        Me.txtDataFine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.btnAvantiGenerale = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtNomeCamp
        '
        Me.txtNomeCamp.Location = New System.Drawing.Point(406, 88)
        Me.txtNomeCamp.Name = "txtNomeCamp"
        Me.txtNomeCamp.Size = New System.Drawing.Size(221, 27)
        Me.txtNomeCamp.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(27, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome della campagna BERNESE"
        '
        'txtDataInizio
        '
        Me.txtDataInizio.Location = New System.Drawing.Point(362, 209)
        Me.txtDataInizio.Name = "txtDataInizio"
        Me.txtDataInizio.Size = New System.Drawing.Size(137, 27)
        Me.txtDataInizio.TabIndex = 1
        '
        'txtDataFine
        '
        Me.txtDataFine.Location = New System.Drawing.Point(527, 209)
        Me.txtDataFine.Name = "txtDataFine"
        Me.txtDataFine.Size = New System.Drawing.Size(137, 27)
        Me.txtDataFine.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(28, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Intervallo temporale"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(381, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Data Inizio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(549, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 25)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Data Fine"
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Location = New System.Drawing.Point(27, 258)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(382, 24)
        Me.chkAuto.TabIndex = 6
        Me.chkAuto.Text = "Attiva selezione automatica dell'intervallo temporale"
        Me.chkAuto.UseVisualStyleBackColor = True
        '
        'btnAvantiGenerale
        '
        Me.btnAvantiGenerale.Location = New System.Drawing.Point(793, 305)
        Me.btnAvantiGenerale.Name = "btnAvantiGenerale"
        Me.btnAvantiGenerale.Size = New System.Drawing.Size(111, 44)
        Me.btnAvantiGenerale.TabIndex = 8
        Me.btnAvantiGenerale.Text = "Avanti"
        Me.btnAvantiGenerale.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(199, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "(es. 05/06/2022, 02/07/2022)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(381, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(187, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Opzioni 1 - Generale"
        '
        'frmOpzGenerale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 453)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnAvantiGenerale)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDataFine)
        Me.Controls.Add(Me.txtDataInizio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNomeCamp)
        Me.Name = "frmOpzGenerale"
        Me.Text = "Opzioni - Generale"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNomeCamp As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDataInizio As TextBox
    Friend WithEvents txtDataFine As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAuto As CheckBox
    Friend WithEvents btnAvantiGenerale As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
