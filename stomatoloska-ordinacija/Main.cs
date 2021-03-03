using Services;
using stomatoloska_ordinacija.Administration.WorkHours;
using stomatoloska_ordinacija.Administration.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsCalendar;
using stomatoloska_ordinacija.App.Appointments;
using stomatoloska_ordinacija.Administration.Patients;
using Services.Appointments;
using Services.WorkHours;

namespace stomatoloska_ordinacija
{
    public delegate void ItemCreated();

    public partial class Main : Form
    {
        private AppointmentsService appointmentsService= new AppointmentsService();
        private WorkHoursService workHoursService= new WorkHoursService();

        private List<CalendarItem> _items = new List<CalendarItem>();

        public Main()
        {

            InitializeComponent();

            var dates = GetStartingDates();

            calendar1.SetViewRange(dates.Item1, dates.Item2);

            GetAppointmentsForCalendar(dates.Item1, dates.Item2);

            SetHighlights();
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            foreach (CalendarItem calendarItem in _items)
            {
                if (calendar1.ViewIntersects(calendarItem))
                {
                    calendar1.Items.Add(calendarItem);
                }
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart.Date, monthView1.SelectionEnd.Date);

            GetAppointmentsForCalendar(monthView1.SelectionStart.Date, monthView1.SelectionEnd.Date);
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            var item = e.Item;

            if(item.Tag == null)
            {
                _items.Remove(item);
                return;
            }

            int appointmentId = (int)item.Tag;

            if (appointmentsService.ChangeAppointmentCompleteFlag(appointmentId, item.BackgroundColor == Color.Orange ? 1 : 0))
            {
                item.BackgroundColor = item.BackgroundColor == Color.Orange ? Color.Green : Color.Orange;
            }
        }

        #region Izbornik

        private void zahvatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new OverviewOperations();
            form.Show();
        }

        private void narudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new OverviewAppointments();
            form.Show();
        }

        private void radnoVrijemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ManageWorkHours();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetHighlights();
            }
        }

        private void pacijentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new OverviewPatients();
            form.Show();
        }

        #endregion

        #region Helper

        private Tuple<DateTime, DateTime> GetStartingDates()
        {
            var today = DateTime.Now;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if ((int)today.DayOfWeek == (int)DayOfWeek.Saturday || (int)today.DayOfWeek == (int)DayOfWeek.Sunday)
            {
                start = (int)today.DayOfWeek == (int)DayOfWeek.Saturday ? start.AddDays(2) : start.AddDays(1);
                end = start.AddDays(5);
            }
            else
            {
                start = start.AddDays(-(int)today.DayOfWeek + 1);
                end = start.AddDays(4);
            }

            return new Tuple<DateTime, DateTime>(start, end);
        }

        private void SetHighlights()
        {

            var workHours = workHoursService.GetWorkHours();

            if (workHours == null)
            {
                var now = DateTime.Now;
                var start = new DateTime(now.Year, now.Month, now.Day);
                start = start.AddHours(8);
                var end = new DateTime(now.Year, now.Month, now.Day);
                end = end.AddHours(16);

                workHours = new Model.WorkHour(start, end);
            }

            var highlightRanges = new List<CalendarHighlightRange>();

            var startHour = workHours.StartTime.Hour;
            var startMin = workHours.StartTime.Minute;

            var endHour = workHours.EndTime.Hour;
            var endMin = workHours.EndTime.Minute;

            calendar1.TimeUnitsOffset = -(startHour * 2);

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList())
            {
                highlightRanges.Add(new CalendarHighlightRange(day, new TimeSpan(startHour, startMin, 0), new TimeSpan(endHour, endMin, 0)));
            }
            calendar1.HighlightRanges = highlightRanges.ToArray();
        }

        private void GetAppointmentsForCalendar(DateTime start, DateTime end)
        {
            _items.Clear();

            var appointments = appointmentsService.GetAllAppointments(start, end);

            foreach (var appointment in appointments)
            {
                var item = new CalendarItem(calendar1, appointment.Time, new TimeSpan(0, appointment.Operation.Duration.DurationInMinutes, 0), appointment.ToString())
                {
                    BackgroundColor = appointment.Completed ? Color.Green : Color.Orange,
                    Tag = appointment.Id
                };

                _items.Add(item);
            }

            foreach (CalendarItem calendarItem in _items)
            {
                if (calendar1.ViewIntersects(calendarItem))
                {
                    calendar1.Items.Add(calendarItem);
                }
            }
        }
        #endregion
    }
}
