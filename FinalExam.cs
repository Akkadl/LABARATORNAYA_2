namespace Lab2
{
    // Выпускной экзамен.
    // sealed - от этого класса нельзя наследоваться (бесплодный класс)
    public sealed class FinalExam : Exam
    {
        private string _specialty;

        public string Specialty
        {
            get => _specialty;
            set => _specialty = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public FinalExam(string name, string examiner, string specialty)
            : base(name, examiner)
        {
            Specialty = specialty;
        }

        // На выпускном экзамене требования строже: 75% от максимума
        public override int GetPassScore()
        {
            return GetMaxScore() * 75 / 100;
        }

        public override string GetRules()
        {
            return $"Final state exam, specialty {Specialty}, " +
                   $"examiner {Examiner}, pass at 75% of max score";
        }

        public override string ToString()
        {
            return base.ToString() + $", specialty: {Specialty}";
        }
    }
}
