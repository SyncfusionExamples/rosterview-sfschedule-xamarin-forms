using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using System.ComponentModel;

namespace ScheduleXamarin
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// list of meeting
        /// </summary>
        private ScheduleAppointmentCollection events;

        /// <summary>
        /// name collection
        /// </summary>

        internal List<string> nameCollection;

        /// <summary>
        /// resources
        /// </summary>
        private ObservableCollection<object> employees;

        public SchedulerViewModel()
        {
            this.events = new ScheduleAppointmentCollection();
            employees = new ObservableCollection<object>();
            this.InitializeDataForBookings();
            this.InitializeResources();
            this.BookingAppointments();
        }

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ListOfMeeting

        /// <summary>
        /// Gets or sets list of meeting
        /// </summary>
        public ScheduleAppointmentCollection Events
        {
            get
            {
                return this.events;
            }

            set
            {
                this.events = value;
                this.RaiseOnPropertyChanged("Events");
            }
        }
        #endregion

        public ObservableCollection<object> Employees
        {
            get
            {
                return employees;
            }

            set
            {
                employees = value;
                this.RaiseOnPropertyChanged("Employees");
            }
        }

        private void InitializeResources()
        {
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                Employees.Add(new ScheduleResource()
                {
                    Name = nameCollection[random.Next(0, 9)],
                    Color = Color.FromRgb(random.Next(0, 255), random.Next(10, 255), random.Next(100, 255)),
                    Id = "560" + i.ToString(),
                    Image = i < 9 ? "employee" + i.ToString() + ".png" : null
                });
            }
        }

        #region BookingAppointments

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        private void BookingAppointments()
        {
            Random random = new Random();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-20);
            DateTime dateTo = DateTime.Now.AddDays(20);

            foreach(var resource in Employees)
            {
                for(date = dateFrom; date <dateTo; date = date.AddDays(1))
                {
                    ScheduleAppointment workDetails = new ScheduleAppointment();
                    workDetails.StartTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    workDetails.EndTime = workDetails.StartTime.AddHours(1);
                    workDetails.Subject = this.currentDayMeetings[random.Next(6)];
                    workDetails.Color = workDetails.Subject == "Work" ? Color.Green : (workDetails.Subject == "Off" ? Color.Gray : Color.Red);
                    workDetails.IsAllDay = true;
                    workDetails.ResourceIds = new ObservableCollection<object>
                        {
                            (resource as ScheduleResource).Id
                        };

                    this.Events.Add(workDetails);
                }
            }
        }

        #endregion BookingAppointments

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Leave");
            this.currentDayMeetings.Add("Off");
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Work");

            this.nameCollection = new List<string>();
            this.nameCollection.Add("Brooklyn");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Danial William");
        }

        #endregion InitializeDataForBookings

        #region Property Changed Event

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
