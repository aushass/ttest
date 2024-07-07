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
using TestTask1.FolderClasses;

namespace TestTask1.FolderPages
{
    /// <summary>
    /// Логика взаимодействия для PageForm.xaml
    /// </summary>
    public partial class PageForm : Page
    {
        public PageForm()
        {
            InitializeComponent();
        }

        private void TBxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckParams("name");
        }

        private void TBxWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckParams("weight");
        }

        private void TBxHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckParams("height");
        }

        private void TBxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckParams("age");
        }

        private void TBxVision_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckParams("vision");
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (CheckParams(null))
            {
                PersonClass person = new PersonClass()
                {
                    Name = TBxName.Text,
                    Weight = Convert.ToInt32(TBxWeight.Text),
                    Height = Convert.ToInt32(TBxHeight.Text),
                    Age = Convert.ToInt32(TBxAge.Text),
                    Vision = Convert.ToDouble(TBxVision.Text.Replace(".", ",")),
                    HabitsAndIll = (string.IsNullOrWhiteSpace(TBxHabitsAndIll.Text)) ? new List<string>() : TBxHabitsAndIll.Text.ToLower().Split(' ').ToList()
                };

                string message = PersonTesting(person);
                MessageBox.Show(message);
                switch (MessageBox.Show("Хотите протестировать других кандидатов?", "", MessageBoxButton.YesNo))
                {
                    case MessageBoxResult.Yes:
                        {
                            FrameClass.MainFrame.Navigate(new PageForm());
                            break;
                        }
                    default:
                        {
                            System.Windows.Application.Current.Shutdown();
                            break;
                        }
                }
            }
        }

        private string PersonTesting(PersonClass person)
        {
            person.Results.Add(PersonTestingClass.WeightTesting(person.Weight));
            person.Results.Add(PersonTestingClass.HeightTesting(person.Height));
            person.Results.Add(PersonTestingClass.AgeTesting(person.Age));
            person.Results.Add(PersonTestingClass.VisionTesting(person.Vision));
            person.Results.Add(PersonTestingClass.TherapistTesting(person.HabitsAndIll));
            person.Results.Add(PersonTestingClass.PsychologistTesting(person.HabitsAndIll));
            person.Results.Add(PersonTestingClass.SmokingTesting(person.HabitsAndIll));
            person.Results.Add(PersonTestingClass.WeightAndBadHabits(person));
            person.Results.Add(PersonTestingClass.StrangeTesting(person));
            person.Results.Add(PersonTestingClass.MathTesting(person));

            if (person.Results.Where(x => x.result == -1).Count() >= 1 || person.Results.Where(x => x.result == 0).Count() >= 3)
            {
                string message = $"Кандидат {person.Name} не прошел тестирование.\nПроблемы:";
                foreach (TestResult problem in person.Results.Where(x => x.result != 1))
                    message += $"\n* {problem.message}";
                return message;
            }
            else
            {
                return $"Кандидат {person.Name} подходит";
            }
        }

        private bool CheckParams(string paramName)
        {
            bool flag = true;

            if (paramName == "name" || paramName == null)
                flag = (ChecksParamDataClass.StringIsNotEmpty(TBxName.Text, TBkName) == false) ? false : flag;

            if (paramName == "weight" || paramName == null)
                flag = (ChecksParamDataClass.StringIsIntegerMoreZero(TBxWeight.Text, TBkWeight) == false) ? false : flag;

            if (paramName == "height" || paramName == null)
                flag = (ChecksParamDataClass.StringIsIntegerMoreZero(TBxHeight.Text, TBkHeight) == false) ? false : flag;

            if (paramName == "age" || paramName == null)
                flag = (ChecksParamDataClass.StringIsIntegerMoreZero(TBxAge.Text, TBkAge) == false) ? false : flag;

            if (paramName == "vision" || paramName == null)
                flag = (ChecksParamDataClass.StringIsRealMoreZeroLessOne(TBxVision.Text, TBkVision) == false) ? false : flag;

            return flag;
        }
    }
}
