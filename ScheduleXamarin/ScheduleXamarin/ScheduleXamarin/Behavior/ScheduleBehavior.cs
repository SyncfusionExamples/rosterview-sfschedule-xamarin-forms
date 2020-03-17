using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;

namespace ScheduleXamarin
{
    public class ScheduleBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.schedule = bindable.FindByName<SfSchedule>("schedule");

            TimelineLabelSettings labelSettings = new TimelineLabelSettings();
            labelSettings.DateFormat = Device.RuntimePlatform == "UWP" ? "%d ddd" : "dd EEE";

            TimelineViewSettings timelineViewSettings = new TimelineViewSettings();
            timelineViewSettings.LabelSettings = labelSettings;
            timelineViewSettings.TimeRulerSize = 0;
            timelineViewSettings.DaysCount = 7;

            this.schedule.TimelineViewSettings = timelineViewSettings;
            this.schedule.ViewHeaderStyle.DateFontSize = Device.RuntimePlatform == "iOS" ? 14 : 15;
            this.schedule.MoveToDate = this.FindFirstDateofWeek();
        }

        private DateTime FindFirstDateofWeek()
        {
            var currentDay = (int)DateTime.Now.DayOfWeek;
            return DateTime.Now.Date.AddDays(-currentDay);
        }
    }
}
