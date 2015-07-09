using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_parser
{
    public class Laboriousness
    {
        public int N;
        public double Pp;
        public double Kn;
        public double Knp;
        public double K1;
        public double K2;
        public double K3;

        public Laboriousness()
        {
            N = -1;
            Pp = -1;
            Kn = -1;
            Knp = -1;
            K1 = -1;
            K2 = -1;
            K3 = -1;
        }

        public double CounLaboriousness()
        {
            double result = -1;
            result = (N / Pp) * (1 + 1 / Kn) * Knp * K1 * K2 * K3;

            return result;
        }

        public void BinarySearchForK2(int N)
        {
            int[] masN = { 100, 200, 300, 500, 700, 900, 1000, 2000, 3000, 4000, 5000, 10000, 20000, 30000, 40000, 50000, 60000, 80000, 100000 };

            int index = masN.Count() / 2;
            int center = masN[index];

            if (N > index)
            {

            }
            else
            {

            }
        }
    }
}
