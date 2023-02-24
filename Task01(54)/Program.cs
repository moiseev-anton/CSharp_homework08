// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

using System;
using static System.Console;


// Ввод натурального числа с консоли
int Prompt(string message)
{
    Write(message);
    int num = Convert.ToInt32(ReadLine()!);
    if (num < 1) // Проверяем натуральное ли число введено
    {
        WriteLine("Введено не корректное значение");
        num = Prompt(message); // Если введено не натуральное число, программа предлагает повторить ввод
    }
    return num;
}

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

// Сортировка по убыванию элементов в каждой строке двумерного массива
void RowsSort(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++) // Этим циклом переключаемся между строками
    {
        for (int j = 0; j < arr.GetLength(1); j++) // Этим циклом выбираем элемент строки
        {
            for (int k = j + 1; k < arr.GetLength(1); k++) // Этим циклом проходим по элементам в строке, следующим за выбранным. Производим сортировку
            {
                if (arr[i, j] < arr[i, k])
                {
                    int buffer = arr[i, j];
                    arr[i, j] = arr[i, k];
                    arr[i, k] = buffer;
                }
            }
        }
    }
}


Clear();
int m = Prompt("Введите количество строк: ");
int n = Prompt("Введите количество столбцов: ");
int[,] matrix = GetMatrix(m, n, 0, 30); // Рандом [0; 30].
PrintMatrix(matrix);
WriteLine($"\nРезультат:");
RowsSort(matrix);
PrintMatrix(matrix);