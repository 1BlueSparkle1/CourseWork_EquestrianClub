﻿using CourseWork.Components;
using CourseWork.Components.UserControls;
using System;
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

namespace CourseWork.Pages.CenterFrame
{
    /// <summary>
    /// Логика взаимодействия для ListTrainersPage.xaml
    /// </summary>
    public partial class ListTrainersPage : Page
    {
        public ListTrainersPage()
        {
            InitializeComponent();
            IEnumerable<Users> trainers = App.db.Users.Where(x => x.PositionId == 2).ToList();
            foreach (var user in trainers)
            {
                ListTrainWp.Children.Add(new TrainersUserControl(user));
            }
        }
    }
}
