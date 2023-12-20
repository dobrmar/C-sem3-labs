// Вариант 6
// В одномерном массиве, состоящем из N целочисленных элементов, вычислить:
// номер максимального элемента массива
// произведение элементов массива, расположенных между первым и вторым нулевыми элементами.
// Преобразовать массив таким образом, чтобы в первой его половине располагались элементы, 
// стоявшие в нечетных позициях, а во второй половине — элементы, стоявшие на четных позициях.

// Для заданной матрицы размером 8 x 8 найти такие k, при которых k-я строка матрицы совпадает с k-м столбцом.
// Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.

class Program
{
    const int minValue = -5;
    const int maxValue = 5;

    public static void Main(string[] args)
    {
        // Часть 1
        int i, j;
        const int N = 10;
        int[] arr = new int[N];
        Random rnd = new Random();
        for (i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(minValue, maxValue);
        }
        PrintArr(arr);

        Console.WriteLine("Индекс максимального элемента: {0}", FindMaxIndex(arr));

        int? res = BetweenZero(arr);
        Console.WriteLine(res == null ? "В массиве нет двух нулей" : "Произведение элементов между первыми двумя нулями: {0}", res);

        ChangeArr(arr);
        PrintArr(arr);

        // Часть 2
        Console.WriteLine();
        int[,] mx = new int[8, 8];
        for (i = 0; i < mx.GetLength(0); i++)
        {
            for (j = 0; j < mx.GetLength(1); j++)
            {
                mx[i, j] = rnd.Next(minValue, maxValue);
            }
        }
        PrintMX(mx);
        FindK(mx);
        Console.WriteLine("Сумма элементов в строках с отрицательным элементом: " + FindSum(mx));
    }

    public static void PrintArr(int[] arr)
    {
        Console.WriteLine(String.Join(" ", arr));
    }

    public static int FindMaxIndex(int[] arr)
    {
        int maxInd = -1;
        int maxEl = minValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxEl)
            {
                maxEl = arr[i];
                maxInd = i;
            }
        }
        return maxInd;
    }

    public static int? BetweenZero(int[] arr)
    {
        int? ret = 1;
        bool foundFirst = false;
        for (int i = 0; i < arr.Length; i++)
        {
            if (foundFirst)
            {
                if (arr[i] == 0)
                {
                    if (arr[i - 1] == 0) return 0; // Если два нуля стоят подряд
                    return ret;
                }
                ret *= arr[i];
            }
            else if (arr[i] == 0)
            {
                foundFirst = true;
            }
        }
        return null;
    }

    public static void ChangeArr(int[] arr)
    {
        int help;
        int right = arr.Length % 2 == 0 ? arr.Length - 1 : arr.Length - 2; // Последний нечетный индекс
        int left = 0;
        while (left < right)
        {
            help = arr[left];
            arr[left] = arr[right];
            arr[right] = help;
            left += 2;
            right -= 2;
        }
    }

    public static void PrintMX(int[,] mx)
    {
        int i, j;
        for (i = 0; i < mx.GetLength(0); i++)
        {
            for (j = 0; j < mx.GetLength(1); j++)
            {
                Console.Write(mx[i, j].ToString().PadLeft(4, ' ') + " ");
            }
            Console.WriteLine();
        }
    }

    public static void FindK(int[,] mx)
    {
        Console.Write("Значения k, при которых kый столбец совпадает с kой строкой:");
        bool found = false;
        bool ok;
        for (int i = 0; i < mx.GetLength(0); i++)
        {

            ok = true;
            for (int j = 0; j < mx.GetLength(0); j++)
            {
                if (mx[i, j] != mx[j, i])
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
            {
                found = true;
                Console.Write(" " + i);
            }
        }
        Console.WriteLine(found ? "" : " таких нет");
    }

    public static int FindSum(int[,] mx)
    {
        int s = 0;
        int i, j, cur;
        bool found;
        for (i = 0; i < mx.GetLength(0); i++)
        {
            cur = 0;
            found = false;
            for (j = 0; j < mx.GetLength(1); j++)
            {
                cur += mx[i, j];
                if (mx[i, j] < 0)
                {
                    found = true;
                }
            }
            if (found) s += cur;
        }
        return s;
    }
}
