using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCaminoMasCorto
{
    class Persona
    {

        private Coordenadas PosicionActual;
        private Coordenadas Salida;
        private int OperacionX = 1;
        private int OperacionY = 1;
        //Fin de variables importantes.

        public Coordenadas Posicion
        {
            get { return PosicionActual; }
        }//Fin de para capturar la posicion de la persona.


        public Persona(Coordenadas Entrada, Coordenadas Salida, int operacionX, int operacionY)
        {
            this.PosicionActual = Entrada;
            this.Salida = Salida;
            this.OperacionX = operacionX;
            this.OperacionY = operacionY;
        }//Fin del constructor de la persona.

        public int Calcular(int Posicion, int Salida, int operacion)
        {
            if (Posicion != Salida) { return Posicion + (1 * operacion); }
            else { return Posicion; }
        }//Fin de para calcular la trayectoria.


        public void Mover()
        {
            int x = this.Calcular(PosicionActual.X, Salida.X, OperacionX);
            int y = this.Calcular(PosicionActual.Y, Salida.Y, OperacionY);
            this.PosicionActual = new Coordenadas(x, y);
        }//Fin de para mover a la persona.

        public Boolean Equals(Coordenadas Comparar)
        {
            Console.WriteLine("Coordenada salida: " + Comparar.Coordenada);
            Console.WriteLine("Position Actual: " + PosicionActual.Coordenada);
            Console.WriteLine("____________________");
            return (this.PosicionActual.X == Comparar.X && this.PosicionActual.Y == Comparar.Y);
        }//Para comparar las coordenadas.

    }//Fin de la clase Personas.
}
