using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace bingo
{
    class Program
    {
        private static void swap(ArrayList ar, int x, int y)
        {
            int temp = 0;
            temp = Convert.ToInt16(ar[x]);
            ar[x] = ar[y];
            ar[y] = temp;
            //int temp = 0;
            //temp = Convert.ToInt16(ar[1]);
            //ar[1] = ar[24];
            //ar[24] = temp;
        }

        //列印5*5的賓果畫面出來
        private static void printAr(ArrayList ar)
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = (i - 1) * 5; j < i * 5; j++)
                {
                    Console.Write($"{ar[j]}\t");
                }
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            //1.一個一維陣列紀錄 1-25 的數字
            ArrayList ar = new ArrayList();
            for (int i = 1; i <= 25; i++)
            {
                ar.Add(i);
            }

            //2.透過兩兩交換的方式，達到每一次出現的順序不同的需求
            //Random 門牌
            Random r = new Random();
            int swapCnt = r.Next(10, 20); //==> 產生兩兩交換的次數有幾次
            for (int i = 0; i < swapCnt; i++)
            {
                swap(ar, r.Next(0, 25), r.Next(0, 25));
                //foreach (var item in ar)
                //{
                //    Console.Write($"{item}-");
                //}
                //Console.Write("\n\n");
            }

            //3.把ar列印出來(雙重迴圈)
            printAr(ar);

            //4.輸入一個數字
            Console.Write("請輸入數字：");
            int input = int.Parse(Console.ReadLine());

            //6.用while包起來，反覆執行 4 & 5
            while (input > 0)
            {
                if (!ar.Contains(input))
                {
                    Console.Write("數字不存在，請輸入數字：");
                    input = int.Parse(Console.ReadLine());
                    continue;
                }

                //5.找出該數字位於陣列中的位置(門牌號碼)，然後開門，把元素(內容物)換成空白
                int pos = ar.IndexOf(input);
                //Console.WriteLine($"pos ==> {pos}");

                ar[pos] = "●";
                printAr(ar);

                int tempCnt = 0;
                int lineCnt = 0;
                //7.橫向連線
                for (int i = 1; i <= 5; i++)
                {
                    tempCnt = 0;
                    for (int j = (i - 1) * 5; j < i * 5; j++)
                    {
                        if (ar[j].ToString() == "●")
                        {
                            tempCnt += 1;
                        }
                    }
                    if (tempCnt == 5)
                    {
                        lineCnt += 1;
                    }
                }

                //8.直向連線
                for (int i = 0; i < 5; i++)
                {
                    tempCnt = 0;
                    for (int j = i; j <= 20 + i; j = j + 5)
                    {
                        if (ar[j].ToString() == "●")
                        {
                            tempCnt += 1;
                        }
                    }
                    if (tempCnt == 5)
                    {
                        lineCnt += 1;
                    }
                }

                //9.左上右下連線 => 0,6,12,18,24
                tempCnt = 0;
                for (int i = 0; i < 25; i += 6)
                {
                    if (ar[i].ToString() == "●")
                    {
                        tempCnt += 1;
                        //Console.WriteLine($"tempCnt ==> {tempCnt}");
                    }
                }
                if (tempCnt == 5)
                {
                    lineCnt += 1;
                    //Console.WriteLine($"lineCnt ==> {lineCnt}");
                }
                //10.右上左下連線 => 4,8,12,16,20
                tempCnt = 0;
                for (int i = 4; i <= 20; i += 4)
                {
                    if (ar[i].ToString() == "●")
                    {
                        tempCnt += 1;
                        //Console.WriteLine($"tempCnt ==> {tempCnt}");
                    }
                }

                if (tempCnt == 5)
                {
                    lineCnt += 1;
                    //Console.WriteLine($"lineCnt ==> {lineCnt}");
                }

                if (lineCnt == 5)
                {
                    Console.WriteLine("恭喜贏得遊戲");
                    break;
                }

                Console.Write("請輸入數字：");
                input = int.Parse(Console.ReadLine());
            }
        }
    }
}
