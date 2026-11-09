using System;

namespace Lab2
{
    // Статический класс с методами расширения
    public static class MyExtensions
    {
        // Для string: считаем слова, которые начинаются с заглавной буквы
        public static int CountCapitalWords(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            // Делим текст на слова по пробелам и знакам препинания
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':' };
            string[] words = text.Split(separators,
                                        StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            foreach (string word in words)
            {
                if (char.IsUpper(word[0]))
                {
                    count++;
                }
            }
            return count;
        }

        // Для MyList: есть ли в списке повторяющиеся элементы
        public static bool HasDuplicates(this MyList list)
        {
            // Каждый элемент сравниваем со всеми, что стоят после него
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
