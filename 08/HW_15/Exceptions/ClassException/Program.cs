using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassException
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException() { }

        public UserNotFoundException(string message) : base(message) { }

        public UserNotFoundException(string message, Exception inner) :
            base(message, inner) { }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) :
            base(info, context) { }
    }

    internal static class Program
    {
        //private static void EditUser(string oldUserName, string newUserName)
        //{
        //    var userForEdit = GetUserByName(oldUserName);

        //    if (userForEdit == null)
        //        throw new UserNotFoundException("User \"" + oldUserName +
        //                                        "\" not found in system");
        //    userForEdit.Name = newUserName;
        //}

        private static void Main()
        {

            try
            {
                try
                {
                    Console.Write("Введите строку: ");
                    var message = Console.ReadLine();
                    if (string.IsNullOrEmpty(message) || message.Length > 6)
                    {
                        throw new Exception("Длина строки 0 or больше 6 символов");
                    }
                }
                catch
                {
                    Console.WriteLine("Возникло исключение");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}