// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

// Заполнение двумерного массива по спирали
int[,] GetSpiralMatrix(int row, int column)
{
    int[,] result = new int[row, column];

    result[0, 0] = 1; // Сразу заполняем первый элемент
    int num = 2;
    int i = 0, j = 0;
    int count = 1; // Счетчик будет показывать насколько надо отступать от "границ" массива при прохождении каждого "витка спирали"

    while (num <= row * column) // Если спираль не заполнена, переходим к новому "витку"
    {
        while (j < column - count) // Заполнение верхней строки (вправо)
        {
            j++;
            result[i, j] = num; // Это можно записать как result[i, ++j] = num++;
            num++;
        }
        while (i < row - count) // Заполнение правого столбца (вниз)
        {
            i++;
            result[i, j] = num;
            num++;
        }
        while (j > -1 + count) // Заполнение нижней строки (влево)
        {
            j--;
            result[i, j] = num;
            num++;
        }
        while (i > count) // Заполнение левого столбца (вверх). Здесь на одну итерацию меньше потому что "последний" верхний элемент уже заполнен
        {
            i--;
            result[i, j] = num;
            num++;
        }
        count++; // Счетчик считает насколько мы отступаем от "границ" массива при прохождении каждого "витка спирали"
    }

    return result;
}


int m = Prompt("Введите количество строк: ");
int n = Prompt("Введите количество столбцов: ");
int[,] matrix = GetSpiralMatrix(m, n);
PrintMatrix(matrix);