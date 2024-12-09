using System;
using System.Security.Cryptography;
using System.Text;

namespace project_unad_mayelin
{
    // Clase base
    public class User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        private string hashedPassword; // Contraseña encriptada
        public string mobile { get; set; }

        public string password
        {
            get => hashedPassword;
            set => hashedPassword = HashPassword(value);
        }

        public User() // Constructor
        {
            this.name = "Stefania";
            this.surname = "Aguilar";
            this.email = "estefaguilar@gmail.com";
            this.password = "Abc12345";
            this.mobile = "30044567893";
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool ValidatePassword(string inputPassword)
        {
            string hashedInput = HashPassword(inputPassword);
            return hashedInput == hashedPassword;
        }

        // Método de login genérico
        public virtual bool Login(string email, string password)
        {
            return this.email == email && ValidatePassword(password);
        }
    }

    // Clase derivada
    public class AdminUser : User
    {
        public string role { get; set; }

        public AdminUser() : base()
        {
            this.role = "Administrator";
        }

        // Sobrescribir el método Login para el admin
        public override bool Login(string email, string password)
        {
            if (this.email == email && ValidatePassword(password))
            {
                Console.WriteLine("Acceso de administrador exitoso.");
                return true;
            }
            return false;
        }
    }
}
