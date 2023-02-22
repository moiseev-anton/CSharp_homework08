// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт 
// номер строки с наименьшей суммой элементов: 1 строка

using System;
using static System.Console;


// Заполнение двумерного массива
int[,] GetMatrix(int m, int n, int minVal, int maxVal)
{
    int[,] result = new int[m, n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minVal, maxVal + 1);
        }
    }
    return result;
}

// Вывод двумерного массива
void PrintMatrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] >= 0)
                Write(" ");
            Write($"{array[i, j]} \t");
        }
        WriteLine();
    }
}

// Поиск строки с минимальной суммой
string FindMinSumRow(int[,] arr)
{
    string result = String.Empty;
    int min = 0;

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int sum = 0;

        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[i, j]; // Суммируем элементы в i-й строке
        }

        WriteLine($"{i + 1} -> {sum}"); // Вывод суммы для удобства проверки

        if (i == 0 || sum < min)
        {
            min = sum; 
            result = Convert.ToString(i + 1);
        }
        else if (sum == min) // Дополнительная проверка если окажется несколько строк с минимальным значением
            result += ", " + Convert.ToString(i + 1);
    }
    return result;
}


Clear();
int[,] matrix = GetMatrix(5, 3, 1, 9); // Массив 5 строк, 3 столбца, рандом [1; 9].
PrintMatrix(matrix);
WriteLine("\nСуммы по строкам:");
string minRow = FindMinSumRow(matrix);
WriteLine($"\nНомер(а) строк(и) с наименьшей суммой элементов: {minRow}");