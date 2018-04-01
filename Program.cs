using System;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
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
        static int CountRes(int [] m, int[] k, int startPos, int endPos)
        {
            if (endPos - startPos == 0)
                return 0;
            if (endPos - startPos == 1)
            {
                m[endPos] = m[endPos - 1];
                k[endPos - 1] = k[endPos];
                return m[endPos - 1] * k[endPos];
            }
            int midPos = startPos + (endPos - startPos) / 2;
            int leftBranch = CountRes(m, k, startPos, midPos - 1);
            int rightBranch = CountRes(m, k, midPos + 1, endPos);
            int curRes = leftBranch + rightBranch;
            if (m[midPos - 1] * k[midPos] < m[midPos] * k[midPos + 1])
            {
                curRes += m[midPos - 1] * k[midPos];
                m[midPos] = m[midPos - 1];
                curRes += m[midPos] * k[midPos + 1];
                k[midPos] = k[midPos + 1];
            }
            else
            {
                curRes += m[midPos] * k[midPos + 1];
                k[midPos] = k[midPos + 1];
                curRes += m[midPos - 1] * k[midPos];
                m[midPos] = m[midPos - 1];
            }
            for (int i = startPos; i <= endPos; i++)
            {
                m[i] = m[midPos];
                k[i] = k[midPos];
            }
            return curRes;
        }
        static void Main(string[] args)
        {
            int[] m;
            int[] k;
            InputArr(out m, out k);
            int result = CountRes(m, k, 0, m.Length - 1);
            OutputRes(result);
        }
    }
}
