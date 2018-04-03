using System;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
        static int[] m;
        static int[] k;
        static int[,] dp;
        static void InputArr(out int[]m, out int[] k)
        {
            StreamReader nwReader = new StreamReader(@"input.txt", Encoding.Default);
            int nwLength = Convert.ToInt32(nwReader.ReadLine());
            m = new int[nwLength];
            k = new int[nwLength];
            for (int i = 0; i < nwLength; i++)
            {
                string[] curData = nwReader.ReadLine().Split();
                m[i] = Convert.ToInt32(curData[0]);
                k[i] = Convert.ToInt32(curData[1]);
            }
            nwReader.Close();
        }
        static void OutputRes(int res)
        {
            StreamWriter nwWriter = new StreamWriter(@"output.txt", false, Encoding.Default);
            nwWriter.WriteLine(res);
            nwWriter.Close();
        }

        static int CountRes(int start, int end)
        {
            if (end - start == 0)
                return 0;
            if (end - start == 1)
                return m[start] * k[end];
            if (dp[start, end] != -1)
                return dp[start, end];
            int dopRes = 1000000000;
            for (int i = end-1; i >= start; i--)
            {
                int curRes = CountRes(start, i) + CountRes(i + 1, end);
                if (curRes < dopRes)
                    dopRes = curRes;
            }
            dp[start, end] = m[start] * k[end] + dopRes;
            return dp[start, end];

        }
        static void CreateDP()
        {
            dp = new int[m.Length+1, m.Length+1];
            for (int i = 0; i < dp.GetLength(0); i++)
                for (int j = 0; j < dp.GetLength(1); j++)
                    dp[i, j] = -1;
        }
        static void Main(string[] args)
        {            
            InputArr(out m, out k);
            CreateDP();
            int result = CountRes(0, m.Length-1);
            OutputRes(result);
        }
    }
}
