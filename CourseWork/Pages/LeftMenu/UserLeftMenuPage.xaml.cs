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

namespace CourseWork.Pages.LeftMenu
{
    /// <summary>
    /// Логика взаимодействия для UserLeftMenuPage.xaml
    /// </summary>
    public partial class UserLeftMenuPage : Page
    {
        public UserLeftMenuPage()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigations.NavigateVisibleFrame(false);
            Navigations.NavigateAllWindow(new AuthorizationPage());
        }
    }
}
