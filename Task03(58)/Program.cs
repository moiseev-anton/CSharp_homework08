// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

using System;
using static System.Console;

// Ввод натурального числа с консоли
int Prompt(string message)
{
    Write(message);
    int num = Convert.ToInt32(ReadLine()!);
    if (num < 1)  // Проверяем натуральное ли число введено
    {
        WriteLine("Введено не корректное значение");
        num = Prompt(message); // Если введено не натуральное число, программа предлагает повторить ввод.
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
    WriteLine(); // Это просто отступ от выведенной матрицы
}

// Умножение матриц
int[,] MatrixMultiplication(int[,] arr1, int[,] arr2)
{
    int[,] result = new int[arr1.GetLength(0), arr2.GetLength(1)];

    for (int i = 0; i < arr1.GetLength(0); i++) // Цикл перебирает строки матрицы А
    {
        for (int j = 0; j < arr2.GetLength(1); j++) // Цикл перебирает столбцы матрицы в
        {
            for (int k = 0; k < arr1.GetLength(1); k++) // Цикл перебирает столбцы матрицы А и строки матрицы В
            {
                result[i, j] += arr1[i, k] * arr2[k, j];
            }
        }
    }
    return result;
}


Clear();
WriteLine("A x B\nКолчесво столбцов матрицы А должно равнятся количеству строк матрицы B");
int rows1 = Prompt("Введите количесво строк матрицы А: ");
int columns1 = Prompt("Введите количесво столбцов матрицы А: ");
int rows2 = Prompt("Введите количесво строк матрицы В: ");
int columns2 = Prompt("Введите количесво столбцов матрицы В: ");

if (columns1 != rows2)
{
    WriteLine("Такие матрицы не могут быть перемножены");
    return;
}

int[,] matrixA = GetMatrix(rows1, columns1, 1, 9); // Рандом [1; 9].
PrintMatrix(matrixA);
int[,] matrixB = GetMatrix(rows2, columns2, 1, 9); // Рандом [1; 9].
PrintMatrix(matrixB);
int[,] matrixAB = MatrixMultiplication(matrixA, matrixB);
WriteLine("Результирующая матрица:");
PrintMatrix(matrixAB);