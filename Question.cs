using System;

namespace Lab2
{
    // Вопрос, который входит в тест или экзамен.
    // Здесь переопределены все методы Object, которые можно переопределить:
    // ToString, Equals и GetHashCode.
    public class Question
    {
        private string _text;
        private int _points;

        public string Text
        {
            get => _text;
            set => _text = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public int Points
        {
            get => _points;
            set => _points = value > 0 ? value : 0;
        }

        public Question(string text, int points)
        {
            Text = text;
            Points = points;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Text} ({Points} pts)";
        }

        // Два вопроса равны, если совпадают текст и баллы
        public override bool Equals(object obj)
        {
            Question other = obj as Question;
            if (other == null)
            {
                return false;
            }
            return Text == other.Text && Points == other.Points;
        }

        // Равные объекты должны давать одинаковый хеш-код
        public override int GetHashCode()
        {
            return HashCode.Combine(Text, Points);
        }
    }
}
