using System.Formats.Asn1;
using System.IO.Compression;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Runtime.CompilerServices;

class Solution
{
    /// <summary>
    /// 겹치는 선분의 길이
    /// </summary>
    /// <param name="lines"></param>
    /// <returns></returns>
    public int Solution0409(int[,] lines)
    {
        int answer = 0;
        // int배열을 전체 크기로 하나 만들고
        int min = -100;
        int max = 100;
        int len = max - min + 1;
        int[] line = new int[len];
        // lines 를 순회하면서
        for (int i = 0; i < 3; i++)
        {
            // line에 해당하는 값을 int배열에서 값을 증가
            for (int j = lines[i, 0]; j < lines[i, 1]; j++)
            {
                line[j - min]++;
            }
        }
        // int배열에서 값이 2이상인 부분의 갯수를 구한다
        for (int i = min; i <= max; i++)
        {
            if (line[i - min] > 1)
            {
                answer++;
            }
        }
        return answer;
    }

    /// <summary>
    /// 주사위 게임3
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    public int Solution0408(int a, int b, int c, int d)
    {
        int answer = 0;
        int[] dice = new int[7];
        dice = IntoDice(a, dice);
        dice = IntoDice(b, dice);
        dice = IntoDice(c, dice);
        dice = IntoDice(d, dice);
        // 4개가 모두 같은 숫자인 경우
        if (dice.Contains(4))
        {
            for (int p = 1; p <= 6; p++)
            {
                if (dice[p] == 4)
                {
                    answer = p * 1111;
                    break;
                }
            }
        }
        // 3 - 1
        else if (dice.Contains(3))
        {
            for (int p = 1; p <= 6; p++)
            {
                if (dice[p] == 3)
                {
                    for (int q = 1; q <= 6; q++)
                    {
                        if (dice[q] == 1)
                        {
                            answer = (10 * p + q) * (10 * p + q);
                            break;
                        }
                    }
                }
            }
        }
        else if (dice.Contains(2))
        {
            // 2 - 1 - 1 : p를 구할 필요가 없다
            if (dice.Contains(1))
            {
                for (int q = 1; q <= 6; q++)
                {
                    if (dice[q] == 1)
                    {
                        for (int r = q + 1; r <= 6; r++)
                        {
                            if (dice[r] == 1)
                            {
                                answer = q * r;
                                break;
                            }
                        }
                    }
                }
            }
            // 2 - 2
            else
            {
                for (int p = 1; p <= 6; p++)
                {
                    if (dice[p] == 2)
                    {
                        for (int q = p + 1; q <= 6; q++)
                        {
                            if (dice[q] == 2)
                            {
                                // q는 p보다 크므로
                                answer = (p + q) * (q - p);
                                break;
                            }
                        }
                    }
                }
            }

        }
        // 1 - 1 - 1 - 1
        else
        {
            answer = 6;
            for (int i = 1; i <= 6; i++)
            {
                if ((dice[i] == 1) && (answer > i))
                {
                    answer = i;
                }
            }
        }
        return answer;
    }
    public int[] IntoDice(int value, int[] dice)
    {
        dice[value]++;
        return dice;
    }

    /// <summary>
    /// 안전지대
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public int Solution0407(int[,] board)
    {
        int answer = 0;
        // 배열의 크기(행과 열)를 구한다
        int len = board.GetLength(0);
        // 주어진 보드의 테두리가 있는 새로운 보드를 만든다
        int[,] temp = new int[len + 2, len + 2];
        // 행과 열 크기만큼 순회
        for (int x = 1; x <= len; x++)
        {
            for (int y = 1; y <= len; y++)
            {
                // 폭탄이 있냐
                if (board[x - 1, y - 1] == 1)
                {
                    // (8방향 + 원위치), 즉 9군데의 값을 변경
                    temp[x - 1, y - 1]++;
                    temp[x - 1, y    ]++;
                    temp[x - 1, y + 1]++;
                    temp[x    , y - 1]++;
                    temp[x    , y    ]++;
                    temp[x    , y + 1]++;
                    temp[x + 1, y - 1]++;
                    temp[x + 1, y    ]++;
                    temp[x + 1, y + 1]++;
                }
            }
        }

        // 행과 열 크기만큼 순회
        for (int x = 1; x <= len; x++)
        {
            for (int y = 1; y <= len; y++)
            {
                // 0인 곳만 answer에 더하기
                if (temp[x, y] == 0)
                {
                    answer++;
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 연속된 수의 합
    /// </summary>
    /// <param name="num"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    public int[] Solution0404(int num, int total)
    {
        int[] answer = new int[num];
        // total을 num으로 나눈 인덱스 변수
        int idx = total / num;
        // 인덱스의 처음 시작 위치 조정
        idx = idx - (num - 1) / 2;
        // for문 num만큼 반복
        for (int i = 0; i < num; i++)
        {
            // answer배열에 값 넣기
            answer[i] = idx + i;
        }
        return answer;
    }

    /// <summary>
    /// 다음에 올 숫자
    /// </summary>
    /// <param name="common"></param>
    /// <returns></returns>
    public int Solution0403(int[] common)
    {
        int answer = 0;
        // 인덱스 0, 1 두개의 값으로 계산되는 결과를 담은 변수
        int first = common[1] - common[0];
        // 인덱스 1, 2 두개의 값으로 계산되는 결과를 담은 변수
        int second = common[2] - common[1];
        // 두개의 변수가 같은가
        if (first == second)
        {
            // 같으면 등차수열
            // answer 계산
            answer = common[common.Length - 1] + first;
        }
        else
        {
            // 다르면 등비수열
            // answer 계산
            int ratio = common[1] / common[0];
            answer = common[common.Length - 1] * ratio;
        }
        return answer;
    }

    /// <summary>
    /// OX퀴즈
    /// </summary>
    /// <param name="quiz"></param>
    /// <returns></returns>
    public string[] Solution0402(string[] quiz)
    {
        // 퀴즈의 길이만큼 answer를 생성
        string[] answer = new string[quiz.Length];
        // 퀴즈 길이만큼 순회
        for (int i = 0; i < quiz.Length; i++)
        {
            // 퀴즈 문장을 분리
            string[] stuff = quiz[i].Split(' ');
            int first = Convert.ToInt32(stuff[0]);
            int second = Convert.ToInt32(stuff[2]);
            int result = Convert.ToInt32(stuff[4]);
            // 연산자가 뭐냐 판단
            bool isRight;
            if (stuff[1].Equals("+"))
            {
                isRight = (first + second == result);
            }
            else
            {
                isRight = (first - second == result);
            }
            //isRight = stuff[1].Equals("+") ? first + second == result : first - second == result;
            // 결과에 따른 값을 answer에 대입
            answer[i] = isRight ? "O" : "X";
        }
        return answer;
    }

    /// <summary>
    /// 배열 만들기 2
    /// </summary>
    /// <param name="l"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public int[] Solution0401(int l, int r)
    {
        int[] answer;
        // 리스트를 하나 만들고
        var list = new List<int>();
        // l에서 r까지 반복
        for (int i = l; i <= r; i++)
        {
            // 5로 나누어 떨어지는지 체크
            if (i % 5 != 0) continue;
            // '0','5'로만 이루어졌는지 체크
            string str = i.ToString();
            if (str.Replace("0", "").Replace("5", "").Length == 0)
            {
                // 리스트에 넣기
                list.Add(i);
            }
        }
        // 리스트를 배열로 변환
        answer = list.ToArray<int>();
        // 값이 하나도 없으면 -1을 넣기
        if (list.Count == 0)
        {
            answer = new int[]{-1};
        }
        return answer;
    }

    /// <summary>
    /// 코드 처리하기
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string Solution0331(string code)
    {
        string ret = string.Empty;
        // mode, idx 변수 만들기
        int mode = 0;
        int idx = 0;
        // code를 순회하면서
        foreach (var item in code)
        {
            // item 이 1인 경우 모드 체인지
            if (item.Equals('1'))
            {
                mode = 1 - mode;
                idx++;
                continue;
            }
            // mode의 값에 따라
            if (mode == 0)
            {
                // idx의 값에 따라
                if (idx % 2 == 0)
                {
                    ret += item;
                }
            }
            else // mode == 1
            {
                // idx의 값에 따라
                if (idx % 2 != 0)
                {
                    ret += item;
                }
            }
            idx++;
        }
        // ret 값이 없는 경우
        if (ret.Length == 0)
        {
            ret = "EMPTY";
        }
        return ret;
    }

    /// <summary>
    /// 저주의 숫자 3
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0328(int n)
    {
        int answer = 0;
        // n만큼 반복
        for (int i = 0; i < n; i++)
        {
            // 특정조건일때만 건너뛰기
            // '3'을 포함하거나 3으로 나누어 떨어질 때
            do
            {
                // answer++
                answer++;
            } while(answer.ToString().Contains('3') || answer % 3 == 0);
        }
        return answer;
    }

    /// <summary>
    /// 치킨 쿠폰
    /// </summary>
    /// <param name="chicken"></param>
    /// <returns></returns>
    public int Solution0327(int chicken)
    {
        int answer = 0;
        // 쿠폰 수 변수 생성
        int coupon = chicken;
        // 쿠폰이 10장 이상이면 반복
        while (coupon >= 10)
        {
            // 쿠폰 10장 빼고
            coupon -= 10;
            // 서비스 치킨 한마리 추가
            answer++;
            // 쿠폰 한장 추가
            coupon++;
        }
        return answer;
    }

    /// <summary>
    /// 전국 대회 선발 고사
    /// </summary>
    /// <param name="rank"></param>
    /// <param name="attendance"></param>
    /// <returns></returns>
    public int Solution0326(int[] rank, bool[] attendance)
    {
        int answer = 0;
        // 등수와 인덱스를 가진 dictionary
        var dic = new Dictionary<int, int>();
        // 등수만 가진 list
        var list = new List<int>(rank);
        // 등수 크기만큼 순회
        for (int i = 0; i < rank.Length; i++)
        {
            // dictionary에 넣고
            dic.Add(rank[i], i);
            // 불참이면
            if (attendance[i] == false)
            {
                // list에 rank 최대값 넣고
                list[i] = list.Count + 1;
            }
        }       
        // 리스트 정렬
        list.Sort();
        // 마지막 값 계산
        answer = dic[list[0]] * 10000 + dic[list[1]] * 100 + dic[list[2]];
        return answer;
    }

    /// <summary>
    /// 로그인 성공?
    /// </summary>
    /// <param name="id_pw"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    public string Solution0325(string[] id_pw, string[,] db)
    {
        // db의 크기만큼 반복
        for (int i = 0; i < db.GetLength(0); i++)
        {
            // id가 같은지
            if (id_pw[0].Equals(db[i, 0]))
            {
                // pw도 같은지
                if (id_pw[1].Equals(db[i, 1]))
                {
                    // login 성공
                    return "login";
                }
                else
                {
                    // pw가 다름
                    return "wrong pw";
                }
            }
        }
        // id도 없음
        return "fail";
    }

    /// <summary>
    /// 캐릭터의 좌표
    /// </summary>
    /// <param name="keyinput"></param>
    /// <param name="board"></param>
    /// <returns></returns>
    public int[] Solution0324(string[] keyinput, int[] board)
    {
        int[] answer = new int[2];
        // 필요한 변수들 선언
        int x = 0, y = 0;
        int bxr = (board[0] - 1) / 2;
        int bxl = -1 * bxr;
        int byu = (board[1] - 1) / 2;
        int byd = -1 * byu;
        // keyinput을 순회하면서
        foreach (var item in keyinput)
        {
            // 각 방향에 따른 값 계산 (범위를 넘지 않는지 검사)
            if (item.Equals("left"))
            {
                if (x > bxl) x -= 1;
            }
            else if (item.Equals("right"))
            {
                if (x < bxr) x += 1;
            }
            else if (item.Equals("down"))
            {
                if (y > byd) y -= 1;
            }
            else 
            {
                if (y < byu) y += 1;
            }
        }
        // answer에 넣기
        answer[0] = x;
        answer[1] = y;
        return answer;
    }

    /// <summary>
    /// 두 수의 합
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public string Solution0321(string a, string b)
    {
        // string의 계산에는 StringBuilder를 사용한다
        var sb = new StringBuilder();
        // a,b 중에 더 긴 수를 찾고 그 길이를 구한다
        int len = Math.Max(a.Length, b.Length);
        // 더해서 10이 넘어가는 경우 다음 계산에 더해줄 변수
        int over = 0;
        // 구한 길이만큼 반복
        for (int i = 0; i < len; i++)
        {
            // a에서 뒤에서부터 인덱스에 해당하는 값
            int va = 0;
            if (a.Length > i)
            {
                va = a[a.Length - 1 - i] - '0';
            }
            // b에서 뒤에서부터 인덱스에 해당하는 값
            int vb = 0;
            if (b.Length > i)
            {
                vb = b[b.Length - 1 - i] - '0';
            }
            // a + b
            int vc = va + vb + over;
            // 10을 넘으면
            if (vc >= 10)
            {
                over = 1;
                vc -= 10;
            }
            else
            {
                over = 0;
            }
            // 결과값을 리턴값 맨 앞에 삽입
            sb.Insert(0, vc);
        }
        // 넘는값이 0이 아니면 삽입
        if (over > 0)
        {
            sb.Insert(0, 1);
        }
        // string으로 변환해서 리턴
        return sb.ToString();
    }

    /// <summary>
    /// 문자열 계산하기
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int Solution0320(string my_string)
    {
        int answer = 0;
        // my_string을 숫자와 연산자로 분리
        string[] str = my_string.Split(' ');
        // 연산자 부호를 대입할 변수
        int pm = 1;
        // 분리된 결과를 순회하면서
        foreach (var item in str)
        {
            // 숫자일 때 대입할 변수
            int temp = 0;
            // "+" 부호냐
            if (item.Equals("+"))
            {
                pm = 1;
            }
            // "-" 부호냐
            else if (item.Equals("-"))
            {
                pm = -1;
            }
            // 아니면 정수값
            else
            {
                temp = Convert.ToInt32(item);
            }
            // 부호에 맞는 값 계산
            answer += temp * pm;
        }
        return answer;
    }

    /// <summary>
    /// 커피 심부름
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public int Solution0319(string[] order)
    {
        int answer = 0;
        // order을 순회하면서
        foreach (var item in order)
        {
            // 특정단어가 포함되었냐 체크
            /*
            if (item.Contains("cafelatte"))
            {
                answer += 5000;
            }
            else
            {
                answer += 4500;
            }
            */
            answer += item.Contains("cafelatte") ? 5000 : 4500;
        }
        return answer;
    }

    /// <summary>
    /// 7의 개수
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int Solution0318(int[] array)
    {
        int answer = 0;
        // 배열의 모든 요소를 하나의 문자열로 만든다
        // StringBuilder를 사용하자
        var sb = new StringBuilder();
        foreach (var item in array)
        {
            sb.Append(item);
        }
        string str = sb.ToString();
        // 문자열을 순회하면서 7과 비교하자
        // 1. foreach 사용
        /*
        foreach (var item in str)
        {
            if (item == '7')
            {
                answer++;
            }
        }
        */
        // 2. Regex 사용
        // Count는 8.0부터 지원
        //answer = Regex.Count(str, "7");
        str = Regex.Replace(str, "[1-6890]", "");
        answer = str.Length;
        return answer;
    }

    /// <summary>
    /// 잘라서 배열로 저장하기
    /// </summary>
    /// <param name="my_str"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public string[] Solution0317(string my_str, int n)
    {
        // 크기를 알 수 있으면, 그 크기만큼 리턴 배열을 만든다
        // n보다 작은 값들이 남는 경우 크기에 1을 더한다
        //int len = my_str.Length / n;
        //if (my_str.Length % n > 0) len++;
        int len = (my_str.Length - 1) / n + 1;
        string[] answer = new string[len];
        // 필요한 인덱스, 카운터 정의
        int idx = 0, cnt = 0;
        // my_str을 순회하면서
        foreach (var item in my_str)
        {
            // answer에 하나씩 넣기
            answer[idx] += item;
            cnt++;
            // n만큼 넣었으면 idx 증가
            if (cnt == n)
            {
                idx++;
                cnt = 0;
            }
        }
        return answer;
    }

    /// <summary>
    /// 한 번만 등장한 문자
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string Solution0314(string s)
    {
        string answer = string.Empty;
        // Dictionary 사용 방법 ////////////////////////////////
        var dic = new Dictionary<char, int>();
        // s를 돌면서
        foreach (var item in s)
        {
            // char item 을 키로 검사해서
            if (dic.TryGetValue(item, out int val))
            {
                // 있으면 value를 증가
                //val++;
                //dic.Remove(item);
                //dic.Add(item, val);
                dic[item]++;
            }
            else
            {
                // 없으면 새로 넣고
                dic.Add(item, 1);
            }   
        }
        var list = new List<char>();
        // dic를 돌면서
        foreach (var item in dic)
        {
            // value가 1인 item만 list에 넣고
            if (item.Value == 1)
            {
                list.Add(item.Key);
            }
        }
        // list를 정렬
        list.Sort();
        // string으로 변환
        foreach (var item in list)
        {
            answer += item;
        }
        answer = string.Empty;
        // Split 사용방법 ///////////////////////////////////
        // Split해서 나온 결과배열이 크기가 2라면, 나누는 기준이 하나
        for (char c = 'a'; c <= 'z'; c++)
        {
            if (s.Split(c).Length == 2)
            {
                answer += c;
            }
        }
        return answer;
    }

    /// <summary>
    /// 숨어있는 숫자의 덧셈 (2)
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int Solution03132(string my_string)
    {
        int answer = 0;
        /*
        // 이전 item이 숫자인가 아닌가를 나타내는 bool 변수
        bool isNumber = false;
        // 계산된 수의 값 저장할 변수
        int val = 0;
        // my_string을 순회
        foreach (var item in my_string)
        {
            // 숫자만 검색
            // 자연수가 아니라고 비교조건에서 '0'을 빼게되면 
            // '10'같은걸 처리할 수 없으므로 주의!!!
            if ((item >= '0') && (item <= '9'))
            {
                // 이전 item이 숫자였냐?
                if (isNumber)
                {
                    // 숫자이면, 연속된 수로 계산
                    val = val * 10 + (item - '0');
                }
                else 
                {
                    // 아니면 계산된 수의 값을 구하고
                    val = (item - '0');
                    // 이전 item이 숫자였다고 표시
                    isNumber = true;
                }
            } 
            else // 숫자가 아니면
            {
                // 이전 item은 숫자가 아니었다고 표시
                isNumber = false;
                // answer에 계산된 수의 값을 더하고
                answer += val;
                // 계산된 수의 값은 초기화
                val = 0;
            }
        }
        // answer에 계산된 수의 값을 더하기
        answer += val;
        return answer;
        */
        // 다른 방법
        string str = Regex.Replace(my_string, "[a-zA-Z]", " ");
        string[] str2 = str.Split(' ');
        foreach (var item in str2)
        {
            // "" 같은 경우 에러나므로 걸러주자
            if (item.Length > 0)
            {
                answer += Convert.ToInt32(item);
            }
        }
        return answer;
    }

    /// <summary>
    /// 숨어있는 숫자의 덧셈 (1)
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public int Solution0313(string my_string)
    {
        int answer = 0;
        // my_string 하나씩 돌자
        foreach (var item in my_string)
        {
            // 얻어온 item이, '1'과 '9' 사이에 있다면
            if ((item >= '1') && (item <= '9'))
            {
                // answer에 그 값을 더한다
                answer += (item - '0');
            }
        }
        return answer;
    }

    /// <summary>
    /// 진료순서 정하기
    /// </summary>
    /// <param name="emergency"></param>
    /// <returns></returns>
    public int[] Solution0312(int[] emergency)
    {
        // 반환값의 크기를 알 수 있으니 그 크기만큼의 answer를 생성
        int[] answer = new int[emergency.Length];
        // 정렬을 사용해야 하므로, List 하나를 생성
        var list = new List<int>(emergency);
        // 정렬 (기본값 : 오름차순)
        list.Sort();
        // 정렬순서 바꾸기 (내림차순)
        list.Reverse();
        // 전체 크기만큼 반복
        for (int i = 0; i < answer.Length; i++)
        {
            // answer의 해당 인덱스에, emergency에서의 인덱스 값(+1)을 넣는다
            answer[i] = list.IndexOf(emergency[i]) + 1;
        }
        return answer;
    }

    /// <summary>
    /// 중복된 문자 제거
    /// </summary>
    /// <param name="my_string"></param>
    /// <returns></returns>
    public string Solution0311(string my_string)
    {
        string answer = string.Empty;
        // my_string을 한글자씩 돈다
        foreach (var item in my_string)
        {
            // item이 answer에 없으면
            if (!answer.Contains(item))
            {
                // answer에 item 추가
                answer += item;
            }
        }
        return answer;
    }

    /// <summary>
    /// 피자 나눠 먹기(2) - 최소공배수 구하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Solution0310(int n)
    {
        int answer = 0;
        // 조건을 만족하면 계속 반복
        do
        {
            // 피자 판 수 + 1
            answer++;
            // n, 6의 최소 공배수
            // 피자조각수를 n으로 나눠서 나머지가 0 인지
        } while (answer * 6 % n != 0);
        return answer;
    }

    /// <summary>
    /// 정수 부분
    /// </summary>
    /// <param name="flo"></param>
    /// <returns></returns>
    public int Solution03072(double flo)
    {
        int answer = 0;
        // 간단한 방법
        //answer = (int)(flo / 1);
        //answer = (int)flo;
        // 조금 복잡한 방법
        string str = flo.ToString();
        string[] strarr = str.Split(".");
        answer = Convert.ToInt32(strarr[0]);
        //answer = Convert.ToInt32(flo.ToString().Split(".")[0]);
        return answer;
    }

    /// <summary>
    /// 이차원 배열 대각선 순회하기
    /// </summary>
    /// <param name="board"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int Solution0307(int[,] board, int k)
    {
        int answer = 0;
        // i의 크기만큼 반복
        for (int i = 0; i < board.GetLength(0); i++)
        {
            // j의 크기만큼 반복
            for (int j = 0; j < board.GetLength(1); j++)
            {
                // 주어진 식을 만족하는 지
                if (i + j <= k)
                {
                    // 만족하면 총합에 추가
                    answer += board[i,j];
                }
            }
        }
        return answer;
    }

    /// <summary>
    /// 할 일 목록
    /// </summary>
    /// <param name="todo_list"></param>
    /// <param name="finished"></param>
    /// <returns></returns>
    public string[] Solution0306(string[] todo_list, bool[] finished)
    {
        // answer 배열의 크기를 구한다
        int len = 0;
        // foreach로 finished를 돌면서
        foreach (var item in finished)
        {
            // 못한 일이 있으면 크기 증가
            if (item == false)
            {
                len++;
            }
        }
        // 구해진 크기만큼의 answer를 생성한다
        string[] answer = new string[len];
        // answer에 사용할 인덱스 변수 하나 생성
        int ai = 0;
        // for문으로 돌면서
        for (int i = 0; i < finished.Length; i++)
        {
            // 할일을 못했으면
            if (finished[i] == false)
            {
                // answer에 todo_list에서의 인덱스 값 추가
                answer[ai] = todo_list[i];
                // answer에서 사용하는 인덱스 값 증가
                ai++;
            }
        }
        // answer 리턴
        return answer;
    }

    /// <summary>
    /// 인덱스 바꾸기
    /// </summary>
    /// <param name="my_string"></param>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public string Solution0305(string my_string, int num1, int num2)
    {
        string answer = string.Empty;
        // num1, num2에 해당하는 char를 얻어온다
        char chr1 = my_string[num1];
        char chr2 = my_string[num2];
        // for문으로 돌면서
        for (int i = 0; i < my_string.Length; i++)
        {
            // num1과 같으면
            if (i == num1)
            {
                // num2를 넣고
                answer += chr2;
            }
            // num2와 같으면
            else if (i == num2)
            {
                // num1을 넣고
                answer += chr1;
            }
            // 아니면
            else
            {
                // 원래 char를 넣고
                answer += my_string[i];
            }
        }
        return answer;
    }

    /// <summary>
    /// 외계행성의 나이
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    public string Solution0304(int age)
    {
        string answer = string.Empty;
        // age가 0보다 크면 반복
        while (age > 0)
        {
            // age의 1의 자리 숫자 추출
            int val = age % 10;
            // 숫자에 해당하는 값의 캐릭터형 변환
            char chr = Convert.ToChar(val + 'a');
            // answer의 앞에 추가
            answer = chr + answer;
            // age 자리수 변환
            age /= 10;
        }
        return answer;
    }

    /// <summary>
    /// 가장 큰 수 찾기
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public int[] Solution02282(int[] array)
    {
        int[] answer = new int[2];
        // dictionary 정의
        //Dictionary<int, int> dic = new Dictionary<int, int>();
        var dic = new Dictionary<int, int>();
        // dic에 array값 넣기
        int idx = 0;
        foreach (var item in array)
        {
            dic.Add(item, idx);
            idx++;
        }
        // 제일 큰 수 찾기 => list를 이용
        List<int> list = array.ToList();
        // list.Sort를 이용
        list.Sort();
        // 리턴배열에 넣기
        answer[0] = list[array.Length - 1]; // list[list.Count - 1]
        answer[1] = dic[answer[0]];
        return answer;
    }

    /// <summary>
    /// 가까운 1 찾기
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="idx"></param>
    /// <returns></returns>
    public int Solution0228(int[] arr, int idx)
    {
        // 특정 조건에 따른 반환값이 정해져 있다면, 그 값을 기본값으로 한다
        int answer = -1;
        // idx부터 arr의 크기만큼 반복
        for (int i = idx; i < arr.Length; i++)
        {
            // 1을 찾으면
            if (arr[i] == 1)
            {
                // answer에 인덱스 값을 넣고 break
                answer = i;
                break;
            }
        }
        return answer;
    }

    /// <summary>
    /// 369게임
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public int Solution0227(int order)
    {
        int answer = 0;
        // order를 string으로 변환
        string str = order.ToString();
        // string의 각 item을 반복
        foreach (var item in str)
        {
            // item이 3,6,9 일때만 answer++
            if (item.Equals('3') || 
                item.Equals('6') || 
                item.Equals('9'))
            {
                answer++;
            }
        }
        return answer;
    }

    /// <summary>
    /// 간단한 식 계산하기
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public int Solution0226(string str)
    {
        int answer = 0;
        // str을 분리
        string[] sa = str.Split(' ');
        // 각 숫자를 int로 변환
        int a = Convert.ToInt32(sa[0]);
        int b = Int32.Parse(sa[2]);
        // 각 수식에 맞게 분기, 계산
        switch (sa[1])
        {
            case "+":
                answer = a + b;
                break;
            case "-":
                answer = a - b;
                break;
            case "*":
                answer = a * b;
                break;
        }
        return answer;
    }

    /// <summary>
    /// 약수 구하기
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] Solution0224(int n)
    {
        // list를 하나 준비
        var list = new List<int>();
        // 1부터 n까지 반복
        for (int i = 1; i <= n; i++)
        {
            // n이 인덱스 값으로 나누어 떨어지면
            if (n % i == 0)
            {
                // 그게 약수니까 list에 넣는다
                list.Add(i);
            }
        }
        // list를 배열형으로 바꿔서 리턴한다
        return list.ToArray();
    }

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
