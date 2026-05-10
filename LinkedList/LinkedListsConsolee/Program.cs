using System;
using List;

namespace LinkedListsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list =
                new DoublyLinkedList<string>();

            string opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== MENÚ =====");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Mostrar");
                Console.WriteLine("3. Mostrar al revés");
                Console.WriteLine("4. Orden descendente");
                Console.WriteLine("5. Buscar");
                Console.WriteLine("6. Eliminar una ocurrencia");
                Console.WriteLine("7. Eliminar todas las ocurrencias");
                Console.WriteLine("8. Moda");
                Console.WriteLine("9. Graficar lista");
                Console.WriteLine("0. Salir");

                Console.Write("Opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese valor: ");
                        string valor = Console.ReadLine();

                        list.Add(valor);

                        Console.WriteLine("Dato agregado.");
                        break;

                    case "2":
                        Console.WriteLine("\nLista:");
                        list.ShowForward();
                        break;

                    case "3":
                        Console.WriteLine("\nLista al revés:");
                        list.ShowBackward();
                        break;

                    case "4":
                        list.SortDescending();
                        Console.WriteLine("\nLista ordenada descendente:");
                        list.ShowForward();
                        break;

                    case "5":
                        Console.Write("Valor a buscar: ");
                        string buscar = Console.ReadLine();

                        if (list.Exists(buscar))
                            Console.WriteLine("El dato existe.");
                        else
                            Console.WriteLine("El dato no existe.");
                        break;

                    case "6":
                        Console.Write("Eliminar una ocurrencia: ");
                        string eliminarUno = Console.ReadLine();

                        list.RemoveOne(eliminarUno);

                        Console.WriteLine("Se eliminó una ocurrencia.");
                        break;

                    case "7":
                        Console.Write("Eliminar todas las ocurrencias: ");
                        string eliminarTodos = Console.ReadLine();

                        list.RemoveAll(eliminarTodos);

                        Console.WriteLine("Se eliminaron todas las ocurrencias.");
                        break;

                    case "8":
                        var modas = list.Mode();

                        Console.WriteLine("\nModa(s):");

                        foreach (var m in modas)
                            Console.Write(m + " ");

                        Console.WriteLine();
                        break;

                    case "9":
                        Console.WriteLine("\nGráfica de frecuencias:\n");
                        list.Graficar();
                        break;

                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != "0");
        }
    }
}