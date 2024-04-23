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
    /// Логика взаимодействия для TrainingTopMenuPage.xaml
    /// </summary>
    public partial class TrainingTopMenuPage : Page
    {
        public TrainingTopMenuPage()
        {
            InitializeComponent();
        }

        private void PonyTrainBtn_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Services> services = App.db.Services.Where(x => x.Id == 1).ToList();
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
