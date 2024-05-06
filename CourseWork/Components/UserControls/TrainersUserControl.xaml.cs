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
    /// Логика взаимодействия для TrainersUserControl.xaml
    /// </summary>
    public partial class TrainersUserControl : UserControl
    {
        public static Users trainer;
        public TrainersUserControl(Users _trainer)
        {
            InitializeComponent();
            trainer = _trainer;
            FullNameTb.Text = $"ФИО: {trainer.FullName}";
            DateTime birth = (DateTime)trainer.DateOfBirthday;
            int age = DateTime.Now.Year - birth.Year;
            if ( age.ToString().ToList().ElementAt(age.ToString().ToList().Count()-1) == 0 || age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == 5 || 
                age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == 6 || age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == 7 || 
                age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == 8 || age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == 9 || 
                age == 11 || age == 12 || age == 13 || age == 14)
            {
                AgeTb.Text = $"Возраст: {age} лет";
            }
            else if (age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == 1)
            {
                AgeTb.Text = $"Возраст: {age} год";
            }
            else if (age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == '2' || age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == '3'
                || age.ToString().ToList().ElementAt(age.ToString().ToList().Count() - 1) == '4')
            {
                AgeTb.Text = $"Возраст: {age} года";
            }

            string train = "";
            foreach (var item in trainer.LevelTrainingUsers.ToList())
            {
                train += item.LevelTraining.Title + ", ";
            }
            if (train == "")
            {
                LevelTrainTb.Text = $"Уровни подготовки: Неизвестно";
            }
            else
            {
                LevelTrainTb.Text = $"Уровни подготовки: {train.Remove(train.Length - 2)}.";
            }

            
        }
    }
}
