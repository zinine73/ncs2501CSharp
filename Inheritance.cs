using System.Threading.Tasks;

namespace MySystem
{
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