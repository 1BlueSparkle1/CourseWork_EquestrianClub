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

            //определяем, что контекст данных у элемента horses
            this.DataContext = horses;

            //заполнение блоков сложными данными(которые надо объединять или преобразовывать)
            MonikerTb.Text = "Кличка:" + horses.Moniker;
            GenderTb.Text = "Пол: " + horses.HorseGender.Title;
            BreedTb.Text = "Порода: " + horses.Breeds.Title;
            DateOfBirthdayTb.Text = horses.DateOfBirthday.Date.ToString().Remove(horses.DateOfBirthday.Date.ToString().Length-8);
            string train = "";
            foreach (var item in horses.LevelTrainingHorses.ToList())
            {
                train += item.LevelTraining.Title + ", ";
            }
            LevelTrainingTb.Text = $"Уровни подготовки: {train.Remove(train.Length - 2)}.";
        }
    }
}
