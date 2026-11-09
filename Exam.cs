namespace Lab2
{
    // Экзамен: устный, его принимает экзаменатор
    public class Exam : Trial
    {
        private string _examiner;

        public string Examiner
        {
            get => _examiner;
            set => _examiner = string.IsNullOrWhiteSpace(value) ? "Unknown" : value;
        }

        public Exam(string name, string examiner) : base(name)
        {
            Examiner = examiner;
        }

        // Для экзамена нужно набрать половину баллов
        public override int GetPassScore()
        {
            return GetMaxScore() / 2;
        }

        public override string GetRules()
        {
            return $"Oral exam, examiner {Examiner}, pass at 50% of max score";
        }

        public override string ToString()
        {
            return base.ToString() + $", examiner: {Examiner}";
        }
    }
}
