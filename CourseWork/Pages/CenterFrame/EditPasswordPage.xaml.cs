using CourseWork.Components;
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
    /// Логика взаимодействия для EditPasswordPage.xaml
    /// </summary>
    public partial class EditPasswordPage : Page
    {
        public EditPasswordPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(OldPassPb.Password) || string.IsNullOrEmpty(NewPasPb.Password))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else if (Md5Class.hashPassword(OldPassPb.Password) != App.ThisUser.Password)
            {
                MessageBox.Show("Старый пароль не совпадает!");
            }
            else if (OldPassPb.Password == NewPasPb.Password)
            {
                MessageBox.Show("Старый и новый пароль не должны совпадать!");
            }
            else
            {
                App.ThisUser.Password = Md5Class.hashPassword(NewPasPb.Password);
                App.db.SaveChanges();
                MessageBox.Show("Пароль изменен!");
                NavigationService.GoBack();
            }
        }
    }
}
