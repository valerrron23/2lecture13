using System;

namespace lecture13_2
{
    class Program
    {
        static int[] temporaryArray; //лекция 13 пример 2

        static void Merge(int[] array, int start, int middle, int end) //задание целочисленных переменных
        {
            var leftPtr = start; //задание переменной
            var rightPtr = middle + 1; //задание переменной
            var length = end - start + 1; //задание переменной
            for (int i = 0; i < length; i++) //цикл, пока верно условие 
            {
                if (rightPtr > end || (leftPtr <= middle && array[leftPtr] < array[rightPtr])) //выполнять, если верно условие
                {
                    temporaryArray[i] = array[leftPtr]; //задание массива
                    leftPtr++; //инкремент
                }
                else //другой исход
                {
                    temporaryArray[i] = array[rightPtr]; //задание массива
                    rightPtr++; //инкремент
                }
            }
            for (int i = 0; i < length; i++) //цикл, пока верно условие
                array[i + start] = temporaryArray[i]; //задание массива
        }

        static void MergeSort(int[] array, int start, int end)
        {
            if (start == end) return; //выполнять, если верно условие
            var middle = (start + end) / 2; //задание переменной
            MergeSort(array, start, middle); //сортировка
            MergeSort(array, middle + 1, end); //сортировка
            Merge(array, start, middle, end); //сортировка

        }

        static void MergeSort(int[] array)
        {
            temporaryArray = new int[array.Length]; //задание массива
            MergeSort(array, 0, array.Length - 1); //сортировка
        }

        public static void Main()
        {
            int[] array = { //задание элементов массива
		3, //1 элемент
		2, //2 элемент
		5,//3 элемент
		7,//4 элемент
		8,//5 элемент
		1,//6 элемент
		9//7 элемент
	};
            MergeSort(array); //сортировка
            foreach (var e in array) //выполнять для каждого указанного элемента
                Console.WriteLine(e); //вывод массива
            Console.ReadKey(); //программа ожидает нажатия клавиши перед завершением работы
        }
    }
}