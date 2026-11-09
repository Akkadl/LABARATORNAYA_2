namespace Lab2
{
    // Всё, что можно сдать и оценить баллами
    public interface IGradable
    {
        // Минимальный балл, при котором испытание считается сданным
        int GetPassScore();

        // Сдано ли испытание при таком балле
        bool IsPassed(int score);
    }
}
