﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace InicioForm
{
    public partial class Form1 : Form
    {

        private Partida partida;
        private List<Button> cartasJ1;
        private List<Button> cartasJ2;
        private Jugador jugadorUno;
        private Jugador jugadorDos;
        private bool hayCambioColor;
        public Form1()
        {
            InitializeComponent();
            this.cartasJ1 = new List<Button> {this.btnCarta1J1, this.btnCarta2J1, this.btnCarta3J1 ,
                this.btnCarta4J1 , this.btnCarta5J1 , this.btnCarta6J1 , this.btnCarta7J1 };
            this.cartasJ2 = new List<Button> {this.btnCarta1J2, this.btnCarta2J2, this.btnCarta3J2 ,
                this.btnCarta4J2 , this.btnCarta5J2 , this.btnCarta6J2 , this.btnCarta7J2 };

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.Visible = false;

                }
            }

            this.btnJugar.Visible = true;
            this.btnAyuda.Visible = true;
            this.pbUnoJ1.Visible = false;
            this.pbUnoJ2.Visible = false;
            this.lblJugador.Visible = false;
            this.btnMazo.BackgroundImage = Properties.Resources.back_side;

        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.Visible = true;

                }
            }

            this.btnJugar.Visible = false;
            this.lblJugador.Visible = true;

            this.partida = new Partida("Jugador 1", "Jugador 2");
            this.jugadorUno = Partida.Jugadores[0];
            this.jugadorDos = Partida.Jugadores[1];
            this.btnPasarTurno.Visible = false;
            this.pbUnoJ1.Visible = false;
            this.pbUnoJ2.Visible = false;

            /*foreach (var item in this.partida.Jugadores)
            {
                for (int i = 0; i < 7; i++)
                {
                    System.Diagnostics.Debug.WriteLine(item[i].ToString());
                }
                
            }*/

            this.actualizar();
        }



        private void actualizar()
        {


            //SI SE TIRO CARTA DE CAMBIO DE COLOR MUESTRA EL FORMULARIO DE SELECCION
            if (this.hayCambioColor)
            {
                SeleccionColorForm color = new SeleccionColorForm();
                color.ShowDialog();
                this.hayCambioColor = false;
            }

            //DESHABILITA EL BOTON DE SALTEAR TURNO SI NO RECOGIO CARTA O NO TIENE 7 CARTAS
            if (!Partida.JugadorActual.RecogioCarta && Partida.JugadorActual.CantidadCartas != 7)
                this.btnPasarTurno.Visible = false;


            //HABILITA LA VISIBILIDAD CARTAS AGREGADAS POR UN +2,+4
            List<int> posiciones = Partida.JugadorActual.ActualizarJugador();

            foreach (int item in posiciones)
            {

                if (Partida.JugadorActual.NumeroJugador == 1)
                {
                    this.cartasJ1[item].Visible = true;
                }
                else
                {
                    this.cartasJ2[item].Visible = true;
                }

            }


            //CARGA LAS IMAGENES DE LAS CARGAS QUE POSEE EL JUGADOR
            foreach (Jugador item in Partida.Jugadores)
            {
                this.CargarImagenesCartas(item);

            }

            //CARGA EL COLOR ACTUAL DE LA PARTIDA
            switch (Partida.ColorActual)
            {
                case EColor.Rojo:
                    this.btnColorActual.BackgroundImage = Properties.Resources.colorRojo;
                    break;
                case EColor.Verde:
                    this.btnColorActual.BackgroundImage = Properties.Resources.colorVerde;
                    break;
                case EColor.Amarillo:
                    this.btnColorActual.BackgroundImage = Properties.Resources.colorAmarillo;
                    break;
                case EColor.Azul:
                    this.btnColorActual.BackgroundImage = Properties.Resources.colorAzul;
                    break;
            }

            //SALTEA EL TURNO DEL JUGADOR PORQUE LA ULTIMA CARTA TIRADA FUE SALTEO,+2,+4,INVERSION DE RONDA
            if (!Partida.yaSeSalteo && (Partida.UltimaCartaTirada.Tipo != ETipo.Numero && Partida.UltimaCartaTirada.Tipo != ETipo.CambioColor))
            {
                Partida.SiguienteJugador();
                Partida.yaSeSalteo = true;
            }

            //ACTUALIZA EL NOMBRE DEL JUGADOR ACTUAL
            this.lblJugador.Text = Partida.JugadorActual.Nombre;

                
        }



        private void CargarImagenesCartas(Jugador jugador)
        {
            List<Button> lista = this.cartasJ1;
            Bitmap imagen = null;
            Carta ultimaTirada = Partida.CartasTiradas.Peek();

            if (jugador.NumeroJugador == 2)
            {
                lista = this.cartasJ2;
            }

            this.btnTiradas.BackgroundImage = this.BuscarImagenCarta(ultimaTirada);


            foreach (Button item in lista)
            {
                switch (item.Name)
                {
                    case "btnCarta1J1":
                    case "btnCarta1J2":
                        imagen = this.BuscarImagenCarta(jugador[0]);
                        break;
                    case "btnCarta2J1":
                    case "btnCarta2J2":
                        imagen = this.BuscarImagenCarta(jugador[1]);
                        break;
                    case "btnCarta3J1":
                    case "btnCarta3J2":
                        imagen = this.BuscarImagenCarta(jugador[2]);
                        break;
                    case "btnCarta4J1":
                    case "btnCarta4J2":
                        imagen = this.BuscarImagenCarta(jugador[3]);
                        break;
                    case "btnCarta5J1":
                    case "btnCarta5J2":
                        imagen = this.BuscarImagenCarta(jugador[4]);
                        break;
                    case "btnCarta6J1":
                    case "btnCarta6J2":
                        imagen = this.BuscarImagenCarta(jugador[5]);
                        break;
                    case "btnCarta7J1":
                    case "btnCarta7J2":
                        imagen = this.BuscarImagenCarta(jugador[6]);
                        break;
                }
                if (imagen is not null)
                    item.BackgroundImage = imagen;
                else
                    item.Visible = false;
            }
        }
        private Bitmap BuscarImagenCarta(Carta carta)
        {
            Bitmap retorno = null;
            if(carta is not null)
            {
                switch (carta.Color)
                {
                    case EColor.Amarillo:
                        switch (carta.Numero)
                        {
                            case 0:
                                retorno = Properties.Resources.y_0;
                                break;
                            case 1:
                                retorno = Properties.Resources.y_1;
                                break;
                            case 2:
                                retorno = Properties.Resources.y_2;
                                break;
                            case 3:
                                retorno = Properties.Resources.y_3;
                                break;
                            case 4:
                                retorno = Properties.Resources.y_4;
                                break;
                            case 5:
                                retorno = Properties.Resources.y_5;
                                break;
                            case 6:
                                retorno = Properties.Resources.y_6;
                                break;
                            case 7:
                                retorno = Properties.Resources.y_7;
                                break;
                            case 8:
                                retorno = Properties.Resources.y_8;
                                break;
                            case 9:
                                retorno = Properties.Resources.y_9;
                                break;
                            default:
                                switch (carta.Tipo)
                                {
                                    case ETipo.Invertir:
                                        retorno = Properties.Resources.y_reverse;
                                        break;
                                    case ETipo.MasDos:
                                        retorno = Properties.Resources.y_draw2;
                                        break;
                                    case ETipo.Salteo:
                                        retorno = Properties.Resources.y_skip;
                                        break;
                                }
                                break;
                        }
                        break;
                    case EColor.Azul:
                        switch (carta.Numero)
                        {
                            case 0:
                                retorno = Properties.Resources.b_0;
                                break;
                            case 1:
                                retorno = Properties.Resources.b_1;
                                break;
                            case 2:
                                retorno = Properties.Resources.b_2;
                                break;
                            case 3:
                                retorno = Properties.Resources.b_3;
                                break;
                            case 4:
                                retorno = Properties.Resources.b_4;
                                break;
                            case 5:
                                retorno = Properties.Resources.b_5;
                                break;
                            case 6:
                                retorno = Properties.Resources.b_6;
                                break;
                            case 7:
                                retorno = Properties.Resources.b_7;
                                break;
                            case 8:
                                retorno = Properties.Resources.b_8;
                                break;
                            case 9:
                                retorno = Properties.Resources.b_9;
                                break;
                            default:
                                switch (carta.Tipo)
                                {
                                    case ETipo.Invertir:
                                        retorno = Properties.Resources.b_reverse;
                                        break;
                                    case ETipo.MasDos:
                                        retorno = Properties.Resources.b_draw2;
                                        break;
                                    case ETipo.Salteo:
                                        retorno = Properties.Resources.b_skip;
                                        break;
                                }
                                break;
                        }
                        break;
                    case EColor.Verde:
                        switch (carta.Numero)
                        {
                            case 0:
                                retorno = Properties.Resources.g_0;
                                break;
                            case 1:
                                retorno = Properties.Resources.g_1;
                                break;
                            case 2:
                                retorno = Properties.Resources.g_2;
                                break;
                            case 3:
                                retorno = Properties.Resources.g_3;
                                break;
                            case 4:
                                retorno = Properties.Resources.g_4;
                                break;
                            case 5:
                                retorno = Properties.Resources.g_5;
                                break;
                            case 6:
                                retorno = Properties.Resources.g_6;
                                break;
                            case 7:
                                retorno = Properties.Resources.g_7;
                                break;
                            case 8:
                                retorno = Properties.Resources.g_8;
                                break;
                            case 9:
                                retorno = Properties.Resources.g_9;
                                break;
                            default:
                                switch (carta.Tipo)
                                {
                                    case ETipo.Invertir:
                                        retorno = Properties.Resources.g_reverse;
                                        break;
                                    case ETipo.MasDos:
                                        retorno = Properties.Resources.g_draw2;
                                        break;
                                    case ETipo.Salteo:
                                        retorno = Properties.Resources.g_skip;
                                        break;
                                }
                                break;
                        }
                        break;
                    case EColor.Rojo:
                        switch (carta.Numero)
                        {
                            case 0:
                                retorno = Properties.Resources.r_0;
                                break;
                            case 1:
                                retorno = Properties.Resources.r_1;
                                break;
                            case 2:
                                retorno = Properties.Resources.r_2;
                                break;
                            case 3:
                                retorno = Properties.Resources.r_3;
                                break;
                            case 4:
                                retorno = Properties.Resources.r_4;
                                break;
                            case 5:
                                retorno = Properties.Resources.r_5;
                                break;
                            case 6:
                                retorno = Properties.Resources.r_6;
                                break;
                            case 7:
                                retorno = Properties.Resources.r_7;
                                break;
                            case 8:
                                retorno = Properties.Resources.r_8;
                                break;
                            case 9:
                                retorno = Properties.Resources.r_9;
                                break;
                            default:
                                switch (carta.Tipo)
                                {
                                    case ETipo.Invertir:
                                        retorno = Properties.Resources.r_reverse;
                                        break;
                                    case ETipo.MasDos:
                                        retorno = Properties.Resources.r_draw2;
                                        break;
                                    case ETipo.Salteo:
                                        retorno = Properties.Resources.r_skip;
                                        break;
                                }
                                break;
                        }
                        break;
                    case EColor.Negro:
                        switch (carta.Tipo)
                        {
                            case ETipo.CambioColor:
                                retorno = Properties.Resources.wild;
                                break;
                            case ETipo.MasCuatro:
                                retorno = Properties.Resources.wild_draw4;
                                break;
                        }
                        break;
                }
            }
            
            return retorno;
        }

        private void MensajeGanador(string jugador)
        {
            MessageBox.Show($"GANADOR: {jugador} TIEMPO: {Partida.CalcularTiempo()} PUNTOS: {Partida.JugadorActual.ObtenerPuntos()}");
            

            foreach (Control item in this.Controls)
            {
                 item.Visible = false;
            }
        }

        private void MensajeUno(int numeroJugador)
        {
            if (numeroJugador == 1)
            {
                this.pbUnoJ1.Visible = true;
            }
            else
            {
                this.pbUnoJ2.Visible = true;
            }
        }

        private void btnCarta_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            try
            {
                this.pbUnoJ1.Visible = false;
                this.pbUnoJ2.Visible = false;

                switch (boton.Name)
                {
                    case "btnCarta1J1":
                        this.btnCarta1J1.Visible = !this.jugadorUno.Jugar(0, out hayCambioColor);
                        break;
                    case "btnCarta2J1":
                        this.btnCarta2J1.Visible = !this.jugadorUno.Jugar(1, out hayCambioColor);
                        break;
                    case "btnCarta3J1":
                        this.btnCarta3J1.Visible = !this.jugadorUno.Jugar(2, out hayCambioColor);
                        break;
                    case "btnCarta4J1":
                        this.btnCarta4J1.Visible = !this.jugadorUno.Jugar(3, out hayCambioColor);
                        break;
                    case "btnCarta5J1":
                        this.btnCarta5J1.Visible = !this.jugadorUno.Jugar(4, out hayCambioColor);
                        break;
                    case "btnCarta6J1":
                        this.btnCarta6J1.Visible = !this.jugadorUno.Jugar(5, out hayCambioColor);
                        break;
                    case "btnCarta7J1":
                        this.btnCarta7J1.Visible = !this.jugadorUno.Jugar(6, out hayCambioColor);
                        break;
                    case "btnCarta1J2":
                        this.btnCarta1J2.Visible = !this.jugadorDos.Jugar(0, out hayCambioColor);
                        break;
                    case "btnCarta2J2":
                        this.btnCarta2J2.Visible = !this.jugadorDos.Jugar(1, out hayCambioColor);
                        break;
                    case "btnCarta3J2":
                        this.btnCarta3J2.Visible = !this.jugadorDos.Jugar(2, out hayCambioColor);
                        break;
                    case "btnCarta4J2":
                        this.btnCarta4J2.Visible = !this.jugadorDos.Jugar(3, out hayCambioColor);
                        break;
                    case "btnCarta5J2":
                        this.btnCarta5J2.Visible = !this.jugadorDos.Jugar(4, out hayCambioColor);
                        break;
                    case "btnCarta6J2":
                        this.btnCarta6J2.Visible = !this.jugadorDos.Jugar(5, out hayCambioColor);
                        break;
                    case "btnCarta7J2":
                        this.btnCarta7J2.Visible = !this.jugadorDos.Jugar(6, out hayCambioColor);
                        break;
                }
             
            }
            catch (MensajeGanadorException ex)//0
            {
                this.MensajeGanador(ex.Message);   
            }
            catch (MensajeUnoException ex)//1
            {
                this.MensajeUno(int.Parse(ex.Message));
            }
            finally
            {
                this.actualizar();
            }

        }

        private void btnMazo_Click(object sender, EventArgs e)
        {

            List<int> posiciones;
            if (Partida.JugadorActual.CantidadCartas == 7)
            {
                this.btnPasarTurno.Visible = true;
            }else if (!Partida.JugadorActual.RecogioCarta)
            {
                if (Partida.IndiceJugadorActual == 1)
                {
                    posiciones = this.jugadorUno.AgregarCartas(Mazo.ObtenerCartas(1));
                    if (posiciones.Count > 0)
                        this.cartasJ1[posiciones[0]].Visible = this.btnPasarTurno.Visible =  true;
                }
                else
                {
                    posiciones = this.jugadorDos.AgregarCartas(Mazo.ObtenerCartas(1));
                    if (posiciones.Count > 0)
                        this.cartasJ2[posiciones[0]].Visible = this.btnPasarTurno.Visible = true;
                }

                if(posiciones.Count > 0)
                {
                    Partida.JugadorActual.RecogioCarta = true;
                }
                this.actualizar();
            }
  
        }


        private void btnPasarTurno_Click(object sender, EventArgs e)
        {

            Partida.SiguienteJugador();
            this.actualizar();

        }
    }
}
