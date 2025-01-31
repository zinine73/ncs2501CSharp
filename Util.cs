using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

class Util
{
    /// <summary>
    /// 정수 배열의 내용을 출력
    /// </summary>
    /// <param name="intarray">출력할 배열</param>
    public static void PrintIntArray(int[] intarray)
    {
        Console.Write("{");
        for (int i = 0; i < intarray.Length; i++)
        {
            if (i != 0)
            {
                Console.Write(",");
            }
            Console.Write(intarray[i]);
        }
        Console.WriteLine("}");
    }
}