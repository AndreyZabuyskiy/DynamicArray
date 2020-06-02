using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicArray
{
    class Application
    {
        DynamicArray arr;
        public void Start()
        {
            arr = new DynamicArray();
            FillArr();
            while (Action(GetCommand())) ;
        }

        private void FillArr()
        {
            arr.Add(10);
            arr.Add(20);
            arr.Add(30);
            arr.Add(40);
            arr.Add(50);
        }

        private void PrintMenu()
        {
            Console.Clear();
            arr.Show();

            Console.Write("[1] Добавить новый элемент в конец;\n" +
                "[2] Удалить все совпадающие элементы;\n" +
                "[3] Вставить значения в заданую позицию;\n" +
                "[4] Заменить элемент по заданной позиции;\n" +
                "[5] Добавить блок элементов в конец;\n" +
                "[6] Очистка массива;\n" +
                "[7] Проверить на наличие элемент в массиве;\n" +
                "[8] Поиск элемент в массиве (возвращает индекс первого вхождения);\n" +
                "[9] Поиск элемент в массиве (возвращает индекс последнего вхождения);\n" +
                "[10] Вставить блок элементов в заданую позицию;\n" +
                "[11] Перевернуть элементы массива в обратном порядке;\n" +
                "[0] Выход\n" + "->");
        }

        private int GetCommand()
        {            
            PrintMenu();
            return GetValue();
        }

        private bool Action(int command)
        {
            Console.Clear();

            switch (command)
            {
                case 0:
                    return false;

                case 1:
                    arr.Add(GetItem());
                    break;

                case 2:
                    arr.Remove(GetItem());
                    break;

                case 3:
                    arr.Insert(GetIdx(), GetItem());
                    break;

                case 4:
                    arr.Edit(GetIdx(), GetItem());
                    break;

                case 5:
                    arr.AddRange(CreateNewArr());
                    break;

                case 6:
                    arr.Clear();
                    break;

                case 7:
                    IsExist(GetItem());
                    break;

                case 8:
                    Console.WriteLine("Индекс: " + arr.FindFirst(GetItem())); 
                    Console.ReadLine();                   
                    break;

                case 9:
                    Console.WriteLine("Индекс: " + arr.FindLast(GetItem()));
                    Console.ReadLine();
                    break;

                case 10:
                    arr.InsertRange(GetIdx(), CreateNewArr());
                    break;

                case 11:
                    arr.Reverse();
                    break;              

                default:
                    Console.WriteLine("Введена некоректная команда!");
                    Console.ReadLine();
                    break;
            }

            return true;
        }

        private int GetItem()
        {           
            Console.Write("Введите элемент\n" + "->");
            return GetValue();
        }

        private int GetIdx()
        {
            arr.Show();
            Console.Write("Введите индекс\n" + "->");          
            return GetValue();
        }

        private int[] CreateNewArr()
        {           
            int[] newArr = new int[GetSizeNewArr()];

            for(int i = 0; i < newArr.Length; ++i)
            {
                Console.Write("[" + i + "]: ");
                newArr[i] = GetValue();
            }

            return newArr;
        }

        private int GetSizeNewArr()
        {           
            Console.Write("Размер массива\n" + "->");
            return GetValue();
        }

        private int GetValue()
        {
            while(true)
            {
                try
                {                    
                    return int.Parse(Console.ReadLine());
                }
                catch(FormatException ex)
                {
                    Console.Write(ex.Message + "\n->");
                }
            }
        }

        private void IsExist(int item)
        {
            if(arr.Exists(item))
            {
                Console.WriteLine("Элемент " + item + " существует");
            }
            else
            {
                Console.WriteLine("Элемент " + item + " не существует");
            }
        }
    }
}
