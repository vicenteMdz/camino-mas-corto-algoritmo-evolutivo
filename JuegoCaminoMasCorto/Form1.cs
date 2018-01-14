using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoCaminoMasCorto
{
    public partial class Form1 : Form
    {
        private Coordenadas Entrada;
        private Coordenadas Salida;
        PictureBox destino;
        private Persona persona;
        private int movimientos = 0;//Para contar los movimientos.
        private int limiteMovimientos = 100;//limite de movimientos

        Random r = new Random();//Valor importante de la clase laberinto.

        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }

        public void Iniciar()
        {
            Entrada = PosicionAleatoria();
            Salida = PosicionAleatoria();

            drawInitialPoint(Entrada.X, Entrada.Y);
            drawFinalPoint(Salida.X, Salida.Y);

            int operacionX = this.Comparar(Entrada.X, Salida.X);
            int operacionY = this.Comparar(Entrada.Y, Salida.Y);

            persona = new Persona(Entrada, Salida, operacionX, operacionY);

            timer1.Start();//iniciamos el timer para buscar el camino cada x segundos

        }//Fin del metodo para iniciar el desafio del laberinto.

        private Coordenadas PosicionAleatoria()
        {
            int lado;
            lado = r.Next(3);
            if(lado == 0)
                    return new Coordenadas(0, r.Next(9));
            else if(lado == 1)
                    return new Coordenadas(9, r.Next(9));
            else if(lado == 2)
                    return new Coordenadas(r.Next(9), 0);
            else
                    return new Coordenadas(r.Next(9), 9);
        }//Para dar la posiciones aleatorias (Entrada y salida).

        private int Comparar(int entrada, int salida)
        {
            int operacionX = 1;
            if (entrada == salida) { operacionX = 0; }
            else
            {
                if (entrada > salida) { operacionX = -1; }
            }
            return operacionX;
        }//Fin del metodo para comparar las rutas.

        public void drawPoint(int x, int y)
        {
            if (x != Salida.X || y != Salida.Y)
            {
                if (Entrada.X > Salida.X)
                {
                    tablero.Controls.Add(
                    new PictureBox()
                    {
                        Image = JuegoCaminoMasCorto.Properties.Resources.walking,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    },
                    x, y);
                }
                else
                {
                    tablero.Controls.Add(
                    new PictureBox()
                    {
                        Image = JuegoCaminoMasCorto.Properties.Resources.walkingR,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    },
                    x, y);
                }
            }
            else
            {
                if (Entrada.X > Salida.X)
                {
                    destino.Image = JuegoCaminoMasCorto.Properties.Resources.metaL;
                }
                else
                {
                    destino.Image = JuegoCaminoMasCorto.Properties.Resources.meta;
                }
            }
        }

        public void drawInitialPoint(int x, int y)
        {
            if (Entrada.X > Salida.X)
            {
                tablero.Controls.Add(
                new PictureBox() { Image = JuegoCaminoMasCorto.Properties.Resources.walker, SizeMode = PictureBoxSizeMode.StretchImage },
                x, y);
            }
            else
            {
                tablero.Controls.Add(
                new PictureBox() { Image = JuegoCaminoMasCorto.Properties.Resources.walkerR, SizeMode = PictureBoxSizeMode.StretchImage },
                x, y);
            }
        }

        public void drawFinalPoint(int x, int y)
        {
            destino = new PictureBox();
            destino.Image = JuegoCaminoMasCorto.Properties.Resources.flag;
            destino.SizeMode = PictureBoxSizeMode.StretchImage;
            tablero.Controls.Add(destino,x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (movimientos == limiteMovimientos)
            {
                MessageBox.Show("Se llegó al limite de movimiento");
                timer1.Stop();//detenemos el timer
            }
            else if (persona.Equals(Salida))
            {
                timer1.Stop();//detenemos el timer
                lblTotalMovimientos.Text = "Se llego al final de laberinto en: " + movimientos + " movimientos.";
                lblTotalMovimientos.ForeColor = Color.Red;
                MessageBox.Show("¡¡¡ Fin del juego !!!");
            }//Fin de que si encuentra la salida.
            else
            {
                persona.Mover();
                drawPoint(persona.Posicion.X, persona.Posicion.Y);
                movimientos++;
                lblTotalMovimientos.Text = "No. Movimientos: " + movimientos + " movimientos.";
            }//Fin de que si no ha encuentrado la salida.
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
