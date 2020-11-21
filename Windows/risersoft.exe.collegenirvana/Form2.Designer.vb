<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SimpleEditor1 = New risersoft.[shared].win.SimpleEditor()
        Me.SuspendLayout()
        '
        'SimpleEditor1
        '
        Me.SimpleEditor1.Location = New System.Drawing.Point(12, 12)
        Me.SimpleEditor1.Name = "SimpleEditor1"
        Me.SimpleEditor1.Size = New System.Drawing.Size(678, 269)
        Me.SimpleEditor1.Styler = Nothing
        Me.SimpleEditor1.TabIndex = 0
        Me.SimpleEditor1.Text = "SimpleEditor1"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 296)
        Me.Controls.Add(Me.SimpleEditor1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SimpleEditor1 As SimpleEditor
End Class
