using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_00
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试实例001：二分查找
            int[] arr = { 11, 44, 53, 75, 99 };
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            int result = SearchBinary(arr, 99);
            Console.WriteLine(result);
            //------------------------------

            //测试实例002：选择排序
            int[] arr1 = { 13, 0, 41, 88, 19 };
            foreach (int i in arr1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            int[] newArr = SelectionSort(arr1);
            foreach (int i in newArr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            //------------------------------

            //测试实例003：递归（阶乘）
            int numFactorial = 5;
            Console.WriteLine($"factorial of {numFactorial} is {factorial(numFactorial)}");
            //------------------------------

            //测试实例004：快速排序
            int[] arrQS = { 4, 11, 53, 0, 33 };
            foreach (int i in arrQS)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            QuickSort(arrQS, 0, arrQS.Length - 1);
            foreach (int i in arrQS)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            //------------------------------

            //测试实例005：散列表（键值对，字典）System.Collections.Generic
            //定义散列表
            Console.WriteLine("Define KeyValusPair...");
            Dictionary<string, string> NameBirthday = new Dictionary<string, string>();
            //添加数据
            Console.WriteLine("Add data in KeyValusPair...");
            NameBirthday.Add("Tom", "1991-01");
            NameBirthday.Add("Lucy", "1988-12");
            NameBirthday.Add("Jaco", "1985-11");
            NameBirthday.Add("Kite", "1994-04");
            //取一条数据
            Console.WriteLine("read a date, about Lucy's birthday...");
            Console.WriteLine($"Lucy's birthday is {NameBirthday["Lucy"]}");
            //遍历散列表
            Console.WriteLine("Traversal the KeyValuePair...");
            foreach (KeyValuePair<string, string> kvp in NameBirthday)
            {
                Console.WriteLine($"{kvp.Key}'s birthday is {kvp.Value}");
            }
            //遍历散列表键，方法1
            Console.WriteLine("Traversal the Keys...");
            Console.WriteLine("Method1:");
            Dictionary<string, string>.KeyCollection kc = NameBirthday.Keys;
            foreach (string s in kc)
            {
                Console.WriteLine(s);
            }
            //遍历散列表键，方法2
            Console.WriteLine("Method2:");
            foreach (string s in NameBirthday.Keys)
            {
                Console.WriteLine(s);
            }
            //遍历散列表值，方法1
            Console.WriteLine("Traversal the Values...");
            Console.WriteLine("Method1:");
            Dictionary<string, string>.ValueCollection vc = NameBirthday.Values;
            foreach (string v in vc)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("Method2:");
            foreach (string s in NameBirthday.Values)
            {
                Console.WriteLine(s);
            }
            //删除数据
            Console.WriteLine("Remove data of Lucy's birthday...");
            NameBirthday.Remove("Lucy");
            foreach (KeyValuePair<string, string> kvp in NameBirthday)
            {
                Console.WriteLine($"{kvp.Key}'s birthday is {kvp.Value}");
            }
            //修改数据
            Console.WriteLine("updata Tom's birthday...");
            NameBirthday["Tom"] = "1993-03";
            Console.WriteLine($"Tom's birthday is {NameBirthday["Tom"]} now.");
            //判断键存在
            Console.WriteLine("Check the Lucy data exist or not...");
            if (!NameBirthday.ContainsKey("Lucy"))
            {
                Console.WriteLine("Lucy's data not exist.");
            }
            else
            {
                Console.WriteLine("Lucy's data exist.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 001.二分查找
        /// </summary>
        /// <param name="arr">整形一维数组</param>
        /// <param name="var">查找的数据项</param>
        /// <returns></returns>
        static int SearchBinary(int[] arr, int var)
        {
            int low = 0;
            int high = arr.Length - 1;
            int mid, guess;
            while (low <= high)
            {
                mid = (low + high) / 2;
                guess = arr[mid];
                if (guess == var)
                {
                    return mid;
                }
                if (guess > var)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 002.选择排序
        /// </summary>
        /// <param name="arr">整形一维数组</param>
        /// <returns></returns>
        static int[] SelectionSort(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            int smallestIndex, smallestVar;
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            for (int i = 0; i < newArr.Length - 1; i++)
            {
                smallestVar = newArr[i];
                smallestIndex = i;
                for (int j = i + 1; j < newArr.Length; j++)
                {
                    if (smallestVar > newArr[j])
                    {
                        smallestVar = newArr[j];
                        smallestIndex = j;
                    }
                }
                newArr[smallestIndex] = newArr[i];
                newArr[i] = smallestVar;
            }
            return newArr;
        }

        /// <summary>
        /// 递归（阶乘）
        /// </summary>
        /// <param name="n">n阶阶乘</param>
        /// <returns></returns>
        static int factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }

        /// <summary>
        /// 004.快速排序（获取参考值）
        /// </summary>
        /// <param name="arr">整形一维数组</param>
        /// <param name="left">起始位索引</param>
        /// <param name="right">结束位索引</param>
        /// <returns></returns>
        static int GetMid(int[] arr, int left, int right)
        {
            int leftIndex = left;
            int rightIndex = right;
            int pivote = arr[leftIndex];
            while (leftIndex < rightIndex)
            {
                while ((leftIndex < rightIndex) && (arr[rightIndex] >= pivote))
                {
                    rightIndex--;
                }
                arr[leftIndex] = arr[rightIndex];
                while ((leftIndex < rightIndex) && (arr[leftIndex] < pivote))
                {
                    leftIndex++;
                }
                arr[rightIndex] = arr[leftIndex];
            }
            arr[leftIndex] = pivote;
            return leftIndex;
        }
        /// <summary>
        /// 004.快速排序（递归）
        /// </summary>
        /// <param name="arr">整形一维数组</param>
        /// <param name="left">起始位索引</param>
        /// <param name="right">结束位索引</param>
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int midIndex = GetMid(arr, left, right);
                QuickSort(arr, left, midIndex - 1);
                QuickSort(arr, midIndex + 1, right);
            }
        }
    }
}
