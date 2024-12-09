using System;
using System.Collections.Generic;
using System.Linq;

namespace project_unad_mayelin
{
    public class Auth
    {
        List<User> users = new List<User>();

        public Auth()
        {
            // Crear un usuario de ejemplo
            users.Add(new User { name = "Stefania", surname = "Aguilar", email = "estefaguilar@gmail.com", password = "Abc12345", mobile = "30044567893" });
        }

        public Boolean login(string email, string password)
        {
            User user = users.FirstOrDefault(u => u.email == email);
            if (user != null && user.ValidatePassword(password))
            {
                return true;
            }
            return false;
        }

        public void logout()
        {
            Console.WriteLine("Sesión cerrada con éxito.");
        }
    }
}
