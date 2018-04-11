using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask7
{
    class Program
    {
        // Task: define to which of the 5 closed classes (T1, T0, L, S, M) input boolean function belongs.
        // Boolean function is presented as a vector.
        // Student: Alexey Subbotin. Group: SE-17-1.
        static void Main(string[] args)
        {
            // The number of digits in a vector (should be equal to a degree of 2).
            int n;

            // n input.
            bool ok;
            bool ok1;
            int degree;
            do
            {
                Console.Write("Enter the number of digits in the vector: ");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                ok1 = Int32.TryParse(Math.Log(n ,2).ToString(), out degree);
                if (!ok || n < 0 || !ok1)
                    Console.WriteLine("Input error! Perhaps you didn't a natural number that should be a degree of the number 2");
            } while (!ok || n < 0 || !ok1);

            // Creating the vector.
            string vector = "";
            Console.WriteLine("Enter the vector: ");
            for(int i = 0; i < n; i++)
            {
                int temp;
                do
                {
                    ok = Int32.TryParse(Console.ReadLine(), out temp);
                    if (!ok || temp != 1 && temp != 0)
                        Console.WriteLine("Input error! Perhaps you didn't enter 0 or 1");
                    else
                        vector += temp;
                } while (!ok || temp != 1 && temp != 0);
            }

            Console.WriteLine("T0: " + CheckT0(vector));
            Console.WriteLine("T1: " + CheckT1(vector));
            Console.WriteLine("L: " + CheckL(vector));
            Console.WriteLine("S: " + CheckS(vector));
            Console.WriteLine("M: " + CheckM(vector.Substring(0, vector.Length / 2), 
                vector.Substring(vector.Length / 2, vector.Length / 2)));

            Console.ReadLine();
        }

        // Checking T0.
        public static bool CheckT0(string vector)
        {
            // Function belongs to the T0 class if f(0,0,..,0) = 0.

            if (vector[0] == '0')
                return true;
            else
                return false;
        }

        // Checking T1.
        public static bool CheckT1(string vector)
        {
            // Function belongs to the T0 class if f(1,1,..,1) = 1.

            if (vector[vector.Length - 1] == '1')
                return true;
            else
                return false;
        }

        // Checking L.
        public static bool CheckL(string vector)
        {
            // Function belongs to the L class if the number of 0s and the number of 1s are even (can check only 0s because the number of digits is even).

            int count0 = 0;

            for(int i = 0; i < vector.Length; i++)
            {
                if (vector[i] == '0')
                    count0++;
            }

            if (count0 % 2 == 0)
                return true;
            else
                return false;
        }

        // Checking S.
        public static bool CheckS(string vector)
        {
            // Function belongs to the S class if opposite sets have opposite results. 

            bool belongs = true;
            for(int i = 0; i < vector.Length / 2; i++)
            {
                if (vector[i] == vector[vector.Length - i - 1])
                {
                    belongs = false;
                    break;
                }
            }
            return belongs;
        }

        // Checking M with a classic algorithm.
        public static bool CheckM(string s1, string s2)
        {
            if(s1.Length != 1 && s2.Length != 1)
            {
                for(int i = 0; i < s1.Length; i++)
                {
                    if ((int)s1[i] > (int)s2[i])
                        return false;
                }
                bool ok1 = CheckM(s1.Substring(0, s1.Length / 2), s1.Substring(s1.Length / 2, s1.Length / 2));
                bool ok2 = CheckM(s2.Substring(0, s2.Length / 2), s2.Substring(s2.Length / 2, s2.Length / 2));

                return ok1 && ok2;
            }
            else
            {
                if (Convert.ToInt32(s1) <= Convert.ToInt32(s2))
                    return true;
                else
                    return false;
            }
        }
    }
}
