﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HorseInfoUserControl.xaml
    /// </summary>
    public partial class HorseInfoUserControl : UserControl
    {
        public HorseInfoUserControl(Horses horses)
        {
            InitializeComponent();
            this.DataContext = horses;
            MonikerTb.Text = "Кличка:" + horses.Moniker;
            GenderTb.Text = "Пол: " + horses.HorseGender.Title;
            DateOfBirthdayTb.Text = horses.DateOfBirthday.ToString();
            LevelTrainingTb.Text = horses.LevelTraining.Title;
            DescriptionTb.Text = horses.Description;
        }
    }
}