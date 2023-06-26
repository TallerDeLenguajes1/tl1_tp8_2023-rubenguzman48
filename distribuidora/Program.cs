/*1) Convierta TP4 que hizo con listas en C a C# (implementandolo con listas y clases).
TP 4
Una distribuidora necesita llevar un control de las tareas realizadas por sus empleados. Usted
forma parte del equipo de programación que se encargará de hacer el módulo en cuestión
que a partir de ahora se llamará módulo ToDo:
Tareas
Cada empleado tiene un listado de tareas a realizar.
Las estructuras de datos necesarias son las siguientes:
1. Cree aleatoriamente N tareas pendientes.
2. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
3. Desarrolle una interfaz para buscar tareas pendientes por descripción.
4. Guarde en un archivo de texto un sumario de las horas trabajadas por el
empleado (sumatoria de la duración de las tareas).
*/


using tarea;

class Program
{
    static void Main(string[] args)
    {
        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();


        //1. Cree aleatoriamente N tareas pendientes.
        //Debo generar un numero aleatorio N
        int N = new Random().Next(2, 4); //Funcion para crear numeros aleatorios entre 2 y 10
        
        cargaTareaPend(N, tareasPendientes); //Invoco la funcion de carga de tareas


        Tarea tareaBuscada = new Tarea();


    }

    //Creo una funcion para generar las tareas aleatoriamente
    public static void cargaTareaPend (int N, List<Tarea> pendientes)
    {
        int duracion = 0;
        //string num = String.Empty;

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"Se han asiganado {N} tareas al usuario.\n ");
            Console.WriteLine($"Ingrese a continuacion la tarea N° {i+1}");

            var nuevaTarea = new Tarea(); //Creo una variable de tipo tarea para poder guardar la tarea en la lista
            nuevaTarea.ID = i;
            Console.Write("Ingrese la descripcion de la tarea: ");
            nuevaTarea.Descripcion = Console.ReadLine();
            do
            {
                Console.Write("Ingrese la duracion de la tarea (Debe ser entre 10 y 100): ");
                duracion = Convert.ToInt32(Console.ReadLine());
                if(duracion < 10 || duracion >100)
                {
                    Console.WriteLine("ERROR, ingreso un valor incorrecto para la duracion, vuelva a intentar!");
                }

            } while (duracion < 10 || duracion >100);
            nuevaTarea.Duracion = duracion;
            Console.WriteLine(nuevaTarea.ID+", "+nuevaTarea.Descripcion+", "+nuevaTarea.Duracion);

        }


    }   


}












       