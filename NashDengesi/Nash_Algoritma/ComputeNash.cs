using System;
using System.Collections.Generic;
using System.Text;

namespace Nash_Algoritma
{
    class ComputeNash
    {
        private int FirstPlayer_Number_Strat = 3;
        private int SecondPlayer_Number_Strat = 3;

        int[,] FirstPlayer_PayOffs ;
        int[,] SecondPlayer_PayOffs;

        public ComputeNash()
        {
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
      

    }
}
