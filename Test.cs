namespace Lab2
{
    // Тест: письменный, ограничен по времени
    public class Test : Trial
    {
        private int _timeLimitMinutes;

        public int TimeLimitMinutes
        {
            get => _timeLimitMinutes;
            // Если время указано неверно, берём 30 минут по умолчанию
            set => _timeLimitMinutes = value > 0 ? value : 30;
        }

        public Test(string name, int timeLimitMinutes) : base(name)
        {
            TimeLimitMinutes = timeLimitMinutes;
        }

        // Для теста нужно набрать 60% от максимума
        public override int GetPassScore()
        {
            return GetMaxScore() * 60 / 100;
        }

        public override string GetRules()
        {
            return $"Written test, time limit {TimeLimitMinutes} min, " +
                   "pass at 60% of max score";
        }

        public override string ToString()
        {
            return base.ToString() + $", time limit: {TimeLimitMinutes} min";
        }
    }
}
