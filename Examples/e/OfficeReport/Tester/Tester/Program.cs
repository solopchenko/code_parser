using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> range = new List<int>(){100, 200, 300, 400, 500, 600};
            List<int> index = new List<int>(){10, 20, 30, 40, 50, 60};
            
            Dictionary<int, int> ind = new Dictionary<int, int>() {{100, 10}, {200, 20}, {300, 30}, {400, 40}};

            Result result = new Result();

            int value = 120;

            //var max = ind.FirstOrDefault(x=> x.Key > value);
            //var min = ind.LastOrDefault(x => x.Key < value);

            //result.key = (max.Key + min.Key) / 2.0;
            //result.value = (max.Value + min.Value) / 2.0;

            //Console.WriteLine(result);
            //Console.ReadKey();

            var maximum = ind.FirstOrDefault(x => x.Key > value);

            if (maximum.Key == 0)
            {
                Result max = new Result();
                max.key = 400;
                max.value = 40;

                Console.WriteLine(max);
                Console.ReadKey();
                return;
            }
            
            var minimum = ind.LastOrDefault(x => x.Key < value);            

            Result bottom = new Result();
            bottom.key = minimum.Key;
            bottom.value = minimum.Value;

            Result upper = new Result();
            upper.key = maximum.Key;
            upper.value = maximum.Value;            

            double delta = 5;

            result.key = ((upper.key + bottom.key) / 2.0);
            result.value = ((upper.value + bottom.value) / 2.0);

            while (Math.Abs(value - result.key) > delta)
            {
                if (value < result.key)
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

            Console.WriteLine(result);
            Console.ReadKey();
        }

        struct  Result
        {
           public double key;
           public double value;

            public override string ToString()
            {
                return string.Format("Key: {0} Value:{1}", key, value);
            }
        }
    }
}
