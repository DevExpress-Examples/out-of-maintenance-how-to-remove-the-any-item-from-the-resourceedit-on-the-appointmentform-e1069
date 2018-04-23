using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            e.Handled = true;
            MyAppointmentForm f = new MyAppointmentForm(sender as SchedulerControl , e.Appointment, e.OpenRecurrenceForm);
            e.DialogResult = f.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            schedulerStorage1.Resources.Add(this.schedulerStorage1.CreateResource(1, "John"));
            schedulerStorage1.Resources.Add(this.schedulerStorage1.CreateResource(2, "Jane"));
        }
    }
    public class MyAppointmentForm : AppointmentForm
    {
       public MyAppointmentForm(SchedulerControl sc, Appointment apt, bool openRecurrenceForm)
            : base(sc, apt, openRecurrenceForm)
        {
            this.edtResource.SelectedIndex = -1;
            this.edtResource.Properties.Items.RemoveAt(0);
        }
    }
}