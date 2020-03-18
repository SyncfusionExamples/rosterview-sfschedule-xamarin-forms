# How to create a roster schedule view using Xamarin.Forms Schedule (SfSchedule)

You can create a roster schedule view using [SfSchedule](https://help.syncfusion.com/xamarin/scheduler/overview?) in Xamarin.Forms. A roster schedule is a schedule that provides information about a list of employees and associated information for a given time period.

![LandscapeRosterView](https://github.com/SyncfusionExamples/rosterview-sfschedule-xamarin-forms/blob/master/Screenshots/RosterScheduleViewLandscape.png)

The following article explains about Roster Scheduler View with SfSchedule.
https://www.syncfusion.com/kb/11234/how-to-create-a-roster-schedule-view-using-xamarin-forms-schedule-sfschedule

**Step 1:** Enable resource view by setting the [ShowResourceView](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~ShowResourceView.html?) property of schedule, use Timeline view with Absolute [ResourceViewMode](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~ResourceViewMode.html?) and set schedule TimeInterval as 1440(24 hours) to make one slot for a day in TimelineView.

``` xml
<syncfusion:SfSchedule x:Name="schedule"
                           ScheduleView="TimelineView"
                           ShowResourceView="True"
                           ResourceViewMode="Absolute"
                           TimeInterval="1440">
```
**Step 2:** Customize the appearance of appointment using [AppointmentTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~AppointmentTemplate.html?).
``` xml
<syncfusion:SfSchedule.AppointmentTemplate>
        <DataTemplate>
               <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="0.5*"/>
                            <RowDefinition Height="0.5*"/>
                        </Grid.RowDefinitions>
                        <Label TextColor="Black" FontAttributes="Bold" Text="{Binding Subject}" Grid.Row="0" HorizontalTextAlignment="Center" VerticalTextAlignment="Center"/>
                        <BoxView Color="{Binding Color}" CornerRadius="5" HeightRequest="10" WidthRequest="10" Grid.Row="1" HorizontalOptions="Center" VerticalOptions="Center" />
             </Grid>
       </DataTemplate>
</syncfusion:SfSchedule.AppointmentTemplate>
```
**Step 3:** Set [TimeRuler](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.TimelineViewSettings~TimeRulerSize.html?) size to 0 to hide the time ruler and [DaysCount](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.TimelineViewSettings~DaysCount.html?) as 7 to show Timeline for a week in [TimelineViewSettings](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.TimelineViewSettings.html?). As the default Timeline view starts from the current date, if you want to start Timeline from a particular day, you can set the [MoveToDate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~MoveToDate.html?) property of schedule.

``` c#
TimelineViewSettings timelineViewSettings = new TimelineViewSettings();
timelineViewSettings.TimeRulerSize = 0;
timelineViewSettings.DaysCount = 7;
 
this.schedule.TimelineViewSettings = timelineViewSettings;
```
**Step 4:** Customize the ViewHeader date format as required using the [DateFormat](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.TimelineLabelSettings~DateFormat.html?) property of [TimelineLabelSettings](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.TimelineLabelSettings.html?).

``` c#
  TimelineLabelSettings labelSettings = new TimelineLabelSettings();
  labelSettings.DateFormat = Device.RuntimePlatform == "UWP" ? "%d ddd" : "dd EEE";
 
  timelineViewSettings.LabelSettings = labelSettings;
  this.schedule.TimelineViewSettings = timelineViewSettings;
```

**Output**

![RosterViewPortrait](https://github.com/SyncfusionExamples/rosterview-sfschedule-xamarin-forms/blob/master/Screenshots/RosterScheduleViewPortrait.png)
