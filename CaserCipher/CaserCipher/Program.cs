using System;

namespace CaserCipher
{
    class Program
    {
         static string encryptedText  = "";
        private static string shiftAmountText = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Mohammed asim Uddin");

            var command = "";
            do
            {
                Console.WriteLine("E encrypt");
                Console.WriteLine("D decrypt");
                command = Console.ReadLine()?.Trim().ToUpper() ?? "";
                switch (command)
                {
                    case "E":
                        RunCaesarEncrypt();
                        break;
                    case "D":
                        RunCaesarDecrypt();
                        break;
                }
            } while (command != "X");
        }


        static void RunCaesarEncrypt()
        {
            Console.WriteLine("Text to encrypt");
            Console.WriteLine(">");

            string plainText = Console.ReadLine()?.Trim().ToUpper() ?? ""; // extended ternary operator

            Console.WriteLine("Amount to shift");
            Console.WriteLine(">");
            shiftAmountText = Console.ReadLine();

            if (int.TryParse(shiftAmountText, out var shiftAmount))
            {
                encryptedText = CaesarEncrypt(plainText, shiftAmount);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("shift:" + shiftAmount);
                Console.WriteLine("original" + plainText);
                Console.WriteLine("encrypted" + encryptedText);
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine("Error: " + shiftAmountText + "is not a number");
            }
        }

        static void RunCaesarDecrypt()
        {
            if (int.TryParse(shiftAmountText, out var shiftAmount))
            {
                string decryptedText = CaesarDecrypt(encryptedText, shiftAmount);
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("shift: " + shiftAmount);
                Console.WriteLine("encryptedText: " + encryptedText);
                Console.WriteLine("decrypted: " + decryptedText);
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine("Error: " + shiftAmountText + "is not a number");
            }
        }

        private static char[] _alphabet= new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
            'V', 'W', 'X', 'Y', 'Z'
        };

        static string CaesarEncrypt(string plainText, int shiftAmount)
        {
            Console.WriteLine("Alphabet size: " + _alphabet.Length);
            string result = "";
            for (int i = 0; i < plainText.Length; i++)
            {
                var letter = plainText[i];
                var indexInAlphabet = Array.IndexOf(_alphabet, letter);
                indexInAlphabet = (indexInAlphabet + shiftAmount) % _alphabet.Length;
                result = result + _alphabet[indexInAlphabet];
            }

            return result;
        }

        static string CaesarDecrypt(string encryptedText, int shiftAmount)
        {
            string result = "";
            Console.WriteLine("Decrypting.........................");
            for (int i = 0; i < encryptedText.Length; i++)
            {
                var letter = encryptedText[i];
                var indexInAlphabet = Array.IndexOf(_alphabet, letter);
                indexInAlphabet = (indexInAlphabet - shiftAmount) % _alphabet.Length;
                result = result + _alphabet[indexInAlphabet];
            }

            return result;
        }
    }
}