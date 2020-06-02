using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicArray
{
    class DynamicArray
    {
        private int[] arr;
        private int currentCount;
        private int count;

        public DynamicArray()
        {
            Initialization();
        }

        private void Initialization()
        {
            count = 5;
            currentCount = 0;
            arr = new int[count];
        }

        public void Show()
        {
            for(int i = 0; i < currentCount; ++i)
            {
                Console.Write("[" + arr[i] + "] ");
            }
            Console.WriteLine("\n---------------------------------------------------");
        }

        private void AllocateMemory(int size)
        {
            if (size >= count)
            {
                count = size * 2;
                int[] tmp = new int[count];

                for (int i = 0; i < currentCount; ++i)
                {
                    tmp[i] = arr[i];
                }

                arr = tmp;
            }
        }

        public void Add(int item)
        {
            AllocateMemory(currentCount);
            arr[currentCount++] = item;
        }

        public void Remove(int item)
        {
            int[] tmp = new int[count];
            int idxTmp = 0;

            for(int i = 0; i < currentCount; ++i)
            {
                if (arr[i] != item)
                {
                    tmp[idxTmp++] = arr[i];
                }
            }

            currentCount = idxTmp;
            arr = tmp;
        }

        public void Insert(int idx, int num)
        {
            if(idx > -1 && idx <= currentCount)
            {
                AllocateMemory(currentCount);

                for (int i = currentCount - 1; i >= idx; --i)
                {
                    arr[i + 1] = arr[i];
                }
                arr[idx] = num;

                currentCount++;
            }
           
        }

        public void Edit(int idx, int num)
        {
            if (idx > -1 && idx <= currentCount)
            {
                arr[idx] = num;
            }
        }

        public void AddRange(int[] _arr)
        {
            AllocateMemory(currentCount + _arr.Length);

            for(int i = 0; i < _arr.Length; ++i)
            {
                arr[currentCount++] = _arr[i];
            }
        }

        public void Clear()
        {
            Initialization();
        }

        public bool Exists(int num)
        {
            for(int i = 0; i < currentCount; ++i)
            {
                if(arr[i] == num)
                {
                    return true;
                }
            }

            return false;
        }

        public int FindFirst(int num) 
        {
            for(int i = 0; i < currentCount; ++i)
            {
                if(arr[i] == num)
                {
                    return i;
                }
            }

            return -1;
        }

        public int FindLast(int num)
        {
            for(int i = currentCount - 1; i > -1; --i)
            {
                if(arr[i] == num)
                {
                    return i;
                }
            }

            return -1;
        }

        public void InsertRange(int idx, int[] _arr)
        {
            if (idx > -1 && idx <= currentCount)
            {
                AllocateMemory(currentCount + _arr.Length);

                for (int i = currentCount - 1; i >= idx; --i)
                {
                    arr[i + _arr.Length] = arr[i];
                }

                for (int i = 0; i < _arr.Length; ++i)
                {
                    arr[idx++] = _arr[i];
                    currentCount++;
                }
            }
        }

        public void Reverse()
        {
            for(int i = 0; i < currentCount / 2; ++i)
            {
                Swap(ref arr[i], ref arr[currentCount - i - 1]);
            }
        }

        private void Swap(ref int first, ref int second)
        {
            first = (first + second) - first + 0 * (second = first);
        }
    }
}
