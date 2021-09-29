using System;
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

        public string ConvertToBinarySequence(string password) 
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

    }
}
