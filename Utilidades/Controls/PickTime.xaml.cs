﻿using Controls.Suport;
using CryGeo.Style;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Controls
{
    public partial class PickTime : UserControl
    {
        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(nameof(Time),
                                                                                             typeof(TimeSpan),
                                                                                             typeof(PickTime),
                                                                                             new PropertyMetadata(TimeSpan.Zero, TimePropertyChanged));


        public static readonly DependencyProperty DaysProperty = DependencyProperty.Register(nameof(Days),
                                                                                             typeof(bool),
                                                                                             typeof(PickTime),
                                                                                             new PropertyMetadata(false, DaysPropertyChanged));

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); PickTimeSp.Time = value; }
        }
        public bool Days
        {
            set { SetValue(DaysProperty, value); PickTimeSp.Days = value; }
        }


        public PickTimeSuport PickTimeSp { get; set; } 



        public PickTime()
        {
            PickTimeSp = new PickTimeSuport();

            PickTimeSp.TimeChanged += PickTimeSp_TimeChanged;

            InitializeComponent();
        }

        private void PickTimeSp_TimeChanged(object? sender, EventArgs e)
        {
            if(sender is TimeSpan)
            {
                Time = (TimeSpan)sender;
            }
        }

        private static void TimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PickTime pickTime)
            {
                TimeSpan newValue = (TimeSpan)e.NewValue;
                pickTime.Time = newValue;
            }
        }

        private static void DaysPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PickTime pickTime)
            {
                bool newValue1 = (bool)e.NewValue;
                pickTime.Days = newValue1;
            }
        }

       

        private void OpenPopup_Click(object sender, RoutedEventArgs e)
        {
            Popup_Picker.IsOpen = true;

        }

        private void ButtonClosePop(object sender, RoutedEventArgs e)
        {
            Popup_Picker.IsOpen = false;
        }

        private void ButtonListoPop(object sender, RoutedEventArgs e)
        {
            Popup_Picker.IsOpen = false;
            Time = PickTimeSp.Time;
        }

        private void ButtonNowPop(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan time = new TimeSpan(now.Hour, now.Minute, now.Second);

            Time = time;
        }
    }
}
