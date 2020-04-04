using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Utilities
{
    public class CaesarCipher
    {
        public CaesarCipher()
        {

        }
        
        public string Encrypt(string text, int keyup)
        {

            string encriptedText = "";
            char character;
            int asciiNumber;

            for (int i = 0; i < text.Length; i++)
            {
                character = ' ';
                asciiNumber = 0;

                if (text[i] == ' ')
                {
                    encriptedText += ' ';
                    continue;
                }

                character = Convert.ToChar(text[i]);
                asciiNumber = character;

                if (asciiNumber >= 32 && asciiNumber <= 46)
                {
                    encriptedText += (char)(asciiNumber);
                }
                else if (asciiNumber > 115)
                {
                    encriptedText += (char)(asciiNumber - 26 + keyup);
                }
                else
                {
                    encriptedText += (char)(asciiNumber + keyup);
                }
            }

            return encriptedText;
        }

        public string Decrypt(string text, int keyup)
        {
            string textDecripted = ""; 
            char character;
            int asciiNumber;

            for (int i = 0; i < text.Length; i++)
            {
                character = ' ';
                asciiNumber = 0;

                if (text[i] == ' ')
                {
                    textDecripted += ' ';
                    continue;
                }

                character = Convert.ToChar(text[i]);
                asciiNumber = character;

                if (asciiNumber >= 32 && asciiNumber <= 46)
                {
                    textDecripted += (char)(asciiNumber);
                }
                else if (asciiNumber < 104)
                {
                    textDecripted += (char)(asciiNumber - keyup + 26);
                }
                else
                {
                    textDecripted += (char)(asciiNumber - keyup);
                }
            }

            return textDecripted;
        }
    }
}
