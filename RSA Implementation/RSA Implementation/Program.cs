using System;

namespace RSA_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m, i, k, d = 0;
            int p = 7;
            int q = 19;
            Console.Write("Please Enter your text here\n");
            var txt = Console.ReadLine();
            if (txt.Length < 1)
            {
                Console.Write("Cannot be empty\n");
                txt = Console.ReadLine();
            }
            var mssg = txt[0] - 65;
            n = p * q;
            m = (p - 1) * (q - 1);
            Console.WriteLine("Message in int: " + mssg);

            for (i = 2; i<m; i++)
            {
                if (GCD(i, m) == 1)
                {
                    break;
                }
            }

            Console.WriteLine($"Co-prime to the m:{m} is i:{i}");
            Console.WriteLine($"Public key: n:{n} i:{i}");

            for (k = 0; k <= 9; k++)
            {
                var x = 1 + (k * m);
                if (x % i != 0) continue;
                d = x / i;
                break;
            }

            Console.WriteLine($"d: {d}");
            Console.WriteLine($"Private key: p*q=n : {p}*{q}={n} d:{d}");
            Console.WriteLine($"char code is:{mssg}");
            long cipher = (long) ((Math.Pow(mssg, i)) % n);
            Console.WriteLine("Cipher is : " + cipher);
            var decryption  = modPow(cipher, d, n);
            Console.WriteLine("Decrypted message is : " + decryption);
        }

        // Function to return Greatest Common Divisor of a and b 
        static int GCD(int e, int z)
        {
            if (e == 0)
                return z;
            return GCD(z % e, e);
        }
        public static bool primeChecker(int num)
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        static int modPow(long bse, int exponent, int modulus)
        {
            int results = 1;
            bse = bse % modulus;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    results = (int) ((results * bse) % modulus);
                exponent = exponent >> 1;
                bse = (bse * bse) % modulus;
            }
            return results;
        }
    } 
}