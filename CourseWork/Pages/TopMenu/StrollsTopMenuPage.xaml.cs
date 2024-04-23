using CourseWork.Components;
using CourseWork.Pages.CenterFrame;
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
    /// Логика взаимодействия для StrollsTopMenuPage.xaml
    /// </summary>
    public partial class StrollsTopMenuPage : Page
    {
        public StrollsTopMenuPage()
        {
            InitializeComponent();
        }

        private void ForestBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Services> services = App.db.Services.Where(x => x.Id == 5).ToList();
            if (App.Guest)
            {
                Navigations.NavigateCenterWindow(new WarningGuestPage());
            }
            else
            {
                Navigations.NavigateCenterWindow(new SignServicePage(services.First()));
            }
        }

        private void FieldBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Services> services = App.db.Services.Where(x => x.Id == 6).ToList();
            if (App.Guest)
            {
                Navigations.NavigateCenterWindow(new WarningGuestPage());
            }
            else
            {
                Navigations.NavigateCenterWindow(new SignServicePage(services.First()));
            }
        }

        private void AroundStableBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Services> services = App.db.Services.Where(x => x.Id == 7).ToList();
            if (App.Guest)
            {
                Navigations.NavigateCenterWindow(new WarningGuestPage());
            }
            else
            {
                Navigations.NavigateCenterWindow(new SignServicePage(services.First()));
            }
        }

        private void OneHourBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Services> services = App.db.Services.Where(x => x.Id == 8).ToList();
            if (App.Guest)
            {
                Navigations.NavigateCenterWindow(new WarningGuestPage());
            }
            else
            {
                Navigations.NavigateCenterWindow(new SignServicePage(services.First()));
            }
        }
    }
}
