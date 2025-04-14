﻿using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

// ZADANIE 1

/* 

Объявить одномерный(5 элементов) массив с именем A и двумерный массив 
(3 строки, 4 столбца) дробных чисел с именем B. Заполнить одномерный массив
А числами, введенными с клавиатуры пользователем, а
двумерный массив В случайными числами с помощью
циклов. Вывести на экран значения массивов: массива
А в одну строку, массива В — в виде матрицы. Найти в
данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, общее
произведение всех элементов, сумму четных элементов
массива А, сумму нечетных столбцов массива В. 

*/

int[] A = new int[5];
double[,] B = new double[3,4];
Random random = new Random();

WriteLine("Заполните значения массива А:\n\n");

for (int i = 0; i < A.Length; i++)
{
    WriteLine($"Введите число под индексом {i}: ");
    A[i] = Convert.ToInt32(ReadLine());
}

for(int i = 0;i < B.GetLength(0);i++)
{
    for(int j = 0;j < B.GetLength(1); j++)
    {
        B[i, j] = Math.Round(random.NextDouble()*100, 1);
    }
}

WriteLine("\n\nПервый массив: ");

for (int i = 0; i < A.Length; i++)
{
    Write(A[i] + " ");
}


WriteLine("\n\nВторой массив: ");

for (int i = 0; i < B.GetLength(0); i++)
{
    for (int j = 0; j < B.GetLength(1); j++)
    {
        Write(B[i, j] + " ");
    }
    WriteLine();
}