using System;
using System.Collections.Generic;

class Program
{
    static List<string> tareas = new List<string>();

    static void Main(string[] args)
    {
        Console.Title = "Gestión de Tareas";

        bool ejecutando = true;

        while (ejecutando)
        {
            MostrarMenu();
            string opcion = Console.ReadLine().Trim();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    MarcarTareaCompletada();
                    break;
                case "3":
                    MostrarTareasPendientes();
                    break;
                case "4":
                    ejecutando = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("¡Hasta luego!");
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("        Gestión de Tareas        ");
        Console.WriteLine("=================================");
        Console.WriteLine("1. Agregar Tarea");
        Console.WriteLine("2. Marcar Tarea como Completada");
        Console.WriteLine("3. Ver Tareas Pendientes");
        Console.WriteLine("4. Salir");
        Console.Write("Elige una opción: ");
    }

    static void AgregarTarea()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("        Agregar Tarea        ");
        Console.WriteLine("=================================");
        Console.Write("Ingrese la nueva tarea: ");
        string nuevaTarea = Console.ReadLine().Trim();

        if (!string.IsNullOrEmpty(nuevaTarea))
        {
            tareas.Add(nuevaTarea);
            Console.WriteLine("\nTarea agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("\nError: La tarea no puede estar vacía.");
        }

        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }

    static void MarcarTareaCompletada()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("   Marcar Tarea como Completada   ");
        Console.WriteLine("=================================");

        if (tareas.Count == 0)
        {
            Console.WriteLine("\nNo hay tareas para marcar como completadas.");
            Console.Write("\nPresiona Enter para continuar...");
            Console.ReadLine();
            return;
        }

        MostrarTareasPendientes(); 

        Console.Write("\nIngrese el índice de la tarea completada: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 0 && indice < tareas.Count)
        {
            tareas.RemoveAt(indice);
            Console.WriteLine("\nTarea marcada como completada.");
        }
        else
        {
            Console.WriteLine("\nError: Índice de tarea no válido.");
        }

        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine(); // Esperar a que el usuario presione Enter
    }

    static void MostrarTareasPendientes()
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine("    Tareas Pendientes   ");
        Console.WriteLine("=================================");

        if (tareas.Count == 0)
        {
            Console.WriteLine("\nNo hay tareas pendientes.");
            Console.Write("\nPresiona Enter para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Tareas Pendientes:");
        for (int i = 0; i < tareas.Count; i++)
        {
            Console.WriteLine($"{i}. {tareas[i]}");
        }

        Console.Write("\nPresiona Enter para continuar...");
        Console.ReadLine();
    }
}
