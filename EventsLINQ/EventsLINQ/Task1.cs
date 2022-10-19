using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsLINQ
{
    public class Task1
    {
        private event Func<int, int, int> SumHendler;
        public int Res()
        {
            SumHendler += Sum;
            SumHendler += Sum;

            var res = 0;

            foreach (var item in SumHendler.GetInvocationList())
            {
                res += (int)item.DynamicInvoke(2, 4);
            }

            return res;
        }

        public void Run(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private int Sum(int x, int y) => x + y;
    }
}
