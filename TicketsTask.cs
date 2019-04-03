using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public static class TicketsTask
    {
        private static Dictionary<string,BigInteger> dic;
        
        public static BigInteger Solve(int totalLen, int totalSum)
        {
            if (totalSum % 2 == 1) return 0;
            dic = new Dictionary<string,BigInteger>();
            var result = GetTicketCount(totalLen, totalSum / 2);
            return result * result;
        }

        private static BigInteger GetTicketCount(int v, int sum)
        {
            var key = $"{v},{sum}";
            if (sum < 0) return 0;

            if (dic.ContainsKey(key)) return dic[key];
            
            switch (v)
            {
                case 0 when sum == 0:
                    dic[key] = 1;
                    return 1;
                case 0 when sum != 0:
                    dic[key] = 0;
                    return 0;
            }

            BigInteger ans = 0;

            for (var i = 0; i < 10; i++)
                ans += GetTicketCount(v - 1, sum - i);

            dic[key] = ans;

            return ans;
        }
    }
}
