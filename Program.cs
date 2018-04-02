using System;
using System.Text;
using System.IO;

namespace Task2
{
    class Program
    {
        static void InputArr(out int[]nArr)
        {
            StreamReader nwReader = new StreamReader(@"input.txt", Encoding.Default);
            int nwLength = Convert.ToInt32(nwReader.ReadLine());
            nArr = new int[nwLength*2 - (nwLength-1)];
            for (int i = 0; i <= nwLength; i++)
            {
                string[] curData = nwReader.ReadLine().Split();
                if (i == 0)
                {
                    nArr[i] = Convert.ToInt32(curData[0]);
                    i++;
                }
                nArr[i] = Convert.ToInt32(curData[1]);
            }
            nwReader.Close();
        }
        static void OutputRes(int res)
        {
            StreamWriter nwWriter = new StreamWriter(@"output.txt", false, Encoding.Default);
            nwWriter.WriteLine(res);
            nwWriter.Close();
        }
        static int FindPosMin(int [] arr, int startPos)
        {
            int min = startPos;
            for (int i = startPos; i < arr.Length; i++)
                if (arr[i] <= arr[min])
                    min = i;
            return min;
        }
        static int[] RemoveRange(int [] arr, int startPos, int endPos)
        {
            int[] nArr = new int[arr.Length - (endPos - startPos + 1)];
            for (int i = 0, j = 0; i < nArr.Length; i++, j++)
            {
                while (j >= startPos && j <= endPos)
                    j++;
                nArr[i] = arr[j];
            }
            return nArr;
        }
        static int CountRes(int [] curArr)
        {
            int startPos = 2;
            int curPos = 0;
            int result = 0;
            while (curArr.Length > 2)
            {
                curPos = FindPosMin(curArr, startPos);
                for (int i = curPos - 2; i >= 0; i--)
                {
                    int curResult = curArr[curPos] * curArr[i];
                    if (i > 0)
                    {
                        if (curArr[i - 1] * curArr[i + 1] < curResult)
                        {
                            result += curArr[i - 1] * curArr[i + 1];
                            curArr = RemoveRange(curArr, i, i);
                        }
                        else
                        {
                            result += curResult;
                            curArr = RemoveRange(curArr, i + 1, i+1);
                        }
                    }
                    else
                    {
                        result += curResult;
                        curArr = RemoveRange(curArr, i + 1, i + 1);
                    }
                    curPos--;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] curArr;
            InputArr(out curArr);
            int result = CountRes(curArr);
            OutputRes(result);
        }
    }
}
