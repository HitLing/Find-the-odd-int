using System;



class Merage
{

    static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (array[left] < array[right])
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }


    static int[] MergeSort(int[] array, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(array, lowIndex, middleIndex);
            MergeSort(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }

        return array;
    }

    public static int[] MergeSort(int[] array)
    {
        return MergeSort(array, 0, array.Length - 1);
    }


   
}

class Kata
    {
        public static int find_it(int[] seq)
        {
            seq = Merage.MergeSort(seq);
            int rememberletter = seq[0];
            int remembernum = 0;
            for (int i = 0; i< seq.Length; i++) {
                if (seq[i] != rememberletter) {
                    if ((i - remembernum) % 2 == 1) {
                        return rememberletter;
                    }
                    rememberletter = seq[i];
                    remembernum = i;
                }
            }
        return 10;
        }


    }


namespace Работа_с_массивом_и_поиском_нечётного
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[10] { 1, 8, 1, 2, 15, 2, 2, 7, 9, 18 };
            Console.WriteLine($"не отсортированный массив");
            for (int i = 0; i<mass.Length;i++) {
                Console.WriteLine(mass[i]);
            }
            mass = Merage.MergeSort(mass);
            Console.WriteLine($"отсортированный массив");
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine(mass[i]);
            }
            int a = Kata.find_it(mass);
            Console.WriteLine(a);
        }
    }
}
