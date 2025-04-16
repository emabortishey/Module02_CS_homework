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

// ZADANIE 2

/*
 
Дан двумерный массив размерностью 5×5, заполненный 
случайными числами из диапазона от –100 до 100.
Определить сумму элементов массива, расположенных
между минимальным и максимальным элементами

*/

int[,] mass5x5 = new int[5, 5];
int maxCOL = 0, maxROW = 0, minCOL = 0, minROW = 0;
int summ5x5 = 0;
bool check = false;

WriteLine("Массив 5x5: ");

for (int i = 0; i < 5; i++) 
{
    for (int j = 0; j < 5; j++)
    {
        mass5x5[i, j] = random.Next(-100, 100);

        Write(mass5x5[i, j]+" ");

        if(mass5x5[i, j] < mass5x5[minCOL, minROW])
        {
            minCOL = i;
            minROW = j;
        }
        if (mass5x5[i, j] > mass5x5[maxCOL, maxROW]) 
        {
            maxCOL = i;
            maxROW = j;
        }
    }
    WriteLine();
}

WriteLine($"Максимальным элементом массива является {mass5x5[maxCOL, maxROW]}, а минимальным {mass5x5[minCOL, minROW]}");

if (maxCOL > minCOL && maxROW > minROW || maxCOL >= minCOL && maxROW > minROW || maxCOL > minCOL && maxROW >= minROW)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (mass5x5[i, j] == mass5x5[minCOL, minROW])
            {
                check = true;
            }
            if (mass5x5[i, j] == mass5x5[maxCOL, maxROW])
            {
                check = false;
                summ5x5 += mass5x5[maxCOL, maxROW];

                i = 5;
                j = 5;
            }

            if(check == true)
            {
                summ5x5 += mass5x5[i, j];
            }
        }
    }
}

else if (maxCOL < minCOL && maxROW < minROW || maxCOL <= minCOL && maxROW < minROW || maxCOL < minCOL && maxROW <= minROW)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (mass5x5[i, j] == mass5x5[maxCOL, maxROW])
            {
                check = true;
            }
            if (mass5x5[i, j] == mass5x5[minCOL, minROW])
            {
                check = false;
                summ5x5 += mass5x5[minCOL, minROW];

                i = 5;
                j = 5;
            }

            if (check == true)
            {
                summ5x5 += mass5x5[i, j];
            }
        }
    }
}

WriteLine($"Сумма всех чисел между индексами макс и мин. элементов равна {summ5x5} \n\nВведите строку которую нужно зашифровать: ");

// ZADANIE 3

/*

 Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную строку используя шифр Цезаря.
Из Википедии:

Шифр Цезаря — это вид шифра подстановки, в котором 
каждый символ в открытом тексте заменяется
символом, находящимся на некотором постоянном числе
позиций левее или правее него в алфавите. Например,
в шифре со сдвигом вправо на 3, A была бы заменена на
D, B станет E, и так далее.
Подробнее тут: https://en.wikipedia.org/wiki/Caesar_cipher.
Кроме механизма шифровки, реализуйте механизм
расшифрования.

*/

string user_str = ReadLine();
char[] user_char_str = new char[user_str.Length + 1];

for(int i = 0; i< user_str.Length; i++)
{
    user_char_str[i] = (char)(user_str[i] + 3);
}

// тут я не уместила все выводы в writeline потому что при
// попытке прописать как через $ так и через + в одной такой
// конструкции у меня выводилось что-то вроде
// System.Char[] вместо самой строки даже при попытке
// прописать user_char_str.ToArray()

WriteLine("\nЗашифрованная строка: ");
Write(user_char_str);
WriteLine("\nВведите строку которую нужно расшифровать: ");

user_str = ReadLine();

for (int i = 0; i < user_str.Length; i++)
{
    user_char_str[i] = (char)(user_str[i] - 3);
}

WriteLine("\nРасшифрованная строка: ");
Write(user_char_str);