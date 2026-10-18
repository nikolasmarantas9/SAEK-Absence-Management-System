Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Globalization

Public Class Form1
    Private Const MAX_ABSENCES As Integer = 50
    Private Const WARNING_ABSENCES As Integer = 40
    Private ReadOnly connectionString As String =
        "server=localhost;user id=root;password=;database=students_db;"

    Private ReadOnly bgColor As Color = Color.FromArgb(18, 24, 38)
    Private ReadOnly panelColor As Color = Color.FromArgb(27, 36, 53)
    Private ReadOnly accentColor As Color = Color.FromArgb(59, 130, 246)
    Private ReadOnly textColor As Color = Color.FromArgb(235, 241, 250)
    Private ReadOnly mutedColor As Color = Color.FromArgb(160, 174, 195)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyModernTheme()
        ConfigureControls()
        MarkWeekendsAndHolidays()
        LoadRecords()
        LoadGrid()
        UpdateCounter()
        UpdateSelectedDateStatus()
    End Sub

    Private Sub ApplyModernTheme()
        Me.Text = "SAEK | Student Absence Management"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MinimumSize = New Size(940, 620)
        Me.BackColor = bgColor
        Me.ForeColor = textColor
        Me.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        Me.AutoScaleMode = AutoScaleMode.Font

        For Each ctl As Control In GetAllControls(Me)
            ctl.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            If TypeOf ctl Is Label Then
                ctl.ForeColor = textColor
                ctl.BackColor = Color.Transparent
            ElseIf TypeOf ctl Is TextBox OrElse TypeOf ctl Is ComboBox OrElse TypeOf ctl Is NumericUpDown Then
                ctl.BackColor = panelColor
                ctl.ForeColor = textColor
            ElseIf TypeOf ctl Is ListBox Then
                ctl.BackColor = panelColor
                ctl.ForeColor = textColor
                DirectCast(ctl, ListBox).BorderStyle = BorderStyle.FixedSingle
            ElseIf TypeOf ctl Is Button Then
                StyleButton(DirectCast(ctl, Button))
            End If
        Next

        mcalAbsence.BackColor = panelColor
        mcalAbsence.ForeColor = textColor
        lstRecords.HorizontalScrollbar = True
        dgvAbsences.BackgroundColor = panelColor
        dgvAbsences.BorderStyle = BorderStyle.None
        dgvAbsences.EnableHeadersVisualStyles = False
        dgvAbsences.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(38, 52, 74)
        dgvAbsences.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvAbsences.DefaultCellStyle.BackColor = panelColor
        dgvAbsences.DefaultCellStyle.ForeColor = textColor
        dgvAbsences.DefaultCellStyle.SelectionBackColor = accentColor
        dgvAbsences.DefaultCellStyle.SelectionForeColor = Color.White
        dgvAbsences.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(32, 43, 62)
        dgvAbsences.GridColor = Color.FromArgb(54, 68, 90)
        dgvAbsences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAbsences.ReadOnly = True
        dgvAbsences.AllowUserToAddRows = False
        dgvAbsences.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAbsences.MultiSelect = False

        lblStatus.ForeColor = accentColor
        lblCount.ForeColor = accentColor
    End Sub

    Private Function GetAllControls(parent As Control) As List(Of Control)
        Dim controls As New List(Of Control)
        For Each child As Control In parent.Controls
            controls.Add(child)
            controls.AddRange(GetAllControls(child))
        Next
        Return controls
    End Function

    Private Sub StyleButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = accentColor
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand
        btn.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
        btn.Height = Math.Max(btn.Height, 36)
    End Sub

    Private Sub ConfigureControls()
        numHours.Minimum = 1
        numHours.Maximum = 12
        numHours.Value = 1
        cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList
        If cmbCourse.SelectedIndex < 0 AndAlso cmbCourse.Items.Count > 0 Then cmbCourse.SelectedIndex = 0
        txtStudentName.MaxLength = 255
        lblStatus.AutoSize = False
        lblStatus.Text = "Έτοιμο για καταχώριση."
        lblCount.AutoSize = True
    End Sub

    Private Sub MarkWeekendsAndHolidays()
        Dim dates As New List(Of DateTime)
        Dim year As Integer = Date.Today.Year
        Dim d As New DateTime(year, 1, 1)
        While d.Year = year
            If d.DayOfWeek = DayOfWeek.Saturday OrElse d.DayOfWeek = DayOfWeek.Sunday Then dates.Add(d)
            d = d.AddDays(1)
        End While
        dates.Add(New DateTime(year, 3, 25))
        dates.Add(New DateTime(year, 10, 28))
        dates.Add(New DateTime(year, 11, 17))
        mcalAbsence.BoldedDates = dates.Distinct().ToArray()
        mcalAbsence.UpdateBoldedDates()
    End Sub

    Private Sub LoadRecords(Optional selectedDate As Date? = Nothing)
        lstRecords.Items.Clear()
        Try
            Using db As New MySqlConnection(connectionString)
                db.Open()
                Dim sql As String = "SELECT id, name, hours, course_name, absence_date FROM absences"
                If selectedDate.HasValue Then sql &= " WHERE absence_date = @date"
                sql &= " ORDER BY absence_date DESC, id DESC"
                Using cmd As New MySqlCommand(sql, db)
                    If selectedDate.HasValue Then cmd.Parameters.Add("@date", MySqlDbType.Date).Value = selectedDate.Value.Date
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            lstRecords.Items.Add(String.Format("{0:dd/MM/yyyy} | {1} | {2} - {3} ώρες",
                                Convert.ToDateTime(reader("absence_date")),
                                reader("course_name").ToString(),
                                reader("name").ToString(),
                                Convert.ToInt32(reader("hours"))))
                        End While
                    End Using
                End Using
            End Using
            lblStatus.Text = If(selectedDate.HasValue, "Εμφάνιση εγγραφών για " & selectedDate.Value.ToString("dd/MM/yyyy"), "Οι εγγραφές φορτώθηκαν.")
            lblStatus.ForeColor = accentColor
        Catch ex As Exception
            ShowError("Δεν ήταν δυνατή η φόρτωση των απουσιών. Έλεγξε αν λειτουργεί η MySQL και αν υπάρχει η βάση students_db.", ex)
        End Try
        UpdateCounter()
    End Sub

    Private Sub LoadGrid()
        Try
            Using db As New MySqlConnection(connectionString)
                Using adapter As New MySqlDataAdapter(
                    "SELECT id, name, course_name, hours, absence_date FROM absences ORDER BY absence_date DESC, id DESC", db)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    dgvAbsences.DataSource = table
                    If dgvAbsences.Columns.Contains("id") Then dgvAbsences.Columns("id").HeaderText = "Κωδικός"
                    If dgvAbsences.Columns.Contains("name") Then dgvAbsences.Columns("name").HeaderText = "Ονοματεπώνυμο"
                    If dgvAbsences.Columns.Contains("course_name") Then dgvAbsences.Columns("course_name").HeaderText = "Μάθημα"
                    If dgvAbsences.Columns.Contains("hours") Then dgvAbsences.Columns("hours").HeaderText = "Ώρες"
                    If dgvAbsences.Columns.Contains("absence_date") Then
                        dgvAbsences.Columns("absence_date").HeaderText = "Ημερομηνία"
                        dgvAbsences.Columns("absence_date").DefaultCellStyle.Format = "dd/MM/yyyy"
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblStatus.Text = "Δεν φορτώθηκε ο πίνακας βάσης."
            lblStatus.ForeColor = Color.Orange
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim studentName As String = txtStudentName.Text.Trim()
        Dim course As String = cmbCourse.Text.Trim()
        Dim selectedDate As Date = mcalAbsence.SelectionStart.Date
        Dim hours As Integer = CInt(numHours.Value)

        If studentName.Length = 0 Then
            MessageBox.Show("Συμπλήρωσε το ονοματεπώνυμο του μαθητή.", "Απαιτείται όνομα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentName.Focus()
            Return
        End If
        If course.Length = 0 Then
            MessageBox.Show("Επίλεξε μάθημα.", "Απαιτείται μάθημα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If selectedDate.DayOfWeek = DayOfWeek.Saturday OrElse selectedDate.DayOfWeek = DayOfWeek.Sunday Then
            MessageBox.Show("Δεν επιτρέπεται καταχώριση απουσίας το Σαββατοκύριακο.", "Μη έγκυρη ημερομηνία", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If selectedDate > Date.Today Then
            MessageBox.Show("Δεν επιτρέπεται καταχώριση για μελλοντική ημερομηνία.", "Μη έγκυρη ημερομηνία", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim total As Integer
            Using db As New MySqlConnection(connectionString)
                db.Open()
                Using tx = db.BeginTransaction()
                    Using cmd As New MySqlCommand(
                        "INSERT INTO absences (name, hours, course_name, absence_date) VALUES (@name, @hours, @course, @date)", db, tx)
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 255).Value = studentName
                        cmd.Parameters.Add("@hours", MySqlDbType.Int32).Value = hours
                        cmd.Parameters.Add("@course", MySqlDbType.VarChar, 255).Value = course
                        cmd.Parameters.Add("@date", MySqlDbType.Date).Value = selectedDate
                        cmd.ExecuteNonQuery()
                    End Using
                    Using cmdSum As New MySqlCommand("SELECT COALESCE(SUM(hours), 0) FROM absences WHERE name = @name", db, tx)
                        cmdSum.Parameters.Add("@name", MySqlDbType.VarChar, 255).Value = studentName
                        total = Convert.ToInt32(cmdSum.ExecuteScalar())
                    End Using
                    tx.Commit()
                End Using
            End Using

            LoadRecords()
            LoadGrid()
            txtStudentName.Clear()
            txtStudentName.Focus()
            If total > MAX_ABSENCES Then
                SetStatus("Προσοχή: " & studentName & " έχει " & total & " ώρες απουσίας — ξεπέρασε το όριο.", Color.IndianRed)
                MessageBox.Show("Το σύνολο του/της " & studentName & " είναι " & total & " ώρες απουσίας και ξεπερνά το όριο των " & MAX_ABSENCES & ".", "Υπέρβαση ορίου", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf total >= WARNING_ABSENCES Then
                SetStatus("Προειδοποίηση: " & studentName & " — σύνολο " & total & " ώρες απουσίας.", Color.DarkOrange)
            Else
                SetStatus("Η καταχώριση ολοκληρώθηκε. Σύνολο μαθητή: " & total & " ώρες.", Color.LightGreen)
            End If
        Catch ex As Exception
            ShowError("Η καταχώριση απέτυχε. Έλεγξε τη σύνδεση και τη δομή της βάσης.", ex)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim studentName As String = txtStudentName.Text.Trim()
        If studentName.Length = 0 Then
            MessageBox.Show("Γράψε το ακριβές ονοματεπώνυμο του μαθητή που θέλεις να διαγράψεις.", "Απαιτείται όνομα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Να διαγραφούν ΟΛΕΣ οι απουσίες για τον/την " & studentName & ";",
                           "Επιβεβαίωση διαγραφής", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            Dim deleted As Integer
            Using db As New MySqlConnection(connectionString)
                db.Open()
                Using cmd As New MySqlCommand("DELETE FROM absences WHERE name = @name", db)
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar, 255).Value = studentName
                    deleted = cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadRecords()
            LoadGrid()
            SetStatus("Διαγράφηκαν " & deleted & " εγγραφές για " & studentName & ".", accentColor)
        Catch ex As Exception
            ShowError("Δεν ήταν δυνατή η διαγραφή των εγγραφών.", ex)
        End Try
    End Sub

    Private Sub btnDeleteSelected_Click(sender As Object, e As EventArgs) Handles btnDeleteSelected.Click
        If lstRecords.SelectedItem Is Nothing Then
            MessageBox.Show("Επίλεξε μια εγγραφή από τη λίστα.", "Δεν επιλέχθηκε εγγραφή", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim record As String = lstRecords.SelectedItem.ToString()
        Dim parts As String() = record.Split(New String() {" | "}, StringSplitOptions.None)
        If parts.Length <> 3 Then
            MessageBox.Show("Δεν ήταν δυνατή η αναγνώριση της επιλεγμένης εγγραφής. Κάνε ανανέωση της λίστας.", "Σφάλμα εγγραφής", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim absenceDate As Date
        If Not Date.TryParseExact(parts(0), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, absenceDate) Then
            MessageBox.Show("Η ημερομηνία της εγγραφής δεν είναι έγκυρη.", "Σφάλμα εγγραφής", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim course As String = parts(1).Trim()
        Dim dash As Integer = parts(2).LastIndexOf(" - ", StringComparison.Ordinal)
        If dash < 0 Then Return
        Dim studentName As String = parts(2).Substring(0, dash).Trim()
        Dim hoursText As String = parts(2).Substring(dash + 3).Replace(" ώρες", "").Trim()
        Dim hours As Integer
        If Not Integer.TryParse(hoursText, hours) Then Return

        If MessageBox.Show("Να διαγραφεί η επιλεγμένη απουσία;" & Environment.NewLine & record,
                           "Επιβεβαίωση διαγραφής", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            Using db As New MySqlConnection(connectionString)
                db.Open()
                Using cmd As New MySqlCommand(
                    "DELETE FROM absences WHERE name = @name AND course_name = @course AND hours = @hours AND absence_date = @date LIMIT 1", db)
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar, 255).Value = studentName
                    cmd.Parameters.Add("@course", MySqlDbType.VarChar, 255).Value = course
                    cmd.Parameters.Add("@hours", MySqlDbType.Int32).Value = hours
                    cmd.Parameters.Add("@date", MySqlDbType.Date).Value = absenceDate.Date
                    If cmd.ExecuteNonQuery() = 0 Then
                        MessageBox.Show("Η εγγραφή δεν βρέθηκε στη βάση. Θα ανανεωθεί η λίστα.", "Δεν βρέθηκε", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
            LoadRecords()
            LoadGrid()
            SetStatus("Η επιλεγμένη εγγραφή διαγράφηκε από τη βάση.", accentColor)
        Catch ex As Exception
            ShowError("Δεν ήταν δυνατή η διαγραφή της επιλεγμένης απουσίας.", ex)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Using dialog As New SaveFileDialog()
            dialog.Title = "Εξαγωγή απουσιών"
            dialog.Filter = "Αρχείο CSV (*.csv)|*.csv|Αρχείο κειμένου (*.txt)|*.txt"
            dialog.FileName = "absences-export.csv"
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            Try
                Using writer As New StreamWriter(dialog.FileName, False, New System.Text.UTF8Encoding(True))
                    writer.WriteLine("""Ημερομηνία"";""Μάθημα"";""Ονοματεπώνυμο"";""Ώρες""")
                    For Each item As Object In lstRecords.Items
                        Dim parts = item.ToString().Split(New String() {" | "}, StringSplitOptions.None)
                        If parts.Length = 3 Then
                            Dim dash = parts(2).LastIndexOf(" - ", StringComparison.Ordinal)
                            If dash > -1 Then
                                writer.WriteLine("""" & parts(0) & """;""" & parts(1).Replace("""", """""") & """;""" &
                                    parts(2).Substring(0, dash).Replace("""", """""") & """;""" &
                                    parts(2).Substring(dash + 3).Replace(" ώρες", "") & """")
                            End If
                        End If
                    Next
                End Using
                SetStatus("Η εξαγωγή ολοκληρώθηκε: " & Path.GetFileName(dialog.FileName), Color.LightGreen)
                MessageBox.Show("Το αρχείο εξαγωγής αποθηκεύτηκε επιτυχώς.", "Εξαγωγή ολοκληρώθηκε", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                ShowError("Δεν ήταν δυνατή η αποθήκευση του αρχείου.", ex)
            End Try
        End Using
    End Sub

    Private Sub btnAverage_Click(sender As Object, e As EventArgs) Handles btnAverage.Click
        Try
            Using db As New MySqlConnection(connectionString)
                db.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) AS records_count, COALESCE(SUM(hours),0) AS total_hours, COALESCE(AVG(hours),0) AS average_hours FROM absences", db)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            MessageBox.Show("Σύνοψη απουσιών" & Environment.NewLine & Environment.NewLine &
                                "Εγγραφές: " & reader("records_count").ToString() & Environment.NewLine &
                                "Συνολικές ώρες: " & reader("total_hours").ToString() & Environment.NewLine &
                                "Μέσος όρος ωρών ανά εγγραφή: " & Convert.ToDouble(reader("average_hours")).ToString("0.00"),
                                "Στατιστικά", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ShowError("Δεν ήταν δυνατός ο υπολογισμός στατιστικών.", ex)
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadGrid()
        LoadRecords()
        SetStatus("Τα δεδομένα ανανεώθηκαν από τη βάση.", accentColor)
    End Sub

    Private Sub mcalAbsence_DateSelected(sender As Object, e As DateRangeEventArgs) Handles mcalAbsence.DateSelected
        LoadRecords(e.Start.Date)
    End Sub

    Private Sub mcalAbsence_DateChanged(sender As Object, e As DateRangeEventArgs) Handles mcalAbsence.DateChanged
        UpdateSelectedDateStatus()
    End Sub

    Private Sub UpdateSelectedDateStatus()
        Dim d As Date = mcalAbsence.SelectionStart.Date
        If d.DayOfWeek = DayOfWeek.Saturday OrElse d.DayOfWeek = DayOfWeek.Sunday Then
            SetStatus("Επιλέχθηκε Σαββατοκύριακο — δεν επιτρέπεται καταχώριση.", Color.IndianRed)
            btnAdd.Enabled = False
        ElseIf d > Date.Today Then
            SetStatus("Επιλέχθηκε μελλοντική ημερομηνία — δεν επιτρέπεται καταχώριση.", Color.DarkOrange)
            btnAdd.Enabled = False
        Else
            btnAdd.Enabled = True
            SetStatus("Επιλεγμένη ημερομηνία: " & d.ToString("dd/MM/yyyy"), accentColor)
        End If
    End Sub

    Private Sub UpdateCounter()
        lblCount.Text = "Σύνολο εγγραφών: " & lstRecords.Items.Count.ToString()
        lblCount.ForeColor = If(lstRecords.Items.Count = 0, mutedColor, accentColor)
    End Sub

    Private Sub SetStatus(message As String, color As Color)
        lblStatus.Text = message
        lblStatus.ForeColor = color
    End Sub

    Private Sub ShowError(message As String, ex As Exception)
        SetStatus(message, Color.IndianRed)
        MessageBox.Show(message & Environment.NewLine & Environment.NewLine & ex.Message,
                        "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
