<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRisGrafici
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picVel = New System.Windows.Forms.PictureBox()
        Me.rbtnITRF = New System.Windows.Forms.RadioButton()
        Me.rbtnETRF = New System.Windows.Forms.RadioButton()
        Me.linkVelo = New System.Windows.Forms.LinkLabel()
        Me.cmb_plh = New System.Windows.Forms.ComboBox()
        CType(Me.picVel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(387, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 23)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Risultati 2 - Grafici"
        '
        'picVel
        '
        Me.picVel.Location = New System.Drawing.Point(217, 108)
        Me.picVel.Name = "picVel"
        Me.picVel.Size = New System.Drawing.Size(660, 540)
        Me.picVel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picVel.TabIndex = 30
        Me.picVel.TabStop = False
        '
        'rbtnITRF
        '
        Me.rbtnITRF.AutoSize = True
        Me.rbtnITRF.Location = New System.Drawing.Point(520, 66)
        Me.rbtnITRF.Name = "rbtnITRF"
        Me.rbtnITRF.Size = New System.Drawing.Size(90, 24)
        Me.rbtnITRF.TabIndex = 31
        Me.rbtnITRF.Text = "ITRF2020"
        Me.rbtnITRF.UseVisualStyleBackColor = True
        '
        'rbtnETRF
        '
        Me.rbtnETRF.AutoSize = True
        Me.rbtnETRF.Location = New System.Drawing.Point(340, 66)
        Me.rbtnETRF.Name = "rbtnETRF"
        Me.rbtnETRF.Size = New System.Drawing.Size(94, 24)
        Me.rbtnETRF.TabIndex = 32
        Me.rbtnETRF.Text = "ETRF2000"
        Me.rbtnETRF.UseVisualStyleBackColor = True
        '
        'linkVelo
        '
        Me.linkVelo.AutoSize = True
        Me.linkVelo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.linkVelo.Location = New System.Drawing.Point(820, 85)
        Me.linkVelo.Name = "linkVelo"
        Me.linkVelo.Size = New System.Drawing.Size(63, 20)
        Me.linkVelo.TabIndex = 33
        Me.linkVelo.TabStop = True
        Me.linkVelo.Text = "Velocità"
        '
        'cmb_plh
        '
        Me.cmb_plh.FormattingEnabled = True
        Me.cmb_plh.Items.AddRange(New Object() {"Planimetria", "Altimetria"})
        Me.cmb_plh.Location = New System.Drawing.Point(226, 117)
        Me.cmb_plh.Name = "cmb_plh"
        Me.cmb_plh.Size = New System.Drawing.Size(113, 28)
        Me.cmb_plh.TabIndex = 34
        '
        'frmRisGrafici
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(932, 453)
        Me.Controls.Add(Me.cmb_plh)
        Me.Controls.Add(Me.linkVelo)
        Me.Controls.Add(Me.rbtnETRF)
        Me.Controls.Add(Me.rbtnITRF)
        Me.Controls.Add(Me.picVel)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRisGrafici"
        Me.Text = "frmRisGrafici"
        CType(Me.picVel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents picVel As PictureBox
    Friend WithEvents rbtnITRF As RadioButton
    Friend WithEvents rbtnETRF As RadioButton
    Friend WithEvents linkVelo As LinkLabel
    Friend WithEvents cmb_plh As ComboBox
End Class
