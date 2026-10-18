<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.lblStudent = New System.Windows.Forms.Label()
        Me.txtStudentName = New System.Windows.Forms.TextBox()
        Me.numHours = New System.Windows.Forms.NumericUpDown()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.mcalAbsence = New System.Windows.Forms.MonthCalendar()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAverage = New System.Windows.Forms.Button()
        Me.btnDeleteSelected = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lstRecords = New System.Windows.Forms.ListBox()
        Me.dgvAbsences = New System.Windows.Forms.DataGridView()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.numHours, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAbsences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblStudent
        '
        Me.lblStudent.AutoSize = True
        Me.lblStudent.Location = New System.Drawing.Point(32, 28)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Size = New System.Drawing.Size(130, 20)
        Me.lblStudent.TabIndex = 0
        Me.lblStudent.Text = "Όνομα Φοιτητή:"
        '
        'txtStudentName
        '
        Me.txtStudentName.Location = New System.Drawing.Point(168, 25)
        Me.txtStudentName.Name = "txtStudentName"
        Me.txtStudentName.Size = New System.Drawing.Size(200, 27)
        Me.txtStudentName.TabIndex = 1
        '
        'numHours
        '
        Me.numHours.Location = New System.Drawing.Point(168, 70)
        Me.numHours.Name = "numHours"
        Me.numHours.Size = New System.Drawing.Size(60, 27)
        Me.numHours.TabIndex = 2
        Me.numHours.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbCourse
        '
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Items.AddRange(New Object() {"Μαθηματικά", "Φυσική", "Προγραμματισμός", "Δίκτυα"})
        Me.cmbCourse.Location = New System.Drawing.Point(168, 115)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(200, 28)
        Me.cmbCourse.TabIndex = 3
        Me.cmbCourse.Text = "Προγραμματισμός"
        '
        'mcalAbsence
        '
        Me.mcalAbsence.Location = New System.Drawing.Point(36, 172)
        Me.mcalAbsence.Name = "mcalAbsence"
        Me.mcalAbsence.TabIndex = 4
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(40, 400)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(150, 40)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Προσθήκη"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(210, 400)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(150, 40)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Εκκαθάριση (Ανά Όνομα)"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(40, 460)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 40)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Αποθήκευση σε TXT"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(210, 460)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(150, 40)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Έξοδος"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAverage
        '
        Me.btnAverage.Location = New System.Drawing.Point(400, 460)
        Me.btnAverage.Name = "btnAverage"
        Me.btnAverage.Size = New System.Drawing.Size(150, 40)
        Me.btnAverage.TabIndex = 9
        Me.btnAverage.Text = "Μέσος Όρος"
        Me.btnAverage.UseVisualStyleBackColor = True
        '
        'btnDeleteSelected
        '
        Me.btnDeleteSelected.Location = New System.Drawing.Point(570, 400)
        Me.btnDeleteSelected.Name = "btnDeleteSelected"
        Me.btnDeleteSelected.Size = New System.Drawing.Size(200, 40)
        Me.btnDeleteSelected.TabIndex = 10
        Me.btnDeleteSelected.Text = "Διαγραφή Επιλεγμένου"
        Me.btnDeleteSelected.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(570, 460)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(200, 40)
        Me.btnLoad.TabIndex = 11
        Me.btnLoad.Text = "Φόρτωση Πίνακα DB"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'lstRecords
        '
        Me.lstRecords.FormattingEnabled = True
        Me.lstRecords.ItemHeight = 20
        Me.lstRecords.Location = New System.Drawing.Point(400, 25)
        Me.lstRecords.Name = "lstRecords"
        Me.lstRecords.Size = New System.Drawing.Size(480, 164)
        Me.lstRecords.TabIndex = 12
        '
        'dgvAbsences
        '
        Me.dgvAbsences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAbsences.Location = New System.Drawing.Point(400, 203)
        Me.dgvAbsences.Name = "dgvAbsences"
        Me.dgvAbsences.RowHeadersWidth = 51
        Me.dgvAbsences.RowTemplate.Height = 29
        Me.dgvAbsences.Size = New System.Drawing.Size(480, 180)
        Me.dgvAbsences.TabIndex = 13
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(40, 520)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(155, 20)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Αναμονή ενέργειας..."
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(400, 520)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(161, 20)
        Me.lblCount.TabIndex = 15
        Me.lblCount.Text = "Σύνολο Καταγραφών: 0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Ώρες Απουσίας:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Μάθημα:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 570)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.dgvAbsences)
        Me.Controls.Add(Me.lstRecords)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnDeleteSelected)
        Me.Controls.Add(Me.btnAverage)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.mcalAbsence)
        Me.Controls.Add(Me.cmbCourse)
        Me.Controls.Add(Me.numHours)
        Me.Controls.Add(Me.txtStudentName)
        Me.Controls.Add(Me.lblStudent)
        Me.Name = "Form1"
        Me.Text = "Διαχείριση Παρουσιολογίου ΣΑΕΚ"
        CType(Me.numHours, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAbsences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStudent As System.Windows.Forms.Label
    Friend WithEvents txtStudentName As System.Windows.Forms.TextBox
    Friend WithEvents numHours As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents mcalAbsence As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnAverage As System.Windows.Forms.Button
    Friend WithEvents btnDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lstRecords As System.Windows.Forms.ListBox
    Friend WithEvents dgvAbsences As System.Windows.Forms.DataGridView
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
