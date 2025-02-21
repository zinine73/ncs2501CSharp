using System.Formats.Asn1;
using System.Text;

class Solution
{
    /// <summary>
    /// 9로 나눈 나머지
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public int Solution0221(string number)
    {
        int answer = 0;
        // string은 char형의 배열
        // 배열의 각 값을 다 돈다
        foreach (var item in number)
        {
            // item 의 integer 값을 더해준다
            answer += (item - '0');
        }
        // 9로 나눈 나머지를 구한다
        return answer % 9;
    }

    /// <summary>
    /// 삼각형의 완성조건(2)
    /// </summary>
    /// <param name="sides"></param>
    /// <returns></returns>
    public int Solution02202(int[] sides)
    {
        int answer = 0;
        // 큰값과 작은값으로 별도의 변수를 잡는다
        int big = Math.Max(sides[0], sides[1]);
        int small = Math.Min(sides[0], sides[1]);
        // x + small > big
        // big - small < x <= big
        for (int i = big - small + 1; i <= big; i++)
        {
            answer++;
        }
        // big + small > x
        // big < x < big + small
        for (int i = big + 1; i < big + small; i++)
        {
            answer++;
        }
        return answer;
    }

    /// <summary>
    /// 삼각형의 완성조건(1)
    /// </summary>
    /// <param name="sides"></param>
    /// <returns></returns>
    public int Solution0220(int[] sides)
    {
        // 리스트로 변환
        var list = new List<int>(sides);
        // 정렬
        list.Sort();
        // 가장 큰 값과 나머지 값들의 합과 비교
        if (list[2] < list[0] + list[1])
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    /// <summary>
    /// 최댓값 만들기(2)
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int Solution02192(int[] numbers)
    {
        //int answer = -10000 * 10000;
        int answer = int.MinValue;
        // for문을 중첩으로 돌린다
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                // 각각의 인덱스 값을 곱해서 나온 값과 현재 최대값을 비교
                if (answer < numbers[i] * numbers[j])
                {
                    // 큰값을 최대값으로
                    answer = numbers[i] * numbers[j];
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 최댓값 만들기(1)
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int Solution0219(int[] numbers)
    {
        int answer = 0;
        /*
        // for문을 중첩으로 돌린다
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                // 각각의 인덱스 값을 곱해서 나온 값과 현재 최대값을 비교
                if (answer < numbers[i] * numbers[j])
                {
                    // 큰값을 최대값으로
                    answer = numbers[i] * numbers[j];
                }
            }
        }
        */
        // 입력값을 정렬
        var list = new List<int>(numbers);
        list.Sort();
        // 마지막 수와 마지막 전 수 를 곱한다
        answer = list[list.Count - 1] * list[list.Count - 2];
        return answer;
    }

    /// <summary>
    /// 5명씩
    /// </summary>
    /// <param name="names"></param>
    /// <returns></returns>
    public string[] Solution0218(string[] names)
    {
        // string List 를 하나 만들자
        var list = new List<string>();
        // 5번째를 체크하는 int 값 (= idx)도 하나 만들자
        int idx = 0;
        // names를 전체 반복
        foreach (var item in names)
        {
            // 체크하는 값이 처음이냐
            if (idx == 0)
            {
                // 리스트에 넣기
                list.Add(item);
            }
            // idx++
            idx++;
            // idx == 5 ?
            if (idx == 5)
            {
                // idx = 0;
                idx = 0;
            }
        }
        // string 배열로 리턴
        return list.ToArray();
    }

    /// <summary>
    /// 콜라츠 수열 만들기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution0217(int n)
    {
        // List를 하나 만들자
        var list = new List<int>();
        // while 로 돌리자
        while (n != 1)
        {
            // n 을 List에 넣는다
            list.Add(n);
            // n 이 짝수인지 판별
            if (n % 2 == 0)
            {
                // 짝수일 때 변형
                n /= 2;
            }
            else
            {
                // 홀수일 때 변형
                n = 3 * n + 1;
            }
        }
        // 마지막으로 할 일
        list.Add(1);
        // List를 배열혛식으로 리턴
        return list.ToArray();
    }

    /// <summary>
    /// 세균 증식
    /// </summary>
    /// <param name="n"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public int Solution0214(int n, int t)
    {
        return n << t;
        //return (int)(n * Math.Pow(2, t));
        /*
        for (int i = 0; i < t; i++)
        {
            n *= 2;
        }
        return n;
        */
    }

    /// <summary>
    /// 배열의 원소만큼 추가하기
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int[] Solution0213(int[] arr)
    {
        var x = new List<int>();
        // arr 전체를 반복
        foreach (var item in arr)
        {
            // 각 원소의 크기만큼 x에 추가
            for (int i = 0; i < item; i++)
            {
                x.Add(item);
            }
        }
        return x.ToArray();
    }

    /// <summary>
    /// 주사위 게임1
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Solution02122(int a, int b)
    {
        int answer = 0;
        if (a % 2 == 1)
        {
            if (b % 2 == 1)
            {
                answer = a * a + b * b;
            }
            else
            {
                answer = 2 * (a + b);
            }
        }
        else
        {
            if (b % 2 == 1)
            {
                answer = 2 * (a + b);
            }
            else
            {
                answer = Math.Abs(a - b);
            }
        }
        return answer;
    }

    /// <summary>
    /// 뒤에서 5등 위로
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution0212(int[] num_list)
    {
        // List사용
        var list = new List<int>(num_list);
        // List정렬
        list.Sort();

        // index : for 문
        /*
        var list2 = new List<int>();
        for (int i = 5; i < list.Count; i++)
        {
            // 다른 list에 넣기
            list2.Add(list[i]);
        }   
        // list를 int[] 로 변환해서 리턴
        return list2.ToArray();
        */

        // RemoveAt : 필요없는 항목 지우기
        for (int i = 0; i < 5; i++)
        {
            list.RemoveAt(0);
        }
        // list를 int[] 로 변환해서 리턴
        return list.ToArray();
    }

    /// <summary>
    /// 짝수는 싫어요
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution02112(int n)
    {
        // list 정의
        //List<int> list = new List<int>();
        var list = new List<int>();
        // 1부터 n(포함)까지 반복
        for (int i = 1; i <= n; i++)
        {
            // 홀수냐?
            if (i % 2 != 0)
            {
                // 홀수면 list에 넣기
                list.Add(i);
            }
        }
        // list를 int[] 형식으로 리턴
        return list.ToArray();
    }

    /// <summary>
    /// 0 떼기
    /// </summary>
    /// <param name="n_str"></param>
    /// <returns></returns>
    public string Solution0211(string n_str)
    {
        string answer = string.Empty;
        int temp = Convert.ToInt32(n_str);
        answer = temp.ToString();
        return answer;
        //return Convert.ToInt32(n_str).ToString();
        /*
        string answer = string.Empty;
        // 0이 지속되는지 여부 변수 : zero
        bool zero = true;
        // zero 변수가 참일때 반복
        while (zero)
        {
            // 현재 맨 앞에 문자가 0인지 판별
            //if (n_str[0] == '0')
            if (n_str[0].CompareTo('0') == 0)
            {
                // 0이면 지우기
                n_str = n_str.Substring(1);//, n_str.Length - 1);
            }
            else
            {
                // zero변수를 false로
                zero = false;
            }
        }
        answer = n_str;
        return answer;
        */
    }

    /// <summary>
    /// 자릿수 더하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution02102(int n)
    {
        int answer = 0;
        // n을 string으로 변환
        string str = n.ToString();
        // string을 처음부터 반복
        foreach (var item in str)
        {
            // 각 char의 계산된 값을 더한다
            answer += (item - '0');
        }
        return answer;
    }

    /// <summary>
    /// 주사위의 개수
    /// </summary>
    /// <param name="box"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0210(int[] box, int n)
    {
        return (box[0] / n) * (box[1] / n) * (box[2] / n);
    }

    /// <summary>
    /// 홀수 vs 짝수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution0207(int[] num_list)
    {
        // 홀수의 합을 넣을 변수 선언
        int hol = 0;
        // 짝수의 합을 넣을 변수 선언
        int jak = 0;
        /*
        // 주어진 배열 크기만큼 반복
        for (int i = 0; i < num_list.Length; i++)
        {
            // 인덱스가 홀수냐 짝수냐 판별
            if (i % 2 == 1)
            {
                // 홀수면 홀수합에 더하고
                hol += num_list[i];
            }
            else
            {
                // 짝수면 짝수합에 더한다
                jak += num_list[i];
            }
        }
        */
        bool nowHol = true;
        foreach (var item in num_list)
        {
            if (nowHol)
            {
                hol += item;
            }
            else
            {
                jak += item;
            }
            nowHol = !nowHol;
        }
        // 둘 중 큰 값 리턴
        return Math.Max(hol, jak);
    }

    /// <summary>
    /// 카운트 업
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public int[] Solution0206(int start, int end)
    {
        // 리턴할 배열의 크기를 먼저 구한다
        int len = end - start + 1;
        // 그 크기만큼 배열을 만든다
        int[] answer = new int[len];
        // 크기만큼 반복
        for (int i = 0; i < len; i++)
        {
            // 배열의 처음부터 start에 인덱스 값 더해서 넣는다
            answer[i] = start + i;
        }
        // 배열 리턴
        return answer;
    }

    /// <summary>
    /// 두 수의 연산값 비교하기
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Solution0205(int a, int b)
    {
        int answer = 0;
        // 첫번째 값 구하기
        string temp = "" + a + b;
        int first = Convert.ToInt32(temp);
        // 두번째 값 구하기
        int second = 2 * a * b;
        // 둘 비교하여 큰 값 리턴하기
        /*
        if (first >= second)
        {
            answer = first;
        }
        else// if (first < second)
        {
            answer = second;
        }
        */
        answer = Math.Max(first, second);
        return answer;
    }

    /// <summary>
    /// 수 조작하기2
    /// </summary>
    /// <param name="numlog"></param>
    /// <returns></returns>
    public string Solution02042(int[] numlog)
    {
        string answer = string.Empty;
        // 문자열 계산을 할때는 StringBuilder를 쓰자
        // StringBuilder 사용을 위해서는 using System.Text가 필요하다
        StringBuilder sb = new StringBuilder();
        // 주어진 문자열 길이 -1 만큼 반복
        for (int i = 0; i < numlog.Length - 1; i++)
        {
            // 다음 값 - 지금 값
            int val = numlog[i+1] - numlog[i];
            // 해당 문자를 결과에 더한다
            /*
            if (val == 1)           sb.Append('w');
            else if (val == -1)     sb.Append('s');
            else if (val == 10)     sb.Append('d');
            else if (val == -10)    sb.Append('a');
            */
            switch (val)
            {
                case 1:     sb.Append('w'); break;
                case -1:    sb.Append('s'); break;
                case 10:    sb.Append('d'); break;
                case -10:   sb.Append('a'); break;
            }
        }
        // StringBuilder을 반환하기전, ToString을 해주자
        answer = sb.ToString();
        return answer;
    }
    
    /// <summary>
    /// 수 조작하기1
    /// </summary>
    /// <param name="n"></param>
    /// <param name="control"></param>
    /// <returns></returns>
    public int Solution0204(int n, string control)
    {
        bool exit = false;
        // control의 길이만큼 반복
        foreach (var item in control)
        {
            if (exit == true) break;
            // 해당문자에 따른 n 계산
            switch (item)
            {
                case 'w':   n++;        break;
                case 's':   n--;        break;
                case 'd':   n += 10;    break;
                case 'a':   n -= 10;    break;
                default:
                    Console.WriteLine("Error!!!");
                    exit = true;
                    break;
            }
            /*
            if      (item.Equals('w'))  n++;
            else if (item.Equals('s'))  n--;
            else if (item.Equals('d'))  n += 10;
            else if (item.Equals('a'))  n -= 10;
            else
            {
                Console.WriteLine("Error!!!");
                break;
            }*/
        }
        // n 리턴
        return n;
    }

    /// <summary>
    /// 첫 번째로 나오는 음수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int Solution0203(int[] num_list)
    {
        // num_list의 길이 만큼 반복
        for (int i = 0; i < num_list.Length; i++)
        {
            // 현재 인덱스의 num_list 값과 0 비교
            if (num_list[i] < 0)
            {
                // 작으면 현재 인덱스 리턴
                return i;
            }
        }
        // 아니면 -1 리턴
        return -1;
    }

    /// <summary>
    /// 피자 나눠 먹기 (1)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution01312(int n)
    {
        int answer = 0;
        // 온전한 피자 한판으로 먹을 수 있는 사람 수
        int piz = n / 7;
        // 나머지 피자 조각 먹는 사람 수
        int res = ((n % 7) == 0) ? 0 : 1;
        answer = piz + res;
        return answer;
    }

    /// <summary>
    /// 배열 뒤집기
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] Solution0131(int[] num_list)
    {
        int len = num_list.Length;
        int[] answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            answer[len - 1 - i] = num_list[i];
        }
        return answer;
    }

    /// <summary>
    /// 모음 제거
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution01272(string my_string)
    {
        return my_string.Replace("a","")
            .Replace("e","").Replace("i","")
            .Replace("o","").Replace("u","");
    }

    /// <summary>
    /// 배열원소의길이
    /// </summary>
    /// <param name="strlist"></param>
    /// <returns></returns>
    public int[] Solution0127(string[] strlist)
    {
        int len = strlist.Length;
        int[] answer = new int[len];
        for (int i = 0; i < len; i++)
        {
            answer[i] = strlist[i].Length;
        }
        return answer;
    }

    /// <summary>
    /// 문자열 뒤집기2
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="s"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public string Solution01242(string my_string, int s, int e)
    {
        // Reverse
        // char[] chr = my_string.ToCharArray();
        // int len = e - s + 1;
        // Array.Reverse(chr, s, len);
        // string answer = new string(chr);
        // return answer;
        char[] chr = my_string.ToCharArray();
        Array.Reverse(chr, s, e - s + 1);
        return new string(chr);
    }

    /// <summary>
    /// 문자열 뒤집기
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution0124(string my_string)
    {
        string answer = string.Empty;
        // 입력된 문자열을 처음부터 반복한다
        /*
        for (int i = 0; i < my_string.Length; i++)
        {
            // 출력할 문자열의 뒤에서부터 넣는다
            answer = my_string[i] + answer;
        }
        */
        /*
        foreach (var item in my_string)
        {
            answer = item + answer;
        }
        */
        StringBuilder sb = new StringBuilder();
        foreach (var item in my_string)
        {
            sb.Insert(0, item);
        }
        answer = sb.ToString();
        return answer;
    }

    /// <summary>
    /// 아이스아메리카노
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    public int[] Solution0123(int money)
    {
        /*
        const int COFFEE_PRICE = 5500;
        int[] answer = new int[2];
        answer[0] = money / COFFEE_PRICE;
        answer[1] = money % COFFEE_PRICE;
        return answer;
        */
        return new int[]{money / 5500, money % 5500};
    }

    /// <summary>
    /// 배열의 유사도
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    public int Solution0122(string[] s1, string[] s2)
    {
        int answer = 0;
        // s1의 크기만큼 반복
        foreach (var item1 in s1)
        {
            // s2의 크기만큼 반복
            foreach (var item2 in s2)
            {
                // 같은게 있으면 answer++
                if (item1 == item2)
                {
                    answer++;
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 배열 두 배 만들기
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public int[] Solution0121(int[] numbers)
    {
        // numbers의 크기만큼 반복
        for (int i = 0; i < numbers.Length; i++)
        {
            // index에 해당하는 값을 두배해서 넣기
            //numbers[i] = numbers[i] * 2;
            numbers[i] *= 2;
        }
        // 결과를 리턴
        return numbers;
    }

    /// <summary>
    /// 피자 나눠 먹기 (3)
    /// </summary>
    /// <param name="slice"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0120(int slice, int n)
    {
        int answer = 0;
        // for문 반복
        // for (int i = 1; i <= n; i += slice)
        // {
        //     // 한판 추가
        //     answer++;
        // }

        // while
        while (answer * slice < n)
        {
            answer++;
        }
        return answer;
    }

    /// <summary>
    /// 짝수 홀수 개수
    /// </summary>
    /// <param name="num_list"></param>
    /// <returns></returns>
    public int[] solution01172(int[] num_list)
    {
        int[] answer = new int[2];
        foreach (var item in num_list)
        {
            if (item % 2 == 0)
            {
                answer[0]++;
            }
            else
            {
                answer[1]++;
            }
        }

        return answer;
    }
    /// <summary>
    /// 머쓱이보다 키 큰 사람
    /// </summary>
    /// <param name="array"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public int solution0117(int[] array, int height)
    {
        int answer = 0;
        // for
        // 배열 크기만큼 반복
/*         for (int i = 0; i < array.Length; i++)
        {
            // 머쓱이 키와 비교
            if (array[i] > height)
            {
                // 크면 결과값 + 1
                answer++;
            }
        } */

        // foreach        
        foreach (var item in array)
        {
            if (item > height)
            {
                answer++;
            }
        }
        // 결과값 리턴
        return answer;
    }

    /// <summary>
    /// 배열 나누기
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int[] solution01162(int[] numbers, int num1, int num2)
    {
        // 리턴할 배열의 크기를 먼저 구한다
        int len = num2 - num1 + 1;
        // 구한 크기만큼 배열을 선언
        int[] answer = new int[len];
        // 크기만큼 반복
        for (int i = 0; i < len; i++)
        {
            // 인덱스에 해당하는 값을 배열에 넣는다
            answer[i] = numbers[num1 + i];
        }
        // 배열 리턴
        return answer;
    }

    /// <summary>
    /// 편지
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public int solution0116(string message)
    {
        int answer = 0;
        answer = message.Length * 2;
        return answer;
    }

    /// <summary>
    /// 배열의 평균값
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public double solution0115(int[] numbers)
    {
        /*
        int sum = 0;
        double answer = 0;
        
        // 배열의 요소만큼 반복
        for (int i = 0; i < numbers.Length; i++)
        {
            // 각 요소를 더한다
            sum += numbers[i];
        }
        // 결과값을 배열의 크기로 나눈다
        answer = (double)sum / numbers.Length;
        return answer;
        */

        double answer = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            answer += numbers[i];
        }
        answer /= numbers.Length;
        return answer;

        /*
        double answer = 0;
        foreach (var item in numbers)
        {
            answer += item;
        }
        answer /= numbers.Length;
        return answer;
        */
    }

    /// <summary>
    /// 양꼬치
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int solution01142(int n, int k)
    {
        int answer = 0;
        // 서비스음료수가 몇병이냐
        int ser = n / 10;
        // 양꼬치 * 12000 + 음료수 * 2000 - 서비스음료수 * 2000
        answer = n * 12000 + k * 2000 - ser * 2000;
        return answer;
    }

    /// <summary>
    /// 짝수의 합
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int solution0114(int n)
    {
        // 계산된 값을 저장할 변수를 준비한다
        int answer = 0;
        // n 까지 반복한다
        for (int i = 1; i <= n; i++)
        {
            // 짝수인가?
            if (i % 2 == 0)
            {
                // 짝수면 변수에 계산
                answer += i;
            }
        }
        // 계산된 최종값을 리턴한다
        return answer;
    }

    /// <summary>
    /// 숫자 비교하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int solution0113(int num1, int num2)
    {
        int answer = 0;
        if (num1 == num2)
        {
            answer = 1;
        }
        else
        {
            answer = -1;
        }
        return answer;
    }

    /// <summary>
    /// 나이 출력
    /// </summary>
    /// <param name="age">2022년도의 나이</param>
    /// <returns>출생연도</returns>
    public int solution01102(int age)
    {
        int answer = 0;
        answer = 2022 - age + 1; 
        return answer;
    }

    /// <summary>
    /// 나머지 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int solution0110(int num1, int num2)
    {
        // 정상적인 계산으로 나올 수 없는 값을 기본값으로 해 준다
        int answer = -1;
        answer = num1 % num2;
        return answer;
    }

    /// <summary>
    /// 두 수의 차
    /// </summary>
    /// <param name="num1">인자1</param>
    /// <param name="num2">인자2</param>
    /// <returns>반환값</returns>
    public int solution0109(int num1, int num2)
    {
        // 더 간단하게
        return num1 - num2;

        // 간단하게
        //int anything = num1 - num2;
        //return anything;

        // 정답
        //int anything;
        //anything = num1 - num2;
        //return anything;
    }

    /// <summary>
    /// 두 수의 곱
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public int solution0108(int num1, int num2)
    {
        int answer = 0;
        answer = num1 * num2;
        return answer;
    }
}
