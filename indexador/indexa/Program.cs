class Program
{
    private static void Main(string[] args)
    {
        string path;
        Console.Write("Ingrese una ruta valida: ");
        path = Console.ReadLine();

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Ruta invalida!");
        }else
        {
            List<string> listarArchivos = Directory.GetFiles(path).ToList();
            Console.WriteLine("Lista de archivos");
            listarArchivos.ForEach(Console.WriteLine); //en esta linea imprimo cada elemento de la lista por consola
            using(StreamWriter indexador = new StreamWriter("index.csv"))
            {
                for (int i = 0; i < listarArchivos.Count; i++)
                {
                    indexador.WriteLine($"{i},{Path.GetFileNameWithoutExtension(listarArchivos[i])},{Path.GetExtension(listarArchivos[i])}");
                }
                indexador.Close();
                indexador.Dispose();
            }


        }
    }
}