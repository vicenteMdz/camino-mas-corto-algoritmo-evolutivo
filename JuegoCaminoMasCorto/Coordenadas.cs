using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCaminoMasCorto
{
    class Coordenadas
    {
        private int coordx = 0; private int coordy = 0;


        public String Coordenada
        {
            get
            {
                return "(" + coordx + "," + coordy + " )";
            }
        }//Para devolver la coordenada en String.

        public int X
        {
            get { return this.coordx; }
        }//Para el valor de X.

        public int Y
        {
            get { return this.coordy; }
        }//Para el valor de Y.

        public Coordenadas(int x, int y)
        {
            this.coordx = x; this.coordy = y;
        }//Constructor de la clase Coordenadas.


    }//Fin de la clase Coordenadas.
}
