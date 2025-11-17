<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRisCrd
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
        Me.picMappaCrd = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.picMappaCrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picMappaCrd
        '
        Me.picMappaCrd.Location = New System.Drawing.Point(217, 108)
        Me.picMappaCrd.Name = "picMappaCrd"
        Me.picMappaCrd.Size = New System.Drawing.Size(660, 540)
        Me.picMappaCrd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMappaCrd.TabIndex = 32
        Me.picMappaCrd.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label6.Location = New System.Drawing.Point(338, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(207, 23)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Risultati 1 - Coordinate"
        '
        'frmRisCrd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(932, 453)
        Me.Controls.Add(Me.picMappaCrd)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmRisCrd"
        Me.Text = "frmRisCrd"
        CType(Me.picMappaCrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picMappaCrd As PictureBox
    Friend WithEvents Label6 As Label
End Class
