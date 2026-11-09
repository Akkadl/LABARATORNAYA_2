using System.Collections.Generic;

namespace Lab2
{
    // Испытание - общий абстрактный класс для теста и экзамена
    public abstract class Trial : IGradable
    {
        private string _name;

        // Композиция: испытание состоит из вопросов
        private List<Question> _questions = new List<Question>();

        public string Name
        {
            get => _name;
            set => _name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public int QuestionCount
        {
            get => _questions.Count;
        }

        protected Trial(string name)
        {
            Name = name;
        }

        public void AddQuestion(Question question)
        {
            if (question != null)
            {
                _questions.Add(question);
            }
        }

        // Максимальный балл - сумма баллов всех вопросов
        public virtual int GetMaxScore()
        {
            int sum = 0;
            foreach (Question question in _questions)
            {
                sum += question.Points;
            }
            return sum;
        }

        // Проходной балл у каждого вида испытания свой
        public abstract int GetPassScore();

        public bool IsPassed(int score)
        {
            return score >= GetPassScore();
        }

        // Правила проведения тоже зависят от вида испытания
        public virtual string GetRules()
        {
            return "General rules";
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, questions: {QuestionCount}, " +
                   $"max score: {GetMaxScore()}";
        }
    }
}
