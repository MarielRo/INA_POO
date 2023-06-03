using System;

namespace LogicaNegocio
{
    public class ClsPromedio
    {
        ClsPromedio calcularPromedio = new ClsPromedio();

        //Atributos
        private double promedio;
        private string condicion = " ", color = "";


        //Propiedades
        public double Promedio { get => promedio; set => promedio = value; }
        public string Condicion { get => condicion; set => condicion = value; }
        public string Color { get => color; set => color = value; }

        //Metodos

        //Constructor vacio
        public ClsPromedio()
        {
            this.promedio = 0;
            this.condicion = string.Empty;
            this.color = string.Empty;
        
        }

        //Calculo del promedioo , que recibe la suma de notas y la cantidad de notas
        public double CalcularPromedio(double sumaNotas, int cantidad)
        {
            double promedio = 0;
            promedio = sumaNotas / cantidad;
            return promedio;
        }

        // Calculo de condición que recibe un promedio y determina si aprobó o reprobó y
        // cambia el valor de la propiedad color de acuerdo a la condición (rojo reprobó, verde aprobó)
        private void CalcularCondicion(double promedio)
        {
            //Declaracion de Variables
            string condicion = string.Empty;
            if (promedio >= 70)
            {
                condicion = "APROBADO";
                color = "VERDE";
            }
            else
            {
                condicion = "REPROBADO";
                color = "ROJO";
            }
        }

    }
}
