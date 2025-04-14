using System.Diagnostics;
using System.Linq;
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

double summD = 0;
double maxD = B[0, 0];
double multD = 1;
double unevenCOLsummD = 0;

int evensumm = 0;

// для нахождения суммы элементов, нечетных столбцов, произведения и макс. числа я просто использовала 1 цикл 
// т.к. лень было искать функции для матриц или пытаться эксперементировать с aggregate 
for (int i = 0; i < B.GetLength(0); i++)
{
    for (int j = 0; j < B.GetLength(1); j++)
    {
        summD += B[i, j];
        multD *= B[i, j];

        if (B[i, j] > maxD)
        {
            maxD = B[i, j];
        }

        if(i%2!=0)
        {
            unevenCOLsummD += B[i, j];
        }
    }
}

for(int i = 0; i < A.Length; i+=2)
{
    evensumm += A[i];
}

WriteLine($"Максимальный элемент массива А: {A.Max()}");
WriteLine($"Максимальный элемент массива B: {maxD}");
WriteLine($"Сумма всех элементов массива А: {A.Aggregate((x, y) => x + y)}");
WriteLine($"Сумма всех элементов массива B: {summD}");
WriteLine($"Произведение всех элементов массива А: {A.Aggregate((x, y) => x * y)}");
WriteLine($"Произведение всех элементов массива B: {multD}");
WriteLine($"Сумма всех элементов с чётным индексом массива А: {evensumm}");
WriteLine($"Сумма всех элементов столбцов с нечётным индексом массива B: {unevenCOLsummD}");