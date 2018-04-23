Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler.UI
Imports DevExpress.XtraScheduler

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub schedulerControl1_EditAppointmentFormShowing(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentFormEventArgs) Handles schedulerControl1.EditAppointmentFormShowing
			e.Handled = True
			Dim f As New MyAppointmentForm(TryCast(sender, SchedulerControl), e.Appointment, e.OpenRecurrenceForm)
			e.DialogResult = f.ShowDialog()

		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			schedulerStorage1.Resources.Add(New Resource(1, "John"))
			schedulerStorage1.Resources.Add(New Resource(1, "Jane"))
		End Sub
	End Class
	Public Class MyAppointmentForm
		Inherits AppointmentForm
	   Public Sub New(ByVal sc As SchedulerControl, ByVal apt As Appointment, ByVal openRecurrenceForm As Boolean)
		   MyBase.New(sc, apt, openRecurrenceForm)
			Me.edtResource.SelectedIndex = -1
			Me.edtResource.Properties.Items.RemoveAt(0)
	   End Sub
	End Class
End Namespace