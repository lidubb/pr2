/*using System;
using System.Globalization;

namespace z1
{
    internal class Program
    {
        static int ReadInt(string prompt, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v) && v >= min)
                    return v;
                Console.WriteLine("Ошибка: введите целое число" +
                    (min == int.MinValue ? "." : $" не меньше {min}."));
            }
        }

        static void Main(string[] args)
        {
            int n = ReadInt("Введите размер массива N: ", 1);
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = ReadInt($"Элемент {i + 1}: ");
            }

            Console.Write("Массив в обратном порядке: ");
            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            double sum = 0;
            for (int i = 0; i < n; i++)
                sum += array[i];
            double average = sum / n;
            int closest = array[0];
            double minDiff = Math.Abs(array[0] - average);
            for (int i = 1; i < n; i++)
            {
                double diff = Math.Abs(array[i] - average);
                if (diff < minDiff)
                {
                    minDiff = diff;
                    closest = array[i];
                }
            }

            Console.WriteLine($"Среднее арифметическое: {average.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Ближайшее к среднему число: {closest}");
        }
    }
}*/

/*using System;

namespace z2
{
    internal class Program
    {
        static int ReadInt(string prompt, int min = int.MinValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v) && v >= min)
                    return v;
                Console.WriteLine("Ошибка: введите целое число" +
                    (min == int.MinValue ? "." : $" не меньше {min}."));
            }
        }

        static void Main(string[] args)
        {
            int n = ReadInt("Введите количество студентов n: ", 1);
            int m = ReadInt("Введите количество предметов m: ", 1);

            int[,] grades = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Студент {i + 1}:");
                for (int j = 0; j < m; j++)
                {
                    grades[i, j] = ReadInt($"  Оценка по предмету {j + 1}: ");
                }
            }

            Console.WriteLine("Средние оценки:");
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < m; j++)
                    sum += grades[i, j];

                Console.WriteLine($"Студент {i + 1}: {sum / m:F2}");
            }
        }
    }
}*/

/*using System;
using System.Collections.Generic;

namespace z3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Вводите числа. Ввод закончится, когда число повторится.");

            while (true)
            {
                Console.Write("Число: ");
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("Ошибка: введите целое число.");
                    continue;
                }

                if (numbers.Contains(value))
                {
                    Console.WriteLine($"Число {value} уже есть в массиве. Ввод завершён.");
                    break;
                }

                numbers.Add(value);
            }

            Console.WriteLine("Массив чисел: " + string.Join(" ", numbers));
        }
    }
}*/

/*using System;
using System.Collections.Generic;

namespace z4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            Console.WriteLine("Телефонная книга. Команды: добавить, найти, показать, выход");

            while (true)
            {
                Console.Write("\nВведите команду: ");
                string command = (Console.ReadLine() ?? "").Trim().ToLower();

                if (command == "выход")
                {
                    Console.WriteLine("Работа программы завершена.");
                    break;
                }

                switch (command)
                {
                    case "добавить":
                        Console.Write("Имя: ");
                        string name = (Console.ReadLine() ?? "").Trim();
                        if (name == "")
                        {
                            Console.WriteLine("Имя не может быть пустым.");
                            break;
                        }

                        Console.Write("Номер телефона: ");
                        string phone = (Console.ReadLine() ?? "").Trim();

                        if (contacts.ContainsKey(name))
                        {
                            Console.WriteLine($"Контакт «{name}» уже есть, номер будет обновлён.");
                        }
                        contacts[name] = phone;
                        Console.WriteLine($"Сохранено: {name}:{phone}");
                        break;

                    case "найти":
                        Console.Write("Введите имя для поиска: ");
                        string search = (Console.ReadLine() ?? "").Trim();

                        if (contacts.TryGetValue(search, out string found))
                            Console.WriteLine($"{search}:{found}");
                        else
                            Console.WriteLine("Контакт не найден.");
                        break;

                    case "показать":
                        if (contacts.Count == 0)
                        {
                            Console.WriteLine("Телефонная книга пуста.");
                            break;
                        }
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine($"{contact.Key}:{contact.Value}");
                        }
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда. Доступно: добавить, найти, показать, выход");
                        break;
                }
            }
        }
    }
}*/

/*using System;
using System.Collections.Generic;

namespace z5
{
    internal class Program
    {
        static void PrintDictionary(Dictionary<string, int> dict)
        {
            List<string> items = new List<string>();
            foreach (var pair in dict)
            {
                items.Add($"{pair.Key}:{pair.Value}");
            }
            Console.WriteLine("{" + string.Join(", ", items) + "}");
        }

        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            Console.WriteLine("Вводите слова (например, яблоко, банан). Для завершения введите «выход».");

            while (true)
            {
                Console.Write("Слово: ");
                string word = (Console.ReadLine() ?? "").Trim();

                if (word.ToLower() == "выход")
                    break;

                if (word == "")
                {
                    Console.WriteLine("Пустое слово не добавляется.");
                    continue;
                }

                if (words.ContainsKey(word))
                {
                    words[word]++;
                    Console.WriteLine($"«{word}» уже есть в словаре, счётчик увеличен.");
                }
                else
                {
                    words.Add(word, 1);
                    Console.WriteLine($"«{word}» добавлено в словарь.");
                }

                PrintDictionary(words);
            }

            Console.WriteLine("Итоговый словарь:");
            PrintDictionary(words);
        }
    }
}*/