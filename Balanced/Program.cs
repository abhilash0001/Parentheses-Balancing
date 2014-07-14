using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new List<string>
            {
                "(if (any? x) sum (/1 x))",
                "I said (it's not (yet) complete). (she didn't listen)",
                ":-)",
                "())("
            };

            inputs.ForEach(i => Console.Write(string.Format("Expression: {0} \nResult: {1}\n\n", i, CheckBalanced(i))));
            Console.Read();
        }

        private static bool CheckBalanced(string str)
        {
            var index = 0;
            return CheckBalanced(str, ref index, false);
        }

        private static bool CheckBalanced(string str, ref int index, bool inParenthesis)
        {
            while (index < str.Length)
            {
                switch (str[index++])
                {
                    case '(':
                        if (!CheckBalanced(str, ref index, true))
                            return false;
                        break;
                    case ')':
                        return inParenthesis;
                }
            }
            return !inParenthesis;
        }
    }
}
