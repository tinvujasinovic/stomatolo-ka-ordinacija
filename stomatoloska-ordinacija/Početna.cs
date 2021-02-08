using Services;
using stomatoloska_ordinacija.Administracija.RadnoVrijeme;
using stomatoloska_ordinacija.Administracija.Zahvati;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsCalendar;

namespace stomatoloska_ordinacija
{
    public delegate void ItemCreated();

    public partial class Početna : Form
    {
        private DbService dbService = DbService.GetInstance();

        private List<CalendarItem> _items = new List<CalendarItem>();

        public Početna()
        {

            InitializeComponent();

            var item = new CalendarItem(calendar1, new DateTime(2021, 2, 4, 11, 30, 0, 0), new TimeSpan(0, 120, 0), "Testni dogadaj");
            item.BackgroundColor = Color.Orange;
            item.Tag = 1;

            _items.Add(item);
            _items.Add(new CalendarItem(calendar1, new DateTime(2021, 2, 4, 11, 30, 0, 0), new TimeSpan(3, 0, 0), "Testni dogadaj2"));

            var dates = GetStartingDates();

            calendar1.SetViewRange(dates.Item1, dates.Item2);

            SetHighlights();
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            foreach (CalendarItem calendarItem in _items)
            {
                if (this.calendar1.ViewIntersects(calendarItem))
                {
                    this.calendar1.Items.Add(calendarItem);
                }
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            this.calendar1.SetViewRange(this.monthView1.SelectionStart.Date, this.monthView1.SelectionEnd.Date);
        }

        #region Izbornik

        private void zahvatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new PregledZahvati();
            form.Show();
        }

        private void novaNarudžbaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void radnoVrijemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ManageRadnoVrijeme();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetHighlights();
            }
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
                start = start.AddDays(-(int)today.DayOfWeek+1);
                end = start.AddDays(4);
            }

            return new Tuple<DateTime, DateTime>(start, end);
        }

        private void SetHighlights()
        {

            var radnoVrijeme = dbService.GetRadnoVrijeme();

            if (radnoVrijeme == null)
            {
                var now = DateTime.Now;
                var pocetak = new DateTime(now.Year, now.Month, now.Day);
                pocetak = pocetak.AddHours(8);
                var kraj = new DateTime(now.Year, now.Month, now.Day);
                kraj = kraj.AddHours(16);

                radnoVrijeme = new Model.RadnoVrijeme(pocetak, kraj);
            }

            var highlightRanges = new List<CalendarHighlightRange>();

            var startHour = radnoVrijeme.Pocetak.Hour;
            var startMin = radnoVrijeme.Pocetak.Minute;

            var endHour = radnoVrijeme.Kraj.Hour;
            var endMin = radnoVrijeme.Kraj.Minute;

            calendar1.TimeUnitsOffset = -(startHour * 2);

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList())
            {
                highlightRanges.Add(new CalendarHighlightRange(day, new TimeSpan(startHour, startMin, 0), new TimeSpan(endHour, endMin, 0)));
            }
            calendar1.HighlightRanges = highlightRanges.ToArray();
        }
        #endregion

    }
}
