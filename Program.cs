using System;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
        static int[] m;
        static int[] k;
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

        static int CountRes(int length, int startPos)
        {
            if (length < 1)
                return 0;
            return m[startPos] * k[length + startPos] +
                Math.Min(CountRes(length - 1, startPos), CountRes(length - 1, startPos + 1));
        }
        static void Main(string[] args)
        {            
            InputArr(out m, out k);
            int result = CountRes(m.Length-1, 0);
            OutputRes(result);
        }
    }
}
