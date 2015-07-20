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
        public double laboriousness;
        public double resultVal;
        public double dayDuration;

        public Laboriousness()
        {
            N = 0;
            Pp = 2.88;
            Kn = 0.58;
            Knp = 0.5;
            K1 = 0.5;
            K2 = 0.5;
            K3 = 1.0;
            dayDuration = 8.25;
            laboriousness = 0;
            resultVal = 0;
        }

        public double CounLaboriousness()
        {
            double result = -1;
            result = (N / Pp) * (1 + 1 / Kn) * Knp * K1 * K2 * K3;

            return Math.Round(result, 2);
        }

        public struct Result
        {
            public double key;
            public double value;

            public override string ToString()
            {
                return string.Format("Key: {0} Value:{1}", key, value);
            }
        }

        public Result SearchK2(int N, double delta)
        {
            Dictionary<int, double> K2_dic = new Dictionary<int, double>();
            K2_dic.Add(100, 1.0);
            K2_dic.Add(200, 1.03);
            K2_dic.Add(300, 1.06);
            K2_dic.Add(500, 1.09);
            K2_dic.Add(700, 1.14);
            K2_dic.Add(900, 1.20);
            K2_dic.Add(1000, 1.32);
            K2_dic.Add(2000, 1.49);
            K2_dic.Add(3000, 1.55);
            K2_dic.Add(4000, 1.65);
            K2_dic.Add(5000, 1.77);
            K2_dic.Add(10000, 1.90);
            K2_dic.Add(20000, 2.03);
            K2_dic.Add(30000, 2.16);
            K2_dic.Add(40000, 2.35);
            K2_dic.Add(50000, 2.90);
            K2_dic.Add(60000, 3.0);
            K2_dic.Add(80000, 3.0);
            K2_dic.Add(100000, 3.0);

            Result result = new Result();

            var maximum = K2_dic.FirstOrDefault(x => x.Key > N);

            if (maximum.Key == 0)
            {
                Result max = new Result();
                max.key = 100000;
                max.value = 3;

                //return max;
            }

            var minimum = K2_dic.LastOrDefault(x => x.Key < N);            

            Result bottom = new Result();
            bottom.key = minimum.Key;
            bottom.value = minimum.Value;

            Result upper = new Result();
            upper.key = maximum.Key;
            upper.value = maximum.Value;            

            result.key = ((upper.key + bottom.key) / 2.0);
            result.value = ((upper.value + bottom.value) / 2.0);

            while (Math.Abs(N - result.key) > delta)
            {
                if (N < result.key)
                {
                    upper = result;   
                }
                else
                {                    
                    bottom = result; 
                }

                result.key = ((upper.key + bottom.key) / 2.0);
                result.value = ((upper.value + bottom.value) / 2.0);
            }

            return result;
        }
    }
}
