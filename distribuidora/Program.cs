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
        int N = new Random().Next(2, 4); //Funcion para crear numeros aleatorios entre 2 y 4
        
        cargaTareaPend(N, tareasPendientes); //Invoco la funcion de carga de tareas

        foreach (var tarea in tareasPendientes) //recorro la lista de pendientes e imprimo las tareas
        {
            Console.WriteLine("Lista Pendientes");
            Console.WriteLine("ID: " + tarea.ID);
            Console.WriteLine("Descripcion: " + tarea.Descripcion);
            Console.WriteLine("Duracion: " + tarea.Duracion);
            Console.WriteLine();
        }

        //****************************************************+++
        //2. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
        moverTarea(tareasPendientes, tareasRealizadas); //Envio las tareas pendientes y realizadas a la funcion moverTarea
        
        foreach (var tarea in tareasPendientes) //recorro la lista de pendientes luego de remover las realizadas e imprimo las pendientes restantes
        {
            Console.WriteLine("Lista Pendientes despues");
            Console.WriteLine("ID: " + tarea.ID);
            Console.WriteLine("Descripcion: " + tarea.Descripcion);
            Console.WriteLine("Duracion: " + tarea.Duracion);
            Console.WriteLine();
        }


        foreach (var tareaR in tareasRealizadas) //recorro la lista de tareas realizadas
        {
            Console.WriteLine("Lista Realizadas");
            Console.WriteLine("ID: " + tareaR.ID);
            Console.WriteLine("Descripcion: " + tareaR.Descripcion);
            Console.WriteLine("Duracion: " + tareaR.Duracion);
            Console.WriteLine();
        }

        //**********************************************************
        //3. Desarrolle una interfaz para buscar tareas pendientes por descripción.
        Tarea tareaBuscada = new Tarea(); //creo una variable de tipo Tarea para guardar un elemento de la lista tareas pendientes
        string confirmar; //creo un string para guardar la respuesta del usuario
        bool continuar = true; 
        string filtro; //creo un string para guardar la descripcion ingresada por el usuario

        Console.WriteLine("Desea buscar alguna tarea pendiente? (si/no)");
        confirmar = Console.ReadLine(); //guardo la respuesta en el string

        if (confirmar.ToLower() == "si") //pregunto si la respuesta es si continuo
        {
            while (continuar) //mientras continuar sea true
            {
                Console.WriteLine("Ingrese la descripcion de la tarea que desea buscar: ");
                filtro = Console.ReadLine(); //guardo la descripcion del usuario en el string filtro

                tareaBuscada = buscarPorDescripcion(tareasPendientes, filtro); //mando la lista pendientes y la descripcion del usuario 
                                                                                //y busco conicidencias, si hay las guardo en la variable tipo Tarea
                if (String.IsNullOrEmpty(tareaBuscada.Descripcion)) //si no se guarda ningun elemento en tareaBuscada no continuo
                {
                    Console.WriteLine("No existe la tarea pendiente que desea encontrar");
                }else
                {
                    Console.WriteLine("------------Tarea Encontrada------------");
                    mostrarTareas(tareaBuscada); //si no es null o vacio envio el elemento a la funcion mostrar e imprimo los objetos del elemento de la lista
                    
                }
                Console.Write("Desea buscar otra tarea pendiente? (si/no)"); //pregunto si deseo continuar
                confirmar = Console.ReadLine(); //sobreescribo el string confirmar

                if (confirmar.ToLower() != "si") //si el string confirmar es distinto a si cambio el valor de continuar a false para que termine el bucle
                {
                    continuar = false;
                }
            }
        }

        if (tareasRealizadas.Count > 0) //si las tareas realizadas son mayores que 0
        {
            guardarSumario(tareasRealizadas); //invoco a la funcion guardar sumario y le paso la lista tareasRealizadas
        }else
        {
            Console.WriteLine("\nNo hay tareas realizadas! No se puede guardar.");
        }

    }
    //******************************************************
    //Creo una funcion para generar las tareas aleatoriamente
    //1. Cree aleatoriamente N tareas pendientes.
    public static void cargaTareaPend (int N, List<Tarea> pendientes) //funcion para crear N tareas donde recibo una lista de pendientes
    {
        int duracion = 0; //inicializo la variable duracion en 0

        for (int i = 0; i < N; i++) //repito N veces
        {
            Console.WriteLine($"Se han asiganado {N} tareas al usuario.\n ");
            Console.WriteLine($"Ingrese a continuacion la tarea N° {i+1}");

            var nuevaTarea = new Tarea(); //Creo una variable de tipo tarea para poder guardar la tarea en la lista
            nuevaTarea.ID = i; //guardo el numero de ID del elemento de la lista con la variable i del bucle
            Console.Write("Ingrese la descripcion de la tarea: ");
            nuevaTarea.Descripcion = Console.ReadLine(); //pido la descripcion y lo guardo en la variable tipo Tarea nuevaTarea
            do
            {
                Console.Write("Ingrese la duracion de la tarea (Debe ser entre 10 y 100): ");
                duracion = Convert.ToInt32(Console.ReadLine()); //guardo como int el valor ingresado por el usuario en la variable duracion
                if(duracion < 10 || duracion >100) //si lo ingresdo por el usuario es menos que 10 o mayor que 100
                {
                    Console.WriteLine("ERROR, ingreso un valor incorrecto para la duracion, vuelva a intentar!");
                }

            } while (duracion < 10 || duracion >100); //repito de nuevo si es menor que 10 o mayor que 100
            nuevaTarea.Duracion = duracion; //si es valido guardo en la variable
            Console.WriteLine(nuevaTarea.ID+", "+nuevaTarea.Descripcion+", "+nuevaTarea.Duracion); //imprimo
            pendientes.Insert(nuevaTarea.ID, nuevaTarea); //Inserto en la lista tareasPendientes con el ID de la tarea y el contenido
            //Con Insert agrego un objeto en la lista con la posicion especifica ID, puedo agregarlo en cualquier parte de la lista

        }
        

    } 

    //***************************************************
    //Creo una funcion para mover las tareas pendientes a las tareas realizadas
    //2. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
    public static void moverTarea(List<Tarea> pendientes, List<Tarea> realizadas) //recibo las listas de tipo Tarea pendientes y realizadas
    {
        string respuesta; //Creo un string para guardar la respuesta 
        foreach (var tareaPendiente in pendientes) //recorro la tarea 
        {
            Console.Write($"\nRealizo la tarea ID: {tareaPendiente.ID}?(si/no)"); //identifico la tarea por el ID y pregunto si ya se realizo
            respuesta = Console.ReadLine(); //guardo la respuesta en el string que cree antes
            if(respuesta == "si") //pregunto si el string es igual a si
            {
                realizadas.Add(tareaPendiente); //Con Add inserto un objeto al final de la lista
                //inserto la tarea pendiente realizada al final de la lista realizadas
            }
        }
        foreach (var tareaARemover in realizadas) //recorro la lista de realizadas
        {
            pendientes.Remove(tareaARemover); //remuevo las tareas que se encuentran en la lista realizadas de la lista de pendientes
        }
    }  

    //********************************************************+
    //3. Desarrolle una interfaz para buscar tareas pendientes por descripción.
    public static Tarea buscarPorDescripcion (List<Tarea> pendientes, string descripcion) //funcion para buscar tareas que recibe la lista de pendientes y una descripcion, esta funcion debe retornar algo
    {
         Tarea tareaBuscar = new Tarea(); //creo un objeto de tipo tarea donde guardare la tarea buscada y la usare para retornar
         foreach (var tareap in pendientes) //recorro la lista pendientes 
         {
            if (tareap.Descripcion == descripcion) //comparo la descripcion de la lista con la descripcion dada por el usuario
            { 
                tareaBuscar = tareap; //si se cumple la comparacion guardo la tarea encontrada en el objeto tareaBuscar 
            }
         }
         Console.WriteLine("Esto es tareaBuscar "+tareaBuscar);
         return tareaBuscar; //retorno la tarea encontrada
    } 

    public static void mostrarTareas(Tarea listaTareas) //creo una funcion para mostrar las tareas que recibe un elemento Tarea de la lista pendientes
    {
        Console.WriteLine($"ID de la tarea: {listaTareas.ID}"); //imprimo
        Console.WriteLine($"Descripción: {listaTareas.Descripcion}");
        Console.WriteLine($"Duración: {listaTareas.Duracion}\n");

    }

    public static void guardarSumario (List<Tarea> realizadas) //resivo la lista de tipo tarea realizadas
    {
        int totalHoras = 0; //inicializo la variable totalHoras en 0
        StreamWriter archivo = new StreamWriter("sumario.txt"); //defino un objeto de tipo Streamwrite para escribir en un archivo "sumario.txt"
        foreach (var tarear in realizadas) //recorro la lista de realiados
        {
            totalHoras += tarear.Duracion; //sumo la cantidad de horas de las tareas realizadas
        }
        archivo.WriteLine($"Sumario: {totalHoras}"); //escribo las horas realizadas en el archivo
        archivo.Close(); //cierro el archivo y libero la memoria reservada
    }


}














       