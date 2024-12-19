using System;

namespace ConsoleApp6
{
    class DynamicArray
    {
        private int[] array;
        private int size;
        private int capacity;

        public DynamicArray()
        {
            capacity = 4;
            array = new int[capacity];
            size = 0;
        }

        // 1. Remove: Удаляет элемент по заданному индексу
        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
        }

        // 2. Contains: Проверяет, содержится ли элемент в массиве
        public bool Contains(int item)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == item)
                    return true;
            }
            return false;
        }

        // 3. Clear: Очищает массив
        public void Clear()
        {
            size = 0;
        }

        // 4. Insert: Вставляет элемент на заданный индекс
        public void Insert(int index, int item)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            if (size == capacity)
                Resize(capacity * 2);

            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = item;
            size++;
        }

        // 5. ToArray: Возвращает обычный массив
        public int[] ToArray()
        {
            int[] result = new int[size];
            Array.Copy(array, result, size);
            return result;
        }

        // 6. IndexOf: Возвращает индекс первого вхождения элемента
        public int IndexOf(int item)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == item)
                    return i;
            }
            return -1;
        }

        // 7. Reverse: Разворачивает элементы массива
        public void Reverse()
        {
            int left = 0;
            int right = size - 1;

            while (left < right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }

        // 8. Sort: Сортирует элементы массива по возрастанию
        public void Sort()
        {
            Array.Sort(array, 0, size);
        }

        // 9. CopyTo: Копирует элементы массива в другой массив
        public void CopyTo(int[] destinationArray)
        {
            Array.Copy(array, destinationArray, size);
        }

        // 10. GetCapacity: Возвращает текущую вместимость массива
        public int GetCapacity()
        {
            return capacity;
        }

        // 11. ResizeTo: Изменяет вместимость массива вручную
        public void ResizeTo(int newCapacity)
        {
            if (newCapacity < size)
                throw new ArgumentOutOfRangeException(nameof(newCapacity), "New capacity cannot be smaller than current size.");

            capacity = newCapacity;
            Array.Resize(ref array, capacity);
        }

        // 12. GetLast: Возвращает последний элемент массива
        public int GetLast()
        {
            if (size == 0)
                throw new InvalidOperationException("Array is empty.");
            return array[size - 1];
        }

        // 13. RemoveAt: Удаляет элемент по заданному индексу и сдвигает элементы влево
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");

            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
        }
        // 14. GetSubArray: Возвращает новый массив в заданном диапазоне
        public int[] GetSubArray(int start, int end)
        {
            if (end >= size || start > end)
                throw new ArgumentOutOfRangeException("Invalid range.");

            int length = end - start + 1;
            int[] subArray = new int[length];
            Array.Copy(array, start, subArray, 0, length);
            return subArray;
        }

        // 15. FindMax: Находит максимальный элемент массива
        public int FindMax()
        {
            if (size == 0)
                throw new InvalidOperationException("Array is empty.");

            int max = array[0];
            for (int i = 1; i < size; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            return max;
        }

        // Метод для добавления элемента в конец массива
        public void Add(int item)
        {
            if (size == capacity)
                Resize(capacity * 2);

            array[size++] = item;
        }

        // Метод для изменения размера массива
        private void Resize(int newCapacity)
        {
            capacity = newCapacity;
            Array.Resize(ref array, capacity);
        }

        // Метод для вывода элементов массива
        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray dynamicArray = new DynamicArray();

            // Пример добавления элементов
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);
            dynamicArray.Add(40);
            dynamicArray.Add(50);

            Console.WriteLine("Введите номер задания (1-15):");
            int taskNumber = int.Parse(Console.ReadLine());

            switch (taskNumber)
            {
                case 1:
                    dynamicArray.Remove(2); // Удаление элемента по индексу
                    Console.WriteLine("После удаления элемента по индексу 2:");
                    dynamicArray.Print();
                    break;
                case 2:
                    Console.WriteLine($"Содержится ли элемент 20? {dynamicArray.Contains(20)}");
                    break;
                case 3:
                    dynamicArray.Clear();
                    Console.WriteLine("Массив очищен:");
                    dynamicArray.Print();
                    break;
                case 4:
                    dynamicArray.Insert(2, 25); // Вставка элемента
                    Console.WriteLine("После вставки элемента на индекс 2:");
                    dynamicArray.Print();
                    break;
                case 5:
                    int[] array = dynamicArray.ToArray();
                    Console.WriteLine("Массив в виде обычного массива: " + string.Join(", ", array));
                    break;
                case 6:
                    Console.WriteLine($"Индекс элемента 40: {dynamicArray.IndexOf(40)}");
                    break;
                case 7:
                    dynamicArray.Reverse();
                    Console.WriteLine("Массив после разворота:");
                    dynamicArray.Print();
                    break;
                case 8:
                    dynamicArray.Sort();
                    Console.WriteLine("Массив после сортировки:");
                    dynamicArray.Print();
                    break;
                case 9:
                    int[] destinationArray = new int[dynamicArray.GetCapacity()];
                    dynamicArray.CopyTo(destinationArray);
                    Console.WriteLine("Копированный массив: " + string.Join(", ", destinationArray));
                    break;
                case 10:
                    Console.WriteLine($"Вместимость массива: {dynamicArray.GetCapacity()}");
                    break;
                case 11:
                    dynamicArray.ResizeTo(15);
                    Console.WriteLine("После изменения вместимости:");
                    dynamicArray.Print();
                    break;
                case 12:
                    Console.WriteLine($"Последний элемент массива: {dynamicArray.GetLast()}");
                    break;
                case 13:
                    dynamicArray.RemoveAt(1); // Удаление по индексу
                    Console.WriteLine("После удаления элемента по индексу 1:");
                    dynamicArray.Print();
                    break;
                case 14:
                    int[] subArray = dynamicArray.GetSubArray(0, 2);
                    Console.WriteLine("Подмассив (с 0 по 2): " + string.Join(", ", subArray));
                    break;
                case 15:
                    Console.WriteLine($"Максимальный элемент массива: {dynamicArray.FindMax()}");
                    break;
                default:
                    Console.WriteLine("Неверный номер задания.");
                    break;
            }
        }
    }
}