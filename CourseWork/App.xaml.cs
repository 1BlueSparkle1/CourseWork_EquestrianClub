using CourseWork.Components;
using CourseWork.Сomponents;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool Admin = false;
        public static CourseWorkEntities1 db = new CourseWorkEntities1();
        public static bool Guest = false;
        public static Users ThisUser = new Users();
    }
}
