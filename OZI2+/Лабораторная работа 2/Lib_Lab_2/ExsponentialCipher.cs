using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Lab_2
{
    public class ExsponentialCipher
    {
        string Alphabit = "abcdefghijklmnopqrstuvwxyz";

        public int[] encode(string Message, string Key)
        {
            List<int> resList = new List<int>();
            Message = Message.ToLower();
            Key = Key.ToLower();
            int KeyNumber = Key.Length - 1;
            int KeyCounter = 0;

            for (int i = 0; i < Message.Length; i++)
            {
                KeyCounter %= KeyNumber;
                int findedMessageNumber = findNumber(Message[i]);
                int findedKeyNumber = findNumber(Key[KeyCounter]);
                double Number = (findedMessageNumber + findedKeyNumber) % Alphabit.Length;
                KeyCounter++;
                resList.Add((int)Number);
            }

            return resList.ToArray();
        }

        public string decode(int[] Encode, string Key)
        {
            string mes = "";
            Key = Key.ToLower();
            int KeyNumber = Key.Length - 1;
            int KeyCounter = 0;
            int IndexDec = 0;

            for (int i = 0; i < Encode.Length; i++)
            {
                KeyCounter %= KeyNumber;
                int findedKeyNumber = findNumber(Key[KeyCounter]);
                IndexDec = (Encode[i] + Alphabit.Length - findedKeyNumber) % Alphabit.Length;
                KeyCounter++;

                mes += Alphabit[IndexDec];
            }

            return mes;
        }

        public int findNumber(char letter)
        {
            int Number = 0;
            bool isFind = false;

            for (int i = 0; i < Alphabit.Length && !isFind; i++)
            {
                if(letter == Alphabit[i])
                {
                    Number = i;
                    isFind = true;
                }
            }

            return Number;
        }
    }
}
