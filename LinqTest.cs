using System;
using System.Collections.Generic;
using System.Linq;

class LinqTest
{
    public void Test()
    {
        var intlist = new List<int>();
        int[] numbers = {1,20,3,4,6,5,9,8,12,15,18,17,11,22,2};

        /*
        foreach (int num in numbers)
        {
            if (num % 2 == 0)
                intlist.Add(num);
        }
        intlist.Sort();

        foreach (int num in intlist)
        {
            Console.Write($"{num} ");
        }
        */

        // 쿼리 구문
        var data = from num in numbers 
                where num % 2 == 0 
                orderby num
                select num;

        // 메서드 구문
        var data2 = numbers.Where(num => num % 2 == 0).OrderBy(n => n);

        foreach (var i in data2)
        {
            Console.Write($"{i} ");
        }
    }

    public void Test2()
    {
        char[] chars = "str12i3!@$1ng".ToCharArray();
        var data = from vchar in chars
                    where vchar >= 97 && 122 >= vchar
                    select vchar;
        foreach (char i in data)
        {
            Console.Write($"{i}");
        }
    }
}