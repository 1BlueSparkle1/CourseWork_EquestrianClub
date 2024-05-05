﻿using CourseWork.Pages.CenterFrame;
using CourseWork.Сomponents;
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

namespace CourseWork.Pages.TopMenu
{
    /// <summary>
    /// Логика взаимодействия для InfoRecreationTopMenuPage.xaml
    /// </summary>
    public partial class DopInfoTopMenuPage : Page
    {
        public DopInfoTopMenuPage()
        {
            InitializeComponent();
        }

        private void TrainersBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateCenterWindow(new ListTrainersPage());
        }
    }
}
