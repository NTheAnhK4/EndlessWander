

public static class ProcessSignal 
{
    public static int ConvertToInt(string signal, int l, int r)
    {
        int res = 0;
        int baseVal = 1;
        for (int i = r; i >= l; --i)
        {
            res += (int)(signal[i] - '0') * baseVal;
            baseVal *= 10;
        }

        return res;
    }
}
