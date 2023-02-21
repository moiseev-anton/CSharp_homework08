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

// Сорторовка по убыванию элементов каждой строки двумерного массива
void RowsSort(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = j + 1; k < arr.GetLength(1); k++)
            {
                if (arr[i,j] < arr[i,k])
                    {
                        int buffer = arr[i,j];
                        arr[i,j] = arr[i,k];
                        arr[i,k] = buffer;
                    }
            }
        }
    }
}


Clear();
int[,] matrix = GetMatrix(5, 4, 0, 30); // Массив 5 строк, 4 столбца, рандом [0; 30].
PrintMatrix(matrix);
WriteLine($"\nРезультат:");
RowsSort(matrix);
PrintMatrix(matrix);