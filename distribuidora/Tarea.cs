using System;
using System.Collections.Generic;
using System.Text;

namespace tarea
{
    public class Tarea
    {
        private int id;
        private string descripcion;
        private int duracion;


        public int ID {get => id; set => id =value; }
        public string Descripcion {get => descripcion; set => descripcion =value; }
        public int Duracion {get => duracion; set => duracion =value; }

        /*public void MostrarTarea()
        {
            Console.WriteLine($"ID de la tarea: {id}");
            Console.WriteLine($"Descripción: {descripcion}");
            Console.WriteLine($"Duración: {duracion}\n");
        }*/

    }


}