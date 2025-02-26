using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MySystem
{
    class MySort
    {
        public delegate int CompareDelegate(int i1, int i2);

        public static void Sort(int[] arr, CompareDelegate comp)
        {
            if (arr.Length < 2) return;
            Console.WriteLine($"함수 Prototype : {comp.Method}");

            int ret;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //ret = AscendingCompare(arr[i], arr[j]);
                    //ret = DescendingCompre(arr[i], arr[j]);
                    ret = comp(arr[i], arr[j]);
                    if (ret == -1)
                    {
                        int tmp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }
            Util.PrintArray<int>(arr);
        }
    }

    class DelProgram
    {
        public void Run()
        {
            int[] a = {5, 53, 3, 7, 1};

            // 올림차순으로 정렬
            MySort.CompareDelegate compDelegate = AscendingCompare;
            MySort.Sort(a, compDelegate);
            // 내림차순으로 정렬
            compDelegate = DescendingCompre;
            MySort.Sort(a, compDelegate);
            //MySort.Sort(a, DescendingCompre);
        }

        // CompareDelegate 와 동일한 prototype 
        int AscendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i2 - i1) > 0 ? 1 : -1;
        }

        // CompareDelegate 와 동일한 prototype 
        int DescendingCompre(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i1 - i2) > 0 ? 1 : -1;
        }

    }

    class MyClass
    {
        // delegate 선언
        private delegate void RunDelegate(int i);

        private void RunThis(int val)
        {
            Console.WriteLine($"{val}");
        }

        private void RunThat(int value)
        {
            Console.WriteLine($"0x{value:X}");
        }

        private void RunOther(float fv)
        {
            Console.WriteLine(fv);
        }

        public void Perform()
        {
            // delegate 인스턴스 생성
            RunDelegate run = new RunDelegate(RunThis);
            // delagate 실행
            run(1024);

            // run = new RunDelagate(RunThat);
            run = RunThat;
            run(1024);
        }

        private const int MAX = 10;
        private string name;
        private int[] data = new int[MAX];
        private int val = 1;

        public int InstRun()
        {
            return val;
        }

        public static int Run()
        {
            return 1;
        }

        public void SetName(string strName)
        {
            name = strName;
        }

        // indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= MAX)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return data[index];
                }
            }
            set
            {
                if (!(index < 0 || index >= MAX))
                //if (index >= 0 && index < MAX)
                {
                    data[index] = value;
                }
            }
        }

        public int this[string str]
        {
            get
            {
                if (str.Equals(name))
                {
                    return data[0];
                }
                else
                {
                    throw new Exception();
                }
            }
            set
            {
                if (str.Equals(name))
                {
                    data[0] = value;
                }
            }
        }
    }

    public class Client
    {
        public void Test()
        {
            MyClass myClass = new MyClass();
            int i = myClass.InstRun();

            int j = MyClass.Run();
        }
    }

    public static class MyUtility
    {
        private static int ver;

        static MyUtility()
        {
            ver = 1;
        }

        public static string Convert(int i)
        {
            return i.ToString();
        }

        public static int ConvertBack(string s)
        {
            return int.Parse(s);
        }

    }
}