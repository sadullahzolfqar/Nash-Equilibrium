using System;
using System.Collections.Generic;
using System.Text;

namespace Nash_Dengesi_UI
{
    class ComputeNash
    {
        private int FirstPlayer_Number_Strat = 3;
        private int SecondPlayer_Number_Strat = 3;

        int[,] FirstPlayer_PayOffs ;
        int[,] SecondPlayer_PayOffs;

        List<string> fp_NashIndex;
        List<string> Sp_NashIndex;

        public ComputeNash(int FirstPlayer_Number_Strat,int SecondPlayer_Number_Strat)
        {
            this.FirstPlayer_Number_Strat=FirstPlayer_Number_Strat;
            this.SecondPlayer_Number_Strat = SecondPlayer_Number_Strat;

            FirstPlayer_PayOffs = new int[FirstPlayer_Number_Strat, SecondPlayer_Number_Strat];
            SecondPlayer_PayOffs= new int[FirstPlayer_Number_Strat, SecondPlayer_Number_Strat];
            
        }

        public int[,] GetFirstPlayer_PayOffs()
        {
            return FirstPlayer_PayOffs;
        }

        public int[,] GetSecondPlayer_PayOffs()
        {
            return SecondPlayer_PayOffs;
        }

        public void setPlayerData(int[] FirstPlayerData,int[] SecondPlayerData)
        {
            int Data_Index = 0;
            for(int row = 0; row < FirstPlayer_Number_Strat; row++)
            {
                for(int col = 0; col < SecondPlayer_Number_Strat; col++)
                {
                    FirstPlayer_PayOffs[row, col] = FirstPlayerData[Data_Index];
                    SecondPlayer_PayOffs[row, col] = SecondPlayerData[Data_Index];
                    Data_Index++;
                }
            }

        }


        public List<string> Compute_Result()
        {
            List<string> FPlayer = new List<string>();
            List<string> SecPlayer = new List<string>();

            for (int i=0;i< SecondPlayer_Number_Strat; i++)
            {
                int enbuyuk = FirstPlayer_PayOffs[0, i];
                FPlayer.Add(0.ToString() + "," + i.ToString());
                for (int j=1;j< FirstPlayer_Number_Strat; j++)
                {
                    if (FirstPlayer_PayOffs[j, i] > enbuyuk)
                    {
                        FPlayer.RemoveRange(i,FPlayer.Count-i);

                        enbuyuk = FirstPlayer_PayOffs[j, i];

                        FPlayer.Add(j.ToString() + "," + i.ToString());
                    }

                    else if(FirstPlayer_PayOffs[j, i] == enbuyuk)
                    {
                        enbuyuk = FirstPlayer_PayOffs[j, i];

                        FPlayer.Add(j.ToString() +","+ i.ToString());
                    }

                }
            }

            for (int i = 0; i < FirstPlayer_Number_Strat; i++)
            {
                int enbuyuk = SecondPlayer_PayOffs[i, 0];
                SecPlayer.Add(i.ToString() + "," + 0.ToString());
                for (int j = 1; j < SecondPlayer_Number_Strat; j++)
                {
                    if (SecondPlayer_PayOffs[i, j] > enbuyuk)
                    {
                        SecPlayer.RemoveRange(i, SecPlayer.Count - i);

                        enbuyuk = SecondPlayer_PayOffs[i, j];

                        SecPlayer.Add(i.ToString() + "," + j.ToString());
                    }

                    else if (SecondPlayer_PayOffs[i, j] == enbuyuk)
                    {
                        enbuyuk = SecondPlayer_PayOffs[i, j];

                        SecPlayer.Add(i.ToString() + "," + j.ToString());
                    }

                }
            }

            fp_NashIndex = FPlayer;
            Sp_NashIndex = SecPlayer;

            string result = "";

            List<string> ResultList = new List<string>();

            if (FPlayer.Count > SecPlayer.Count)
            {
                foreach(string str in SecPlayer)
                {
                    foreach(string str2 in FPlayer)
                    {
                        if (str.Equals(str2))
                        {

                            string[] IndexSplit = str.Split(',');
                            result = FirstPlayer_PayOffs[Int32.Parse(IndexSplit[0]), Int32.Parse(IndexSplit[1])].ToString()+","+SecondPlayer_PayOffs[Int32.Parse(IndexSplit[0]), Int32.Parse(IndexSplit[1])].ToString();
                            ResultList.Add(result);
                        }
                    }
                }
            }
            else
            {
                foreach (string str in FPlayer)
                {
                    foreach (string str2 in SecPlayer)
                    {
                        if (str.Equals(str2))
                        {
                            string[] IndexSplit = str.Split(',');
                            result = FirstPlayer_PayOffs[Int32.Parse(IndexSplit[0]), Int32.Parse(IndexSplit[1])].ToString() + "," + SecondPlayer_PayOffs[Int32.Parse(IndexSplit[0]), Int32.Parse(IndexSplit[1])].ToString();
                            ResultList.Add(result);
                        }
                    }
                }
            }

            return ResultList;
        }
        
        public static double[] compute_PandQ(int[] FirstPlayerData, int[] SecondPlayerData)
        {

            double[] result = new double[2];


            result[0] = (double)(FirstPlayerData[3] - FirstPlayerData[1]) / (FirstPlayerData[0] - FirstPlayerData[1] - FirstPlayerData[2] + FirstPlayerData[3]);
            result[1] = (double)(SecondPlayerData[3] - SecondPlayerData[2]) / (SecondPlayerData[0] - SecondPlayerData[2] - SecondPlayerData[1] + SecondPlayerData[3]);
            return result;
        }

        public List<string> comput_AandB_NashEquel(int[] FirstPlayerData,int[] SecondPlayerData)
        {
            double[] result_PandG = compute_PandQ(FirstPlayerData, SecondPlayerData);
            double p = result_PandG[0], q = result_PandG[1];

            double[,] pq_Matris = new double[,]{ 
                                                 {p*q,q*(1-p) },
                                                 {p*(1-q),(1-q)*(1-p)}
                                               };

            double firstPlayerNashEquel = 0;
            double SecondPlayerNashEquel = 0;

            for (int i=0;i< FirstPlayer_Number_Strat; i++)
            {
                for(int j = 0; j < SecondPlayer_Number_Strat; j++)
                {
                    firstPlayerNashEquel += FirstPlayer_PayOffs[i,j] * pq_Matris[i, j];
                    SecondPlayerNashEquel += SecondPlayer_PayOffs[i, j] * pq_Matris[i, j];
                }
            }

            return new List<string> { firstPlayerNashEquel.ToString(), SecondPlayerNashEquel.ToString() };
        }

        public List<string> f_NashIndexGet()
        {
            return fp_NashIndex;
        }
        public List<string> S_NashIndexGet()
        {
            return Sp_NashIndex;
        }

    }

    class computeNashResult
    {
        public List<string> Nashresult { get; set; }
        public Boolean isMixed { get; set; }
        public List<string> fp_NashIndex { get; set; }
        public List<string> Sp_NashIndex { get; set; }
    }

}
