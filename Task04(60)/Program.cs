// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

using System;
using static System.Console;

// Ввод строки с консоли
string Prompt(string message)
{
    Write(message);
    string result = ReadLine()!;
    return result;
}

// Перевод строки в массив
int[] StringToIntArray(string stringValue)
{
    string[] stringArray = stringValue.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
    int[] result = new int[stringArray.Length];

    for (int i = 0; i < stringArray.Length; i++)
        result[i] = Convert.ToInt32(stringArray[i]);

    return result;
}

// Проверка максимального количества элементов в массиве
void ValidateMaxArraySize(int[] arr)
{
    int size = arr[0] * arr[1] * arr[2];
    if (size > 90) // Двузначных чисел всего 90 (положительных). Массив из неповторяющихся чисел не должен привысить 90 элементов
    {
        WriteLine("Превышено максимальное количество элементов массива");
        Environment.Exit(0);
    }
}

// Заполнение трехмерного массива
int[,,] Get3DArray(int[] lengths)
{
    int[,,] result = new int[lengths[0], lengths[1], lengths[2]];
    string dictionary = String.Empty; // В строку будут вноситься элементы которые уже присваивались 

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            for (int k = 0; k < result.GetLength(2); k++)
            {
                int number = 0;
                string num = String.Empty;

                while (dictionary.Contains(num)) // В цикле получаем рандомное число и проверяем содержит ли его строка (попадалось ли оно уже) и так пока не получим "оригинальное" число  
                {
                    number = new Random().Next(10, 100);
                    num = Convert.ToString(number);
                }

                dictionary += num + " "; // Когда получим число, не содержащаеся в строке, то вносим его в строку
                result[i, j, k] = number; // И присваиваем его элементу массива
            }
        }
    }
    return result;
}

// Вывод трехмерного массива
void Print3DArray(int[,,] array)
{
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Write($"{array[i, j, k]} ({i},{j},{k})\t");
            }
            WriteLine();
        }
    }
}


Clear();
string size = Prompt("Введите размер массива через пробел (i j k): ");
int[] lengths = StringToIntArray(size);
ValidateMaxArraySize(lengths);
int[,,] array3d = Get3DArray(lengths);
Print3DArray(array3d);