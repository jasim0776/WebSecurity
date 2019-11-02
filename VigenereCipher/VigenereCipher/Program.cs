using System;

namespace VigenereCipher
{
    class VCipher
    {
        public string encrypt(string txt, string key, int d)
        {
            int pwi = 0, tmp;
            string ns = "";
            txt = txt.ToUpper();
            key = key.ToUpper();
            foreach (char t in txt)
            {
                if (t < 65) continue;
                tmp = t - 65 + d * (key[pwi] - 65);
                if (tmp < 0) tmp += 26;
                ns += Convert.ToChar(65 + ( tmp % 26) );
                if (++pwi == key.Length) pwi = 0;
            }
 
            return ns;
        }
    };
 
    class Program
    {
        static void Main(string[] args)
        {
            VCipher X = new VCipher();
 
            string message = "Good bye to you my trusted friend, We have known each others since we were nine or ten. ",
                key = "VIGENERECIPHER";
 
            Console.WriteLine(message + "\n" + key + "\n");
            string s1 = X.encrypt(message, key, 1);
            Console.WriteLine("Encrypted: " + s1);
            s1 = X.encrypt(s1, "VIGENERECIPHER", -1);
            Console.WriteLine("Decrypted: " + s1);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}