using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Console;
using static System.Net.Mime.MediaTypeNames;

//// ZADANIE 1

///* 

//Объявить одномерный(5 элементов) массив с именем A и двумерный массив 
//(3 строки, 4 столбца) дробных чисел с именем B. Заполнить одномерный массив
//А числами, введенными с клавиатуры пользователем, а
//двумерный массив В случайными числами с помощью
//циклов. Вывести на экран значения массивов: массива
//А в одну строку, массива В — в виде матрицы. Найти в
//данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, общее
//произведение всех элементов, сумму четных элементов
//массива А, сумму нечетных столбцов массива В. 

//*/

//int[] A = new int[5];
//double[,] B = new double[3,4];
//Random random = new Random();

//WriteLine("Заполните значения массива А:\n\n");

//for (int i = 0; i < A.Length; i++)
//{
//    WriteLine($"Введите число под индексом {i}: ");
//    A[i] = Convert.ToInt32(ReadLine());
//}

//for(int i = 0;i < B.GetLength(0);i++)
//{
//    for(int j = 0;j < B.GetLength(1); j++)
//    {
//        B[i, j] = Math.Round(random.NextDouble()*100, 1);
//    }
//}

//WriteLine("\n\nПервый массив: ");

//for (int i = 0; i < A.Length; i++)
//{
//    Write(A[i] + " ");
//}


//WriteLine("\n\nВторой массив: ");

//for (int i = 0; i < B.GetLength(0); i++)
//{
//    for (int j = 0; j < B.GetLength(1); j++)
//    {
//        Write(B[i, j] + " ");
//    }
//    WriteLine();
//}

//double summD = 0;
//double maxD = B[0, 0];
//double multD = 1;
//double unevenCOLsummD = 0;

//int evensumm = 0;

//// для нахождения суммы элементов, нечетных столбцов, произведения и макс. числа я просто использовала 1 цикл 
//// т.к. лень было искать функции для матриц или пытаться эксперементировать с aggregate 
//for (int i = 0; i < B.GetLength(0); i++)
//{
//    for (int j = 0; j < B.GetLength(1); j++)
//    {
//        summD += B[i, j];
//        multD *= B[i, j];

//        if (B[i, j] > maxD)
//        {
//            maxD = B[i, j];
//        }

//        if(i%2!=0)
//        {
//            unevenCOLsummD += B[i, j];
//        }
//    }
//}

//for(int i = 0; i < A.Length; i+=2)
//{
//    evensumm += A[i];
//}

//WriteLine($"Максимальный элемент массива А: {A.Max()}");
//WriteLine($"Максимальный элемент массива B: {maxD}");
//WriteLine($"Сумма всех элементов массива А: {A.Aggregate((x, y) => x + y)}");
//WriteLine($"Сумма всех элементов массива B: {summD}");
//WriteLine($"Произведение всех элементов массива А: {A.Aggregate((x, y) => x * y)}");
//WriteLine($"Произведение всех элементов массива B: {multD}");
//WriteLine($"Сумма всех элементов с чётным индексом массива А: {evensumm}");
//WriteLine($"Сумма всех элементов столбцов с нечётным индексом массива B: {unevenCOLsummD}");

//// ZADANIE 2

///*
 
//Дан двумерный массив размерностью 5×5, заполненный 
//случайными числами из диапазона от –100 до 100.
//Определить сумму элементов массива, расположенных
//между минимальным и максимальным элементами

//*/

//int[,] mass5x5 = new int[5, 5];
//int maxCOL = 0, maxROW = 0, minCOL = 0, minROW = 0;
//int summ5x5 = 0;
//bool check = false;

//WriteLine("Массив 5x5: ");

//for (int i = 0; i < 5; i++) 
//{
//    for (int j = 0; j < 5; j++)
//    {
//        mass5x5[i, j] = random.Next(-100, 100);

//        Write(mass5x5[i, j]+" ");

//        if(mass5x5[i, j] < mass5x5[minCOL, minROW])
//        {
//            minCOL = i;
//            minROW = j;
//        }
//        if (mass5x5[i, j] > mass5x5[maxCOL, maxROW]) 
//        {
//            maxCOL = i;
//            maxROW = j;
//        }
//    }
//    WriteLine();
//}

//WriteLine($"Максимальным элементом массива является {mass5x5[maxCOL, maxROW]}, а минимальным {mass5x5[minCOL, minROW]}");

//if (maxCOL > minCOL && maxROW > minROW || maxCOL >= minCOL && maxROW > minROW || maxCOL > minCOL && maxROW >= minROW)
//{
//    for (int i = 0; i < 5; i++)
//    {
//        for (int j = 0; j < 5; j++)
//        {
//            if (mass5x5[i, j] == mass5x5[minCOL, minROW])
//            {
//                check = true;
//            }
//            if (mass5x5[i, j] == mass5x5[maxCOL, maxROW])
//            {
//                check = false;
//                summ5x5 += mass5x5[maxCOL, maxROW];

//                i = 5;
//                j = 5;
//            }

//            if(check == true)
//            {
//                summ5x5 += mass5x5[i, j];
//            }
//        }
//    }
//}

//else if (maxCOL < minCOL && maxROW < minROW || maxCOL <= minCOL && maxROW < minROW || maxCOL < minCOL && maxROW <= minROW)
//{
//    for (int i = 0; i < 5; i++)
//    {
//        for (int j = 0; j < 5; j++)
//        {
//            if (mass5x5[i, j] == mass5x5[maxCOL, maxROW])
//            {
//                check = true;
//            }
//            if (mass5x5[i, j] == mass5x5[minCOL, minROW])
//            {
//                check = false;
//                summ5x5 += mass5x5[minCOL, minROW];

//                i = 5;
//                j = 5;
//            }

//            if (check == true)
//            {
//                summ5x5 += mass5x5[i, j];
//            }
//        }
//    }
//}

//WriteLine($"Сумма всех чисел между индексами макс и мин. элементов равна {summ5x5} \n\nВведите строку которую нужно зашифровать: ");

//// ZADANIE 3

///*

// Пользователь вводит строку с клавиатуры. Необходимо зашифровать данную строку используя шифр Цезаря.
//Из Википедии:

//Шифр Цезаря — это вид шифра подстановки, в котором 
//каждый символ в открытом тексте заменяется
//символом, находящимся на некотором постоянном числе
//позиций левее или правее него в алфавите. Например,
//в шифре со сдвигом вправо на 3, A была бы заменена на
//D, B станет E, и так далее.
//Подробнее тут: https://en.wikipedia.org/wiki/Caesar_cipher.
//Кроме механизма шифровки, реализуйте механизм
//расшифрования.

//*/

//string user_str = ReadLine();
//char[] user_char_str = new char[user_str.Length + 1];

//// тут как при шифровке так и при дешифровке идёт проверка (то есть если
//// при шифровке со сдвигом вправа на 3 как я и сделала, в тексте будет
//// буква xyz то сдвиг не пойдёт в символы, а перейдёт в начало алфавита
//// и также будет и при дешифровке, abc перейдут в конец алфавита а не в символы
//// и данная схема распространяется на оба регистра
//for(int i = 0; i< user_str.Length; i++)
//{
//    if ((int)(user_str[i]) == 88 || (int)(user_str[i]) == 89 || (int)(user_str[i]) == 90)
//    {
//        user_char_str[i] = (char)(64 + (4 + ((int)(user_str[i])-91)));
//    }
//    else if ((int)(user_str[i]) == 120 || (int)(user_str[i]) == 121 || (int)(user_str[i]) == 122)
//    {
//        user_char_str[i] = (char)(96 + (4 + ((int)(user_str[i]) - 123)));
//    }
//    else
//    {
//        user_char_str[i] = (char)(user_str[i] + 3);
//    }
//}

//// тут я не уместила все выводы в writeline потому что при
//// попытке прописать как через $ так и через + в одной такой
//// конструкции у меня выводилось что-то вроде
//// System.Char[] вместо самой строки даже при попытке
//// прописать user_char_str.ToArray()

//WriteLine("\nЗашифрованная строка: ");
//Write(user_char_str);
//WriteLine("\nВведите строку которую нужно расшифровать: ");

//user_str = ReadLine();

//for (int i = 0; i < user_str.Length; i++)
//{
//    if ((int)(user_str[i]) == 65 || (int)(user_str[i]) == 66 || (int)(user_str[i]) == 67)
//    {
//        user_char_str[i] = (char)(91 - (4 - ((int)(user_str[i]) - 64)));
//    }
//    else if((int)(user_str[i]) == 97 || (int)(user_str[i]) == 98 || (int)(user_str[i]) == 99)
//    {
//        user_char_str[i] = (char)(123 - (4 - ((int)(user_str[i]) - 96)));
//    }
//    else
//    {
//        user_char_str[i] = (char)(user_str[i] - 3);
//    }
//}

//WriteLine("\nРасшифрованная строка: ");
//Write(user_char_str);

//// ZADANIE 4

///*
 
//Создайте приложение, которое производит операции
//над матрицами:
//■ Умножение матрицы на число;
//■ Сложение матриц;
//■ Произведение матриц
 
// */

//const int size = 2;
//int[,] A_matrix = new int[size, size] { { 1, 2 }, { 3, 4 } };
//int[,] B_matrix = new int[size, size] { { 5, 6 }, { 7, 8 } };

//int[,] Result = new int[size, size];

//int user_choice;

//WriteLine("\nМатрица A:\n");

//for (int i = 0; i < size; i++)
//{
//    for (int j = 0; j < size; j++)
//    {
//        Write(A_matrix[i, j]+" ");
//    }
//    WriteLine();
//}

//WriteLine("Матрица B:\n");

//for (int i = 0; i < size; i++)
//{
//    for (int j = 0; j < size; j++)
//    {
//        Write(B_matrix[i, j]+" ");
//    }
//    WriteLine();
//}

//WriteLine("\nВведите число в зависимости от вашего выбора действия над  матрицами А и В:\n1.Сложить\nВычесть\n3.Умножить\n\n");

//user_choice = Convert.ToInt32(ReadLine());

//WriteLine("\nРезультат: ");

//switch(user_choice)
//{
//    case (int)Ops.SUMM:
//        {
//            for (int i = 0; i < size; i++) 
//            {
//                for (int j = 0; j < size; j++) 
//                {
//                    Result[i, j] = A_matrix[i, j] + B_matrix[i, j];
//                }
//            }
//            break;
//        }
//    case (int)Ops.SUBT:
//        {
//            for (int i = 0; i < size; i++) 
//            {
//                for (int j = 0; j < size; j++) 
//                {
//                    Result[i, j] = A_matrix[i, j] - B_matrix[i, j];
//                }
//            }
//            break;
//        }
//    case (int)Ops.MULT:
//        {
//            for (int i = 0; i < size; i++)
//            {
//                for (int j = 0; j < size; j++)
//                {
//                    for (int k = 0; k < size; k++)
//                    {
//                        Result[i,j] += A_matrix[i,k] * B_matrix[k,j];
//                    }

//                    Write(Result[i, j]+" ");
//                }
//                WriteLine();
//            }

//            break;
//        }
//} 

// ZADANIE 5

/*

Пользователь с клавиатуры вводит в строку арифметическое 
выражение. Приложение должно посчитать его результат.
Необходимо поддерживать только две операции: + и –.

*/

WriteLine("Введите математическое выражние для вычисления: ");

string user_exp = ReadLine();
char[] chared_exp = new char[user_exp.Length];
char[] buff_chared_exp;
string buff_exp;
char[] curr_numb = new char[user_exp.Length];
string curr_numb_str;
int next_numb_index = 0;
int counter = 0;
bool oper = false;
int op_res = 0;
int curr = 0;
int op_indx = 0;

// убираем пробелы в случа если пользователь ввёл
// выражение кое-как и поставил их не везде, чтобы
// было легче отделять +, - и числа при выполнении

foreach(char buff in user_exp)
{
    if(buff== ' ')
    {
        user_exp.Remove(counter, 1);
    }
        counter++;
}

counter = 0;

while (chared_exp.Length!=0)
{

    if(user_exp.IndexOf('-') > user_exp.IndexOf('+') || user_exp.IndexOf('-') < 0)
    {
        oper = true;
    }
    if (oper == true)
    {
        for (int i = 0; user_exp[i] != '+'; i++) 
        {
            curr_numb[i] = user_exp[i];
            op_indx = i + 2;
        }

        user_exp.CopyTo(0, curr_numb, 0, op_indx - 1);

        curr = int.Parse(curr_numb);
        op_res += curr;

        user_exp.Remove(0, op_indx);
    }
    else
    {
        for (int i = 0; user_exp[i] != '-'; i++)
        {
            curr_numb[i] = user_exp[i];
            op_indx = i + 2;
        }

        user_exp.CopyTo(0, curr_numb, 0, op_indx - 1);

        curr = int.Parse(curr_numb);
        op_res -= curr;

        user_exp.Remove(0, op_indx);
    }

    counter = 0;
}

// ZADANIE 6

/*

Пользователь с клавиатуры вводит некоторый текст.
Приложение должно изменять регистр первой буквы
каждого предложения на букву в верхнем регистре.

Например, если пользователь ввёл: «today is a good
day for walking. i will try to walk near the sea».
Результат работы приложения: «Today is a good day
for walking. I will try to walk near the sea».

*/

WriteLine($"{op_res}\n\nВведите предложения, регистр первых букв которых нужно исправить на верхний: ");

string str_text = ReadLine();
char[] str_text_but_chared = str_text.ToCharArray();

// проверка на регистр первой буквы строки
if(str_text_but_chared[0] > 96 && str_text_but_chared[0] < 123)
{
    str_text_but_chared[0] = (char)(str_text[0] - 32);
}

// проверка на начало нового предложения и на то,
// не написана ли первая буква уже верхним регистром

for (int i = 0; i < str_text.Length; i++) 
{
    if (str_text_but_chared[i] == '.' && str_text_but_chared[i + 1] == ' ' && str_text_but_chared[i + 2] > 96 && str_text_but_chared[i + 2] < 123) 
    {
        str_text_but_chared[i + 2] = (char)(str_text[i + 2] - 32);
    }
}

WriteLine("Получившийся текст: ");
Write(str_text_but_chared);

// ZADANIE 7



public enum Ops { SUMM = 1, SUBT, MULT };