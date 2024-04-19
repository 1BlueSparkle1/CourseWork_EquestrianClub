using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Components
{
    internal class Md5Class
    {
        //класс хэширования пароля
        public static string hashPassword(string password)
        {
            //создается элемент для хэширования
            MD5 md5 = MD5.Create();

            //пароль переводится в байты
            byte[] b = Encoding.ASCII.GetBytes(password);
            //хэшируется
            byte[] hash = md5.ComputeHash(b);

            //создается строковый элемент
            StringBuilder sb = new StringBuilder();

            //хэш преобразуется в строку
            foreach(var a in hash)
            {
                sb.Append(a.ToString("X2"));
            }

            //возвращается строка
            return sb.ToString();
        }
    }
}
