class TupleTest
{
    public (int count, int sum, double average) Calculate(List<int> data)
    {
        int cnt = 0;
        int sum = 0;
        double avg = 0;

        foreach (var i in data)
        {
            cnt++;
            sum += i;
        }
        avg = sum / cnt;

        return (cnt, sum, avg);
    }

    public (int sum, int sub) Calc(int a, int b)
    {
        return (a + b, a - b);
    }
}