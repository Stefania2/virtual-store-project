using System;

namespace project_unad_mayelin
{
    public class Product
    {
        public string code { get; set; }
        public string name { get; set; }
        public string precio { get; set; }

        public Product(string code, string name, string precio)
        {
            this.code = code;
            this.name = name;
            this.precio = precio;
        }

        // Validar que el precio sea un número válido
        public bool IsValidPrice()
        {
            decimal temp;
            return decimal.TryParse(precio, out temp);
        }
    }
}
