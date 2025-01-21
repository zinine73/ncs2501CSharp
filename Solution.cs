class Solution
{
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
