using Xunit;
using Lab2; 

namespace Lab2.Tests
{
    public class MyListTests
    {
        // ТЕСТИРОВАНИЕ ПЕРЕГРУЖЕННЫХ ОПЕРАЦИЙ

        [Fact]
        public void Plus_AddsItemToStart()
        {
            MyList list = new MyList(2, 3);
            MyList result = 1 + list;
            Assert.True(result == new MyList(1, 2, 3));
        }

        [Fact]
        public void Plus_DoesNotChangeOriginalList()
        {
            MyList list = new MyList(2, 3);
            MyList result = 1 + list;
            Assert.Equal(2, list.Count);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Decrement_RemovesFirstElement()
        {
            MyList list = new MyList(1, 2, 3);
            --list;
            Assert.True(list == new MyList(2, 3));
        }

        [Fact]
        public void Decrement_EmptyList_StaysEmpty()
        {
            MyList list = new MyList();
            --list;
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Equality_SameElements_ReturnsTrue()
        {
            MyList first = new MyList(1, 2, 3);
            MyList second = new MyList(1, 2, 3);
            Assert.True(first == second);
            Assert.False(first != second);
        }

        [Fact]
        public void NotEqual_DifferentElements_ReturnsTrue()
        {
            MyList first = new MyList(1, 2, 3);
            MyList second = new MyList(1, 2, 4);
            Assert.True(first != second);
        }

        [Fact]
        public void Multiply_JoinsTwoLists()
        {
            MyList first = new MyList(1, 2);
            MyList second = new MyList(3);
            MyList result = first * second;
            Assert.True(result == new MyList(1, 2, 3));
        }

        [Fact]
        public void Indexer_ReadAndWrite()
        {
            MyList list = new MyList(5, 6, 7);
            list[1] = 60;
            Assert.Equal(5, list[0]);
            Assert.Equal(60, list[1]);
        }

        // ТЕСТИРОВАНИЕ МЕТОДОВ РАСШИРЕНИЯ

        [Fact]
        public void CountCapitalWords_ReturnsThree()
        {
            int count = "Hello world From Novosibirsk".CountCapitalWords();
            Assert.Equal(3, count);
        }

        [Fact]
        public void CountCapitalWords_EmptyString_ReturnsZero()
        {
            Assert.Equal(0, "".CountCapitalWords());
        }

        [Fact]
        public void HasDuplicates_WithDuplicates_ReturnsTrue()
        {
            MyList list = new MyList(1, 2, 3, 2);
            Assert.True(list.HasDuplicates());
        }

        [Fact]
        public void HasDuplicates_AllDifferent_ReturnsFalse()
        {
            MyList list = new MyList(1, 2, 3);
            Assert.False(list.HasDuplicates());
        }
    }

    public class TrialTests
    {
        private Test CreateTest()
        {
            Test test = new Test("C# basics", 40);
            test.AddQuestion(new Question("Q1", 10));
            test.AddQuestion(new Question("Q2", 10));
            test.AddQuestion(new Question("Q3", 10));
            return test;
        }

        private Exam CreateExam()
        {
            Exam exam = new Exam("Algorithms", "Ivanov");
            exam.AddQuestion(new Question("Q1", 20));
            exam.AddQuestion(new Question("Q2", 30));
            return exam;
        }

        [Fact]
        public void Test_ToString_ContainsTypeAndValues()
        {
            string text = CreateTest().ToString();
            Assert.Contains("Test: C# basics", text);
            Assert.Contains("questions: 3", text);
            Assert.Contains("max score: 30", text);
            Assert.Contains("time limit: 40 min", text);
        }

        [Fact]
        public void Exam_ToString_ContainsExaminer()
        {
            string text = CreateExam().ToString();
            Assert.Contains("Exam: Algorithms", text);
            Assert.Contains("examiner: Ivanov", text);
        }

        [Fact]
        public void GetMaxScore_SumsQuestionPoints()
        {
            Assert.Equal(30, CreateTest().GetMaxScore());
            Assert.Equal(50, CreateExam().GetMaxScore());
        }

        [Fact]
        public void Test_IsPassed_CheckBoundary()
        {
            Test test = CreateTest();
            Assert.Equal(18, test.GetPassScore());
            Assert.True(test.IsPassed(18));
            Assert.False(test.IsPassed(17));
        }

        [Fact]
        public void Exam_PassScore_IsHalfOfMax()
        {
            Assert.Equal(25, CreateExam().GetPassScore());
        }

        [Fact]
        public void FinalExam_PassScore_IsSeventyFivePercent()
        {
            FinalExam finalExam = new FinalExam("State exam", "Petrov", "Software");
            finalExam.AddQuestion(new Question("Q1", 100));
            Assert.Equal(75, finalExam.GetPassScore());
        }

        [Fact]
        public void Polymorphism_GetRulesUsesDerivedClass()
        {
            Trial trial = CreateExam();
            Assert.Contains("Oral exam", trial.GetRules());
        }

        [Fact]
        public void FinalExam_IsSealed()
        {
            Assert.True(typeof(FinalExam).IsSealed);
        }

        [Fact]
        public void Question_Equals_SameTextAndPoints()
        {
            Question first = new Question("What is a class?", 10);
            Question second = new Question("What is a class?", 10);
            Assert.True(first.Equals(second));
            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        [Fact]
        public void Question_EmptyText_BecomesUnknown()
        {
            Question question = new Question("", 5);
            Assert.Equal("Unknown", question.Text);
        }

        [Fact]
        public void Test_WrongTimeLimit_BecomesDefault()
        {
            Test test = new Test("Quiz", -5);
            Assert.Equal(30, test.TimeLimitMinutes);
        }
    }
}
