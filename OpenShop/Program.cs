using System;
using System.Collections.Generic;
//Implementación carrito de compras.
namespace OpenShop
{
   
    class GestorVenta
    {
        static Carrito Carrito = new Carrito();
        static List<FormasPago> FormasPagos = new List<FormasPago>();

        static void Main(string[] args)
        {
            FormasPagos.Add(new FormasPago("Tarjeta en 6 cuotas sin interés"));
            FormasPagos.Add(new FormasPago("Débito"));

            // Pide productos de manera infinita hasta que el usuario diga basta

            while (true)
            {
                var finalizado = Comprar();

                if (finalizado)
                {
                    break;
                }
            }

            AgregarPago();

            System.Console.WriteLine("Gracias por comprar.");
        }

        static public bool Comprar()
        {
            RegistroProductos.MostrarProductos();

            System.Console.WriteLine();
            System.Console.WriteLine("Seleccione un producto.");

            while (true)
            {
                var opcionProducto = System.Console.ReadLine();
                if (int.TryParse(opcionProducto, out var value))
                {
                    if (value >= 1 && value <= RegistroProductos.Productos.Count)
                    {
                        var producto = RegistroProductos.Productos[int.Parse(opcionProducto) - 1];
                        System.Console.WriteLine();
                        System.Console.WriteLine("Introduzca la cantidad de productos que desea comprar: ");
                        var opcionCantidad = System.Console.ReadLine();
                        int cantidadElegida = (int.Parse(opcionCantidad));

                        Carrito.Agregar(producto, cantidadElegida);
                        Carrito.MostrarCarrito();
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("VALOR INCORRECTO. Ingrese un valor mayor a 1 y menor a " + RegistroProductos.Productos.Count);
                    }
                }

            }

            System.Console.WriteLine("");
            System.Console.WriteLine("Digite 1 para seguir comprando, 2 para abonar los productos del carrito.");

            
            while (true)
            {
                var opcionSeguir = System.Console.ReadLine();
                if(int.TryParse(opcionSeguir, out var value))
                {
                    if(value >= 1 && value <= 2)
                    {
                        if(value == 1)
                        {
                            return false;
                            
                        }
                        else
                        {
                            return true;
                        }
                    
                    }
                    else
                    {
                     System.Console.WriteLine("VALOR INCORRECTO. Ingrese 1 o 2.");
                    }
                }
            }
          
        }
       
        static public void AgregarPago()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Formas de pago: ");
            int pos = 1;
            foreach (var pago in FormasPagos)
            {
                System.Console.WriteLine(pos + "- " + pago.Tipo);
                pos++;
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Seleccione una forma de pago. (Digite 1 o 2)");

            FormasPago formasPagos;

            while (true)
            {
                var seleccionPago = System.Console.ReadLine();
                if (int.TryParse(seleccionPago, out var value))
                {
                    if (value >= 1 && value <= 2)
                    {
                        formasPagos = FormasPagos[value - 1];
                        break;
                    }

                    else
                    {
                        System.Console.WriteLine("Ingrese un valor correcto, solo 1 o 2");
                    }
                      
                }
            }

            System.Console.WriteLine("La forma de pago elegida fue: " + formasPagos.Tipo);
            System.Console.WriteLine("");

           
        }
    }

    class FormasPago
    {
        public string Tipo { get; set; }
        public FormasPago(string tipo)
        {
            Tipo = tipo;
        }

    }

    class RegistroProductos
    {
        public static List<Producto> Productos = new List<Producto>();

        static RegistroProductos()
        {
            Productos.Add(new Producto("Cafetera", 3000));
            Productos.Add(new Producto("Celular", 249999.99m));
            Productos.Add(new Producto("Televisor", 22000));
            Productos.Add(new Producto("Ojotas", 700));
        }

         static public void MostrarProductos()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("OPEN SHOP");
            System.Console.WriteLine("Listado de productos:");
            int pos = 1;
            foreach (var producto in Productos)
            {
                System.Console.WriteLine(pos + "-" + producto.Nombre + " $" + producto.Precio);
                pos++;
            }
        }
    }

    class Producto
    {
       public string Nombre { get; set; }
       public decimal Precio { get; set; }

       public Producto(string nombre, decimal precio)
       {
           Nombre = nombre;
           Precio = precio;
       }
    }

    class Carrito
    {
        private List<ProductoEnCarrito> Productos = new List<ProductoEnCarrito>();

        public void Agregar(Producto producto, int cantidad)
        {
            var prodEnCarrito = new ProductoEnCarrito();
            prodEnCarrito.Producto = producto;
            prodEnCarrito.Cantidad = cantidad;

            Productos.Add(prodEnCarrito);
        }

       public void MostrarCarrito()
       {
            System.Console.WriteLine("");
            System.Console.WriteLine("Tienes en tu carrito: ");

            decimal totalCarrito = 0;
            foreach (var productoEnCarrito in Productos)
            {
                var cantidad = productoEnCarrito.Cantidad;
                var precio = productoEnCarrito.Producto.Precio;
                var nombre = productoEnCarrito.Producto.Nombre;
                System.Console.WriteLine(cantidad + "x " + nombre + " $" + cantidad * precio);

                totalCarrito = totalCarrito + cantidad * precio;
            }

            System.Console.WriteLine("Total: $" + totalCarrito);
        }
    }

    class ProductoEnCarrito
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
    



}