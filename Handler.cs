using System;
using System.Collections.Generic;
using System.Text;

namespace project_unad_mayelin
{
    public class Handler
    {
        // Declaramos listProducts como un campo de la clase para que sea accesible en todos los métodos
        List<Product> listProducts = new List<Product>
        {
            new Product("0001", "Laptop Asus", "$2349000"),
            new Product("0002", "Mouse ergonómico", "$89900"),
            new Product("0003", "Teclado ergonómico", "$319900"),
            new Product("0004", "Monitor HP", "$479000"),
            new Product("0005", "Base refrigerante laptop", "$29900")
        };

        List<Product> cart = new List<Product>(); // Carrito de compras

        public Handler()
        {
            // n/a
        }

        public void init()
        {
            Console.WriteLine("Bienvenido a Tu equipo ya!");
            Console.WriteLine("Ingresa una opción válida:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Cancelar");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Ingresa el email: ");
                    string email = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Ingresa el password: ");
                    string password = ReadPassword(); // Usa el método para leer la contraseña
                    Auth auth = new Auth();
                    if (auth.login(email, password))
                    {
                        Console.WriteLine("Acceso exitoso.");
                        this.menuMain();
                    }
                    else
                    {
                        Console.WriteLine("Credenciales inválidas.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Cancelado.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    init(); // Re-inicia el menú
                    break;
            }
        }

        private void menuMain()
        {
            Console.WriteLine("Hola, Bienvenido al menú principal");
            Console.WriteLine("Elige una de las siguientes opciones:");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Ver carrito");
            Console.WriteLine("3. Eliminar producto del carrito");
            Console.WriteLine("4. Comprar");
            Console.WriteLine("5. Salir");

            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    this.showProducts(); // Muestra productos disponibles
                    break;
                case "2":
                    this.showCart(); // Muestra carrito
                    break;
                case "3":
                    this.removeFromCart(); // Eliminar del carrito
                    break;
                case "4":
                    this.buyProducts(); // Realizar compra
                    break;
                case "5":
                    Console.WriteLine("Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        // Mostrar productos disponibles
        private void showProducts()
        {
            Console.WriteLine("**** PRODUCTOS DISPONIBLES: ");
            for (int i = 0; i < listProducts.Count; i++)
            {
                Product product = listProducts[i];
                Console.WriteLine($"{i + 1}. {product.name} - Precio: {product.precio}");
            }

            Console.WriteLine("Elige un producto por el número para agregarlo al carrito:");
            int productChoice = int.Parse(Console.ReadLine() ?? "0");

            if (productChoice >= 1 && productChoice <= listProducts.Count)
            {
                Product selectedProduct = listProducts[productChoice - 1];
                cart.Add(selectedProduct);
                Console.WriteLine($"Producto {selectedProduct.name} agregado al carrito.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

            menuMain(); // Vuelve al menú principal
        }

        // Mostrar el carrito de compras
        private void showCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Tu carrito está vacío.");
            }
            else
            {
                Console.WriteLine("**** CARRITO DE COMPRAS: ");
                for (int i = 0; i < cart.Count; i++)
                {
                    Product product = cart[i];
                    Console.WriteLine($"{i + 1}. {product.name} - Precio: {product.precio}");
                }
            }

            menuMain();
        }

        // Eliminar producto del carrito
        private void removeFromCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Tu carrito está vacío.");
                menuMain();
                return;
            }

            Console.WriteLine("Selecciona el producto a eliminar del carrito:");
            for (int i = 0; i < cart.Count; i++)
            {
                Product product = cart[i];
                Console.WriteLine($"{i + 1}. {product.name} - Precio: {product.precio}");
            }

            int removeChoice = int.Parse(Console.ReadLine() ?? "0");

            if (removeChoice >= 1 && removeChoice <= cart.Count)
            {
                Product productToRemove = cart[removeChoice - 1];
                cart.Remove(productToRemove);
                Console.WriteLine($"Producto {productToRemove.name} eliminado del carrito.");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

            menuMain();
        }

        // Comprar los productos
        private void buyProducts()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Tu carrito está vacío, no puedes comprar.");
            }
            else
            {
                Console.WriteLine("**** Resumen de tu compra: ");
                decimal total = 0;
                foreach (Product product in cart)
                {
                    Console.WriteLine($"{product.name} - Precio: {product.precio}");
                    decimal price = decimal.Parse(product.precio.Replace("$", "").Replace(",", ""));
                    total += price;
                }

                Console.WriteLine($"Total a pagar: ${total}");

                Console.WriteLine("¿Confirmas la compra? (s/n)");
                string confirm = Console.ReadLine()?.ToLower();

                if (confirm == "s")
                {
                    Console.WriteLine("¡Compra realizada con éxito!");
                    cart.Clear(); // Limpiar carrito después de la compra
                }
                else
                {
                    Console.WriteLine("Compra cancelada.");
                }
            }

            menuMain();
        }

        // Método para leer la contraseña oculta
        public static string ReadPassword()
        {
            StringBuilder password = new StringBuilder();

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept: true); // Lee la tecla sin mostrarla en la consola

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1); // Elimina el último carácter
                    Console.Write("\b \b"); // Borra el carácter de la consola
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar); // Agrega el carácter a la contraseña
                    Console.Write("*"); // Muestra un asterisco en lugar del carácter
                }
            }
            while (key.Key != ConsoleKey.Enter); // Detiene cuando se presiona Enter

            Console.WriteLine(); // Salto de línea después de ingresar la contraseña
            return password.ToString(); // Devuelve la contraseña
        }
    }
}
