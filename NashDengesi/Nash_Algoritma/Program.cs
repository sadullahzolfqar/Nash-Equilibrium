using System;

namespace Nash_Algoritma
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeNash computeNash = new ComputeNash();
            int[] data1 = new int[] { 1,10,-10,0,1,10,1,1,1 };
            int[] data2 = new int[] { 1,0,1,10,1,1,-10,10,1 };

            computeNash.setPlayerData(data1, data2);

            int[,] firstPlayerPay = computeNash.GetFirstPlayer_PayOffs();
            int[,] SecondPlayerPay = computeNash.GetSecondPlayer_PayOffs();

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(firstPlayerPay[i, j] + "," + SecondPlayerPay[i, j]);
                    Console.Write("  ");
                }
               
                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (string result in computeNash.Compute_Result())
            {
                Console.Write("Result: " + result+" , ");
            }
           

           //Console.WriteLine("Hello World!");
        }
    }
}
