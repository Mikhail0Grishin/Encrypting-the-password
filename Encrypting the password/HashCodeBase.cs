using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypting_the_password
{
    public class HashCodeBase
    {
        private List<Char> hashBase = new List<char>()
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
            'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
            'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'а', 'б', 'в', 'г', 'д', 'е',
            'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х',
            'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё',
            'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц',
            'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };

        private string login;
        private string password;
        private string loginFromDB;
        private string hashCodeFromDB;
        private bool error;
        private string saltFromDB; // That is the string for hash-func

        public HashCodeBase(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string CalculateHashCode()
        {
            string binaryLogin = ConvertToBinarySequence(login);
            string binaryPassword = ConvertToBinarySequence(password);

            string binaryRule = CreateRule(binaryLogin);

            List<String> currentPattern = new List<String>() { "111", "110", "101", "100", "011", "001", "010", "000"};

            ArrayList newPatter = ConverStringToArrayList(binaryRule);

            string salt = CreateSalt();

            string binarySalt = ConvertToBinarySequence(salt);

            string initStateAut = binaryPassword + binarySalt;

            string binaryHashCode = CreatHashCode(initStateAut, currentPattern, newPatter);

            string hashCode = ConvertBinarySequenceToText(binaryHashCode);

            return hashCode;
        }

        private string CreatHashCode(string initStateAut, List<string> currentPattern, ArrayList newPatter)
        {
            StringBuilder newStateAut = new StringBuilder();
            string neighborhoodOfPoint = "";

            for (int i = 0; i < initStateAut.Length - 2; i++)
            {
                
                neighborhoodOfPoint = initStateAut.Substring(i, 3);
              

                newStateAut.Append(newPatter[currentPattern.IndexOf(neighborhoodOfPoint)]);
            }

            neighborhoodOfPoint = initStateAut.Substring(initStateAut.Length - 2) + initStateAut[0];
            newStateAut.Append(newPatter[currentPattern.IndexOf(neighborhoodOfPoint)]);

            neighborhoodOfPoint = initStateAut.Substring(initStateAut.Length - 1) + initStateAut[0] + initStateAut[1];
            newStateAut.Append(newPatter[currentPattern.IndexOf(neighborhoodOfPoint)]);

            return newStateAut.ToString();
        }

        private ArrayList ConverStringToArrayList(string str)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < str.Length; i++)
            {
                arrayList.Add(str[i]);
            }

            return arrayList;
        }

        private string ConvertToBinarySequence(string password) 
        {
            StringBuilder binaryResult = new StringBuilder();
            StringBuilder binaryNumber = new StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                binaryNumber.Append(Convert.ToString(hashBase.IndexOf(password[i]), 2));

                while (binaryNumber.Length != 7)
                {
                    binaryNumber.Insert(0, '0');
                }

                binaryResult.Append(binaryNumber);

                binaryNumber.Length = 0;
            }

            return binaryResult.ToString();
        }

        private long ConvertBinaryNumberToDecimal(string binaryNumber)
        {
            return Convert.ToInt64(binaryNumber, 2);
        }

        private string ConvertBinarySequenceToText(string binarySequence)
        {
            StringBuilder text = new StringBuilder();
            int numberOfLetter;

            for (int i = 0; i < binarySequence.Length; i += 7)
            {
                numberOfLetter = (int)ConvertBinaryNumberToDecimal(binarySequence.Substring(i, 7));
                text.Append(hashBase[numberOfLetter]);
            }

            return text.ToString();
        }

        private string CreateSalt() 
        {
            Random random = new Random();
            string result = "";
            int randomNumber = random.Next(1, 127);
            for (int i = 0; i < 32 - password.Length; i++)
            {
                result = result + hashBase[randomNumber];
                randomNumber = random.Next(1, 127);
            }

            return result;
        }

        private string CreateRule(string binaryLogin)
        {
            int loginFromBinaryLogin = (int)ConvertBinaryNumberToDecimal(binaryLogin);
            int ruleDecomalNumber = loginFromBinaryLogin % 255;

            StringBuilder ruleBinaryNumber = new StringBuilder(Convert.ToString(ruleDecomalNumber, 2));
            while (ruleBinaryNumber.Length != 8)
            {
                ruleBinaryNumber.Insert(0, "0");
            }

            return ruleBinaryNumber.ToString();
        }
    }
}
