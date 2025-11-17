<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipale
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mnOpzioni = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOpzGenerale = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOpzStazioni = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOpzServer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnRisultati = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnRisCrd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnRisGrafici = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAvanzate = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdAiuto = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnCalcola = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtLog = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnOpzioni
        '
        Me.mnOpzioni.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnOpzGenerale, Me.mnOpzStazioni, Me.mnOpzServer})
        Me.mnOpzioni.Name = "mnOpzioni"
        Me.mnOpzioni.Size = New System.Drawing.Size(75, 24)
        Me.mnOpzioni.Text = "Opzioni"
        '
        'mnOpzGenerale
        '
        Me.mnOpzGenerale.Name = "mnOpzGenerale"
        Me.mnOpzGenerale.Size = New System.Drawing.Size(223, 26)
        Me.mnOpzGenerale.Text = "Generale"
        '
        'mnOpzStazioni
        '
        Me.mnOpzStazioni.Name = "mnOpzStazioni"
        Me.mnOpzStazioni.Size = New System.Drawing.Size(223, 26)
        Me.mnOpzStazioni.Text = "Stazioni Permanenti"
        '
        'mnOpzServer
        '
        Me.mnOpzServer.Name = "mnOpzServer"
        Me.mnOpzServer.Size = New System.Drawing.Size(223, 26)
        Me.mnOpzServer.Text = "Server FTP"
        '
        'mnRisultati
        '
        Me.mnRisultati.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnRisCrd, Me.mnRisGrafici})
        Me.mnRisultati.Name = "mnRisultati"
        Me.mnRisultati.Size = New System.Drawing.Size(76, 24)
        Me.mnRisultati.Text = "Risultati"
        '
        'mnRisCrd
        '
        Me.mnRisCrd.Name = "mnRisCrd"
        Me.mnRisCrd.Size = New System.Drawing.Size(166, 26)
        Me.mnRisCrd.Text = "Coordinate"
        '
        'mnRisGrafici
        '
        Me.mnRisGrafici.Name = "mnRisGrafici"
        Me.mnRisGrafici.Size = New System.Drawing.Size(166, 26)
        Me.mnRisGrafici.Text = "Grafici"
        '
        'mnAvanzate
        '
        Me.mnAvanzate.Name = "mnAvanzate"
        Me.mnAvanzate.Size = New System.Drawing.Size(84, 24)
        Me.mnAvanzate.Text = "Avanzate"
        '
        'cmdAiuto
        '
        Me.cmdAiuto.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdAiuto.BackColor = System.Drawing.SystemColors.MenuBar
        Me.cmdAiuto.Name = "cmdAiuto"
        Me.cmdAiuto.Size = New System.Drawing.Size(30, 24)
        Me.cmdAiuto.Text = "?"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnOpzioni, Me.mnRisultati, Me.cmdAiuto, Me.mnCalcola, Me.mnAvanzate})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(932, 28)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnCalcola
        '
        Me.mnCalcola.Name = "mnCalcola"
        Me.mnCalcola.Size = New System.Drawing.Size(72, 24)
        Me.mnCalcola.Text = "Calcola"
        '
        'txtLog
        '
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.ForeColor = System.Drawing.Color.Transparent
        Me.txtLog.Location = New System.Drawing.Point(0, 28)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(932, 425)
        Me.txtLog.TabIndex = 6
        Me.txtLog.Text = ""
        Me.txtLog.Visible = False
        '
        'frmPrincipale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 453)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmPrincipale"
        Me.Text = "Compensazione geodetica automatica"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnOpzioni As ToolStripMenuItem
    Friend WithEvents mnOpzGenerale As ToolStripMenuItem
    Friend WithEvents mnOpzStazioni As ToolStripMenuItem
    Friend WithEvents ServerFTPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmdRisultati As ToolStripMenuItem
    Friend WithEvents cmdAvanzate As ToolStripMenuItem
    Friend WithEvents cmdAiuto As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents txtLog As RichTextBox
    Friend WithEvents CoordinateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GraficiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnOpzServer As ToolStripMenuItem
    Friend WithEvents mnRisultati As ToolStripMenuItem
    Friend WithEvents mnRisCrd As ToolStripMenuItem
    Friend WithEvents mnRisGrafici As ToolStripMenuItem
    Friend WithEvents mnAvanzate As ToolStripMenuItem
    Friend WithEvents mnCalcola As ToolStripMenuItem
End Class
