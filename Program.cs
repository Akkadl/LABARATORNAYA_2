using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Part1Demo();
            Console.WriteLine();
            Part2Demo();
        }

        // Часть 1: проверяем перегруженные операции и методы расширения
        static void Part1Demo()
        {
            Console.WriteLine("--- PART 1: MyList ---");

            MyList a = new MyList(1, 2, 3);
            MyList b = new MyList(3, 4);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);

            // item + list
            Console.WriteLine("5 + a = " + (5 + a));

            // --list (берём отдельный список, чтобы a не менялся)
            MyList c = new MyList(7, 8, 9);
            --c;
            Console.WriteLine("--c = " + c);

            // объединение списков
            MyList union = a * b;
            Console.WriteLine("a * b = " + union);

            // сравнение и индексатор
            Console.WriteLine("a == b: " + (a == b));
            Console.WriteLine("a != b: " + (a != b));
            Console.WriteLine("a[1] = " + a[1]);

            // методы расширения
            Console.WriteLine("a has duplicates: " + a.HasDuplicates());
            Console.WriteLine("a * b has duplicates: " + union.HasDuplicates());

            string text = "Hello world From Novosibirsk";
            int count = text.CountCapitalWords();
            Console.WriteLine("Capital words in \"" + text + "\": " + count);
        }

        // Часть 2: иерархия классов и полиморфизм
        static void Part2Demo()
        {
            Console.WriteLine("--- PART 2: Trials ---");

            Test test = new Test("C# basics", 40);
            test.AddQuestion(new Question("What is a class?", 10));
            test.AddQuestion(new Question("What is inheritance?", 10));
            test.AddQuestion(new Question("What is polymorphism?", 10));

            Exam exam = new Exam("Algorithms", "Ivanov");
            exam.AddQuestion(new Question("Explain quick sort", 20));
            exam.AddQuestion(new Question("Explain binary search trees", 30));

            FinalExam finalExam =
                new FinalExam("State exam", "Petrov", "Software Engineering");
            finalExam.AddQuestion(new Question("Describe your thesis", 30));
            finalExam.AddQuestion(new Question("Explain design patterns", 30));
            finalExam.AddQuestion(new Question("Explain databases", 40));

            // Массив ссылок на базовый класс, а объекты в нём разных типов
            Trial[] trials = { test, exam, finalExam };

            foreach (Trial trial in trials)
            {
                // Вызовутся переопределённые методы нужного класса
                Console.WriteLine(trial.ToString());
                Console.WriteLine("  Rules: " + trial.GetRules());
                Console.WriteLine("  Pass score: " + trial.GetPassScore());
            }

            Console.WriteLine("Test, score 18 passed: " + test.IsPassed(18));
            Console.WriteLine("Test, score 17 passed: " + test.IsPassed(17));

            // Question: переопределены все методы Object
            Question q1 = new Question("What is a class?", 10);
            Question q2 = new Question("What is a class?", 10);
            Console.WriteLine(q1.ToString());
            Console.WriteLine("ReferenceEquals: " + ReferenceEquals(q1, q2));
            Console.WriteLine("q1.Equals(q2): " + q1.Equals(q2));
            bool sameHash = q1.GetHashCode() == q2.GetHashCode();
            Console.WriteLine("Same hash code: " + sameHash);
        }
    }
}
