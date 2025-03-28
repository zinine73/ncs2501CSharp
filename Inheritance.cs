using System.Threading.Tasks;

namespace MySystem
{
    interface ParentInterface
    {
        void myMethod(string str);
    }

    interface SubInterface : ParentInterface
    {
        void myMethod(string str, int i);
    }

    public class InterClass2 : SubInterface
    {
        public void myMethod(string str)
        {
            Console.WriteLine(str + " ParentInterface.myMethid() call!");
        }
        public void myMethod(string str, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(str 
                    + " SubInterface.myMethod() " + i + "call!");
            }
        }
    }

    interface IMyInterfaceA
    {
        void print();
    }

    interface IMyInterfaceB
    {
        void print();
    }

    public class InterClass : IMyInterfaceA, IMyInterfaceB
    {
        public void Run()
        {
            InterClass mc = new InterClass();
            IMyInterfaceA imca = mc;
            imca.print();

            IMyInterfaceB imcb = mc;
            imcb.print();
        }

        void IMyInterfaceA.print()
        {
            Console.WriteLine("IMyInterfaceA.print() 호출");
        }

        void IMyInterfaceB.print()
        {
            Console.WriteLine("IMyInterfaceB.print() 호출");
        }
    }

    public class OuterClass
    {
        private int aa = 70;

        public class InnerClass
        {
            OuterClass instance;

            public InnerClass(OuterClass value)
            {
                instance = value;
            }

            public async Task AccessVatiable(int num)
            {
                //aa = num;
                this.instance.aa = num;
            }

            public void ShowVariable()
            {
                Console.WriteLine($"aa : {this.instance.aa}");
            }
        }
    }

    public class Parent
    {
        public int num;
        public Parent()
        {
            num = 1;
        }
    }

    public class Child : Parent
    {
        private string name = "John";
        public new int num;
        public Child(int num)
        {
            this.num = num;
            //Console.WriteLine($"Child num:{this.num}");
            //Console.WriteLine($"Parent num:{base.num}");
            //Console.WriteLine($"num:{num}");
        }
        public string Name
        {
            get
            {
                return name;
            }   
            set
            {
                if (value.Length < 5)
                {
                    name = value;
                }
            }
        }

        public void SetName(string val)
        {
            if (val.Length < 5)
            {
                name = val;
            }
        }

        public string GetName()
        {
            return name;
        }
    }
}