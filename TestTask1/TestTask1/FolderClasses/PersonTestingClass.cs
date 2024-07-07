using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace TestTask1.FolderClasses
{
    internal class PersonTestingClass
    {
        static List<string> therapistCollection = new List<string>() { "насморк", "бронхит", "вирусы", "аллергия", "ангина", "бессонница", "cold", "bronchitis", "virus", "allergy", "quinsy", "insomnia" };
        static List<string> psychologistCollection = new List<string>() { "алкоголизм", "бессонница", "наркомания", "травмы", "alcoholism", "insomnia", "narcomania", "injury" };

        public static TestResult WeightTesting(int weight)
        {
            if (weight >= 75 && weight <= 90)
                return new TestResult() { name = "weight", result = 1 };

            if (weight >= 70 && weight < 75)
                return new TestResult() { name = "weight", result = 0, message = "Вес кандидата меньше 75 кг (удовлетворительно)" };

            if (weight > 90 && weight <= 100)
                return new TestResult() { name = "weight", result = 0, message = "Вес кандидата больше 90 кг (удовлетворительно)" };

            if (weight < 70)
                return new TestResult() { name = "weight", result = -1, message = "Вес кандидата меньше 70 кг (неудовлетворительно)" };

            return new TestResult() { name = "weight", result = -1, message = "Вес кандидата больше 100 кг (неудовлетворительно)" };
        }

        public static TestResult HeightTesting(int height)
        {
            if (height >= 170 && height <= 185)
                return new TestResult() { name = "height", result = 1 };

            if (height >= 160 && height < 170)
                return new TestResult() { name = "height", result = 0, message = "Рост кандидата меньше 170 см (удовлетворительно)" };

            if (height > 185 && height <= 190)
                return new TestResult() { name = "height", result = 0, message = "Рост кандидата больше 185 см (удовлетворительно)" };

            if (height < 160)
                return new TestResult() { name = "height", result = -1, message = "Рост кандидата меньше 160 см (неудовлетворительно)" };

            return new TestResult() { name = "height", result = -1, message = "Рост кандидата больше 190 см (неудовлетворительно)" };
        }

        public static TestResult AgeTesting(int age)
        {
            if (age >= 25 && age <= 35)
                return new TestResult() { name = "age", result = 1 };

            if (age >= 23 && age < 25)
                return new TestResult() { name = "age", result = 0, message = "Возраст кандидата меньше 25 лет (удовлетворительно)" };

            if (age > 35 && age <= 37)
                return new TestResult() { name = "age", result = 0, message = "Возраст кандидата больше 35 лет (удовлетворительно)" };

            if (age < 23)
                return new TestResult() { name = "age", result = -1, message = "Возраст кандидата меньше 23 лет (неудовлетворительно)" };

            return new TestResult() { name = "age", result = -1, message = "Возраст кандидата больше 37 лет (неудовлетворительно)" };
        }

        public static TestResult VisionTesting(double vision)
        {
            if (vision == 1.0)
                return new TestResult() { name = "vision", result = 1 };

            return new TestResult() { name = "vision", result = -1, message = "Зрение кандидата меньше 1 (неудовлетворительно)" };
        }

        public static TestResult TherapistTesting(List<string> values)
        {
            int count = 0;

            foreach (string illness in values)
                if (therapistCollection.Where(x => x.ToLower().Contains(illness.ToLower())).Count() > 0)
                    count++;

            if (count <= 2)
                return new TestResult() { name = "therapist", result = 1, counter = count };

            if (count == 3)
                return new TestResult() { name = "therapist", result = 0, message = "Терапевт - Количество болезней у кандидата 3 (удовлетворительно)", counter = count };

            return new TestResult() { name = "therapist", result = -1, message = "Терапевт - Количество болезней у кандидата больше 3 (неудовлетворительно)", counter = count };
        }

        public static TestResult PsychologistTesting(List<string> values)
        {
            int count = 0;

            foreach (string illness in values)
                if (psychologistCollection.Where(x => x.ToLower().Contains(illness.ToLower())).Count() > 0)
                    count++;

            if (count == 0)
                return new TestResult() { name = "psychologist", result = 1, counter = count };

            if (count == 1)
                return new TestResult() { name = "psychologist", result = 0, message = "Психиатр - Количество болезней у кандидата 1 (удовлетворительно)", counter = count };

            return new TestResult() { name = "psychologist", result = -1, message = "Психиатр - Количество болезней у кандидата больше 1 (неудовлетворительно)", counter = count };
        }

        public static TestResult SmokingTesting(List<string> values)
        {
            string flag = values.FirstOrDefault(x => x.ToLower().Contains("курение") || x.ToLower().Contains("курить") || x.ToLower().Contains("smoking"));

            if (flag == null)
                return new TestResult() { name = "smoking", result = 1 };

            return new TestResult() { name = "smoking", result = -1, message = "Кандидат курит (неудовлетворительно)" };
        }

        public static TestResult WeightAndBadHabits(PersonClass person)
        {
            bool smokingFlag = (person.Results.FirstOrDefault(x => x.name == "smoking") is TestResult resultSmoking) ? (resultSmoking.result == 1) : (SmokingTesting(person.HabitsAndIll).result == 1);
            bool illnessFlag = (person.Results.FirstOrDefault(x => x.name == "therapist") is TestResult resultTherapist) ? (resultTherapist.counter == 0) : (TherapistTesting(person.HabitsAndIll).counter == 0);
            bool weightFlag = person.Weight < 60 || person.Weight > 120;

            if (!smokingFlag && !illnessFlag && weightFlag)
                return new TestResult() { name = "weight and bad habits", result = -1, message = "Кандидат не прошел тест \"Вес и вредные привычки\" (неудовлетворительно)" };

            bool weightFlag2 = person.Weight > 110;
            bool otherParam = !smokingFlag || !illnessFlag || weightFlag;
            if (otherParam && weightFlag2)
                return new TestResult() { name = "weight and bad habits", result = 0, message = "Кандидат частично прошел тест \"Вес и вредные привычки\" (удовлетворительно)" };

            return new TestResult() { name = "weight and bad habits", result = 1 };
        }

        public static TestResult StrangeTesting(PersonClass person)
        {
            if (person.Name.ToLower()[0] == 'п')
                return new TestResult() { name = "strange", result = 1 };

            if (person.Age > 68)
                return new TestResult() { name = "strange", result = 0, message = "Кандидат частично прошел тест \"Странный\" (удовлетворительно)" };

            return new TestResult() { name = "strange", result = -1, message = "Кандидат не прошел тест \"Странный\" (неудовлетворительно)" };
        }

        public static TestResult MathTesting(PersonClass person)
        {
            bool heightFlag = (double)person.Height % 3 == 0;
            bool coldFlag = person.HabitsAndIll.Contains("насморк");
            if (heightFlag && coldFlag)
                return new TestResult() { name = "math", result = -1, message = "Кандидат не прошел тест \"Математический\" (неудовлетворительно)" };

            bool otherParam = heightFlag || coldFlag;
            bool heightFlag2 = (double)person.Height % 2 == 0;
            if (otherParam && heightFlag2)
                return new TestResult() { name = "math", result = 1 };

            return new TestResult() { name = "math", result = 0, message = "Кандидат частично прошел тест \"Математический\" (удовлетворительно)" };
        }

    }
}
