using System;
using System.Collections.Generic;
using System.Text;

namespace Craps
{
    public struct des
    {
        public void affichDes(int de1, int de2)
        {
            string[] des = new string[31];

            des[1] = "+-------+";
            des[2] = "|       |";
            des[3] = "|   O   |";
            des[4] = "|       |";
            des[5] = "+-------+";

            des[6] = "+-------+";
            des[7] = "| O     |";
            des[8] = "|       |";
            des[9] = "|     O |";
            des[10] = "+-------+";

            des[11] = "+-------+";
            des[12] = "|     O |";
            des[13] = "|   O   |";
            des[14] = "| O     |";
            des[15] = "+-------+";

            des[16] = "+-------+";
            des[17] = "| O   O |";
            des[18] = "|       |";
            des[19] = "| O   O |";
            des[20] = "+-------+";

            des[21] = "+-------+";
            des[22] = "| O   O |";
            des[23] = "|   O   |";
            des[24] = "| O   O |";
            des[25] = "+-------+";

            des[26] = "+-------+";
            des[27] = "| O   O |";
            des[28] = "| O   O |";
            des[29] = "| O   O |";
            des[30] = "+-------+";

            for (int i = 0; i < 5; i++)
            {
                Console.Write(des[(de1 * 5) - i] + des[(de2 * 5) - i] + "\n");
            }
        }
    }
}
