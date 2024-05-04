using CourseWork.Pages;
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

namespace CourseWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //объявление что MainWindow на страницах это это окно
            Navigations.mainWindow = this;
            AuthorizationPage.mainWindow = this;
            //Сокрытие бокового и верхнего меню и иконки уведомлений
            LeftMenuFrame.Visibility = Visibility.Collapsed;
            TopMenuFrame.Visibility = Visibility.Collapsed;
            NotificationsBtn.Visibility = Visibility.Collapsed;
            //Открытие страницы авторизации
            AllWindowFrame.Navigate(new AuthorizationPage());
        }
    }
}
