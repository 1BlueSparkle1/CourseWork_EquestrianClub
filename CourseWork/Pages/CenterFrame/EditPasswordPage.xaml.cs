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

        //нажатие кнопки смены пароля
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            //если поля не заполнены
            if (string.IsNullOrEmpty(OldPassPb.Password) || string.IsNullOrEmpty(NewPasPb.Password))
            {
                //выводится сообщение с ошибкой
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            //если старый вводимый пароль не совпадает с паролем пользователя
            else if (Md5Class.hashPassword(OldPassPb.Password) != App.ThisUser.Password)
            {
                //выводится сообщение с ошибкой
                MessageBox.Show("Старый пароль не совпадает!");
            }
            //если новый и старый пароль введены одинакого
            else if (OldPassPb.Password == NewPasPb.Password)
            {
                //выводится сообщение с ошибкой
                MessageBox.Show("Старый и новый пароль не должны совпадать!");
            }
            //если ошибок нет
            else
            {
                //изменяем пароль пользователя
                App.ThisUser.Password = Md5Class.hashPassword(NewPasPb.Password);
                //сохраняем в бд
                App.db.SaveChanges();
                //уведомляем об этом
                MessageBox.Show("Пароль изменен!");
                //возвращаемся на прошлую страницу
                NavigationService.GoBack();
            }
        }
    }
}
