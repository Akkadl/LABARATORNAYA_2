using System;
using System.Collections.Generic;

namespace Lab2
{
    // Список целых чисел с перегруженными операциями
    public class MyList
    {
        // Сами элементы лежат во внутреннем списке
        private List<int> _items;

        public MyList(params int[] items)
        {
            _items = new List<int>(items);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        // Индексатор: обращаемся к элементу по номеру, как в массиве
        public int this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        // Копия списка, чтобы операции не портили исходные данные
        private MyList Copy()
        {
            return new MyList(_items.ToArray());
        }

        // item + list: новый список, в котором item стоит первым
        public static MyList operator +(int item, MyList list)
        {
            MyList result = list.Copy();
            result._items.Insert(0, item);
            return result;
        }

        // --list: убираем первый элемент (в пустом списке ничего не делаем)
        public static MyList operator --(MyList list)
        {
            MyList result = list.Copy();
            if (result.Count > 0)
            {
                result._items.RemoveAt(0);
            }
            return result;
        }

        // first * second: объединение, сначала элементы первого, потом второго
        public static MyList operator *(MyList first, MyList second)
        {
            MyList result = first.Copy();
            result._items.AddRange(second._items);
            return result;
        }

        // Списки равны, если элементы совпадают и идут в том же порядке
        public static bool operator ==(MyList first, MyList second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }
            if (first.Count != second.Count)
            {
                return false;
            }
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }

        // != всегда делаем парой к ==
        public static bool operator !=(MyList first, MyList second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            return this == (obj as MyList);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            foreach (int item in _items)
            {
                hash.Add(item);
            }
            return hash.ToHashCode();
        }

        // Вид строки: [1, 2, 3]
        public override string ToString()
        {
            return "[" + string.Join(", ", _items) + "]";
        }
    }
}
