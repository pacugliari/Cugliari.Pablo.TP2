using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using static Entidades.Cronometro;

namespace UnoPacGUI
{
    public partial class PartidaForm : Form
    {

        private Partida partida;
        private List<Button> cartasJ1;
        private List<Button> cartasJ2;
        private Jugador jugadorUno;
        private Jugador jugadorDos;
        private bool hayCambioColor;
        private Cronometro cronometro;
        private bool hayGanador;

        public PartidaForm(string nombreJ1, string nombreJ2)
        {
            InitializeComponent();

            this.cartasJ1 = new List<Button> {this.btnCarta1J1, this.btnCarta2J1, this.btnCarta3J1 ,
                this.btnCarta4J1 , this.btnCarta5J1 , this.btnCarta6J1 , this.btnCarta7J1 };
            this.cartasJ2 = new List<Button> {this.btnCarta1J2, this.btnCarta2J2, this.btnCarta3J2 ,
                this.btnCarta4J2 , this.btnCarta5J2 , this.btnCarta6J2 , this.btnCarta7J2 };

            this.btnMazo.BackgroundImage = Properties.Resources.back_side;

            this.hayGanador = false;
            this.cronometro = new Cronometro(1000);
            this.cronometro.TiempoCumplido += this.ActualizarTiempo;

            this.partida = new Partida(nombreJ1, nombreJ2);
            this.lblJ1.Text = nombreJ1;
            this.lblJ2.Text = nombreJ2;
            this.jugadorUno = this.partida.Jugadores[0];
            this.jugadorDos = this.partida.Jugadores[1];
            this.btnPasarTurno.Visible = false;
            this.pbUnoJ1.Visible = false;
            this.pbUnoJ2.Visible = false;
            this.pbManoJ1.Visible = this.pbManoJ2.Visible = false;
            this.btnColorActual.BackgroundImage = Properties.Resources.colorVerde;
            this.cronometro.IniciarCronometro();
            this.actualizar();

            Inicio.MostrarAyuda(this.btnColorActual, "Color actual de la partida");
            Inicio.MostrarAyuda(this.btnMazo, "Click para agarrar una carta del mazo");
            Inicio.MostrarAyuda(this.btnPasarTurno, "Click para pasar turno al siguiente jugador");
            Inicio.MostrarAyuda(this.btnTiradas, "Cartas ya jugadas");
            Inicio.MostrarAyuda(this.lblJ1, "Jugador 1");
            Inicio.MostrarAyuda(this.lblJ2, "Jugador 2");
            Inicio.MostrarAyuda(this.pbManoJ1, "Jugador Actual");
            Inicio.MostrarAyuda(this.pbManoJ2, "Jugador Actual");
            Inicio.MostrarAyuda(this.lblDuracion, "Tiempo transcurrido de la partida");
        }


        private void actualizar()
        {


            //SI SE TIRO CARTA DE CAMBIO DE COLOR MUESTRA EL FORMULARIO DE SELECCION
            if (this.hayCambioColor)
            {
                SeleccionColorForm color = new SeleccionColorForm(this.partida);
                color.ShowDialog();
                this.hayCambioColor = false;
            }

            //DESHABILITA EL BOTON DE SALTEAR TURNO SI NO RECOGIO CARTA O NO TIENE 7 CARTAS
            if (!this.partida.JugadorActual.RecogioCarta && this.partida.JugadorActual.CantidadCartas != 7)
                this.btnPasarTurno.Visible = false;


            //HABILITA LA VISIBILIDAD CARTAS AGREGADAS POR UN +2,+4
            List<int> posiciones = this.partida.JugadorActual.ActualizarJugador(this.partida);

            foreach (int item in posiciones)
            {

                if (this.partida.JugadorActual.NumeroJugador == (int)EJugadores.Jugador1)//1
                {
                    this.cartasJ1[item].Visible = true;
                }
                else
                {
                    this.cartasJ2[item].Visible = true;
                }

            }


            //CARGA LAS IMAGENES DE LAS CARGAS QUE POSEE EL JUGADOR
            foreach (Jugador item in this.partida.Jugadores)
            {
                this.CargarImagenesCartas(item);

            }

            //CARGA EL COLOR ACTUAL DE LA PARTIDA
            switch (this.partida.ColorActual)
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
            if (!this.partida.yaSeSalteo && (this.partida.UltimaCartaTirada.Tipo != ETipo.Numero && this.partida.UltimaCartaTirada.Tipo != ETipo.CambioColor))
            {
                this.partida.SiguienteJugador();
                this.partida.yaSeSalteo = true;
            }

            //ACTUALIZA EL NOMBRE DEL JUGADOR ACTUAL
            //this.lblJ1.Text = Partida.JugadorActual.Nombre;
            if(this.partida.JugadorActual.NumeroJugador == (int)EJugadores.Jugador1)//1
            {
                this.pbManoJ1.Visible = true;
                this.pbManoJ2.Visible = false;
            }
            else
            {
                this.pbManoJ1.Visible = false;
                this.pbManoJ2.Visible = true;
            }

                
        }



        private void CargarImagenesCartas(Jugador jugador)
        {
            List<Button> lista = this.cartasJ1;
            Bitmap imagen = null;
            Carta ultimaTirada = this.partida.CartasTiradas.Peek();

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
            
            int puntosGanador = this.partida.JugadorActual.ObtenerPuntos();
            string duracion = this.cronometro.DetenerCronometro();
            string texto = $"GANADOR: {jugador} TIEMPO: {duracion} PUNTOS: {puntosGanador}";
            MessageBox.Show(texto);

            //AGREGO LOG GANADOR
            this.partida.log.AgregarAlLog($"[{DateTime.Now}][{texto}]");
            this.partida.log.AgregarAlLog($"[{DateTime.Now}][FIN DE PARTIDA]");
            ArchivosDeTexto.AgregarAlArchivo(this.partida.log);

            //AGREGO DATO EN SQL
            PartidaSQL dato = new PartidaSQL();
            dato.Fecha = DateTime.Now.ToString();
            dato.Jugador1 = this.partida.Jugadores[0].Nombre;
            dato.Jugador2 = this.partida.Jugadores[1].Nombre;
            dato.Ganador = jugador;
            dato.PuntosGanador = puntosGanador.ToString();
            dato.Duracion = duracion;
            SQL.AgregarDato(dato);

            this.hayGanador = true;
            this.Close();

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
                        this.btnCarta1J1.Visible = !this.jugadorUno.Jugar(this.partida, 0, out hayCambioColor);
                        break;
                    case "btnCarta2J1":
                        this.btnCarta2J1.Visible = !this.jugadorUno.Jugar(this.partida, 1, out hayCambioColor);
                        break;
                    case "btnCarta3J1":
                        this.btnCarta3J1.Visible = !this.jugadorUno.Jugar(this.partida, 2, out hayCambioColor);
                        break;
                    case "btnCarta4J1":
                        this.btnCarta4J1.Visible = !this.jugadorUno.Jugar(this.partida, 3, out hayCambioColor);
                        break;
                    case "btnCarta5J1":
                        this.btnCarta5J1.Visible = !this.jugadorUno.Jugar(this.partida, 4, out hayCambioColor);
                        break;
                    case "btnCarta6J1":
                        this.btnCarta6J1.Visible = !this.jugadorUno.Jugar(this.partida, 5, out hayCambioColor);
                        break;
                    case "btnCarta7J1":
                        this.btnCarta7J1.Visible = !this.jugadorUno.Jugar(this.partida, 6, out hayCambioColor);
                        break;
                    case "btnCarta1J2":
                        this.btnCarta1J2.Visible = !this.jugadorDos.Jugar(this.partida, 0, out hayCambioColor);
                        break;
                    case "btnCarta2J2":
                        this.btnCarta2J2.Visible = !this.jugadorDos.Jugar(this.partida, 1, out hayCambioColor);
                        break;
                    case "btnCarta3J2":
                        this.btnCarta3J2.Visible = !this.jugadorDos.Jugar(this.partida, 2, out hayCambioColor);
                        break;
                    case "btnCarta4J2":
                        this.btnCarta4J2.Visible = !this.jugadorDos.Jugar(this.partida, 3, out hayCambioColor);
                        break;
                    case "btnCarta5J2":
                        this.btnCarta5J2.Visible = !this.jugadorDos.Jugar(this.partida, 4, out hayCambioColor);
                        break;
                    case "btnCarta6J2":
                        this.btnCarta6J2.Visible = !this.jugadorDos.Jugar(this.partida, 5, out hayCambioColor);
                        break;
                    case "btnCarta7J2":
                        this.btnCarta7J2.Visible = !this.jugadorDos.Jugar(this.partida, 6, out hayCambioColor);
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

            if (this.partida.JugadorActual.CantidadCartas == 7)
            {
                this.btnPasarTurno.Visible = true;
            }else if (!this.partida.JugadorActual.RecogioCarta)
            {
                if (this.partida.IndiceJugadorActual == 1)
                {
                    posiciones = this.jugadorUno.AgregarCartas(this.partida.Mazo.ObtenerCartas(this.partida,1));
                    if (posiciones.Count > 0)
                        this.cartasJ1[posiciones[0]].Visible = this.btnPasarTurno.Visible =  true;
                }
                else
                {
                    posiciones = this.jugadorDos.AgregarCartas(this.partida.Mazo.ObtenerCartas(this.partida,1));
                    if (posiciones.Count > 0)
                        this.cartasJ2[posiciones[0]].Visible = this.btnPasarTurno.Visible = true;
                }

                if(posiciones.Count > 0)
                {
                    this.partida.JugadorActual.RecogioCarta = true;
                    this.partida.log.AgregarAlLog($"[{DateTime.Now}][{this.partida.JugadorActual.Nombre}][AGARRA CARTA DEL MAZO]");
                }
                this.actualizar();
            }
  
        }


        private void btnPasarTurno_Click(object sender, EventArgs e)
        {
            this.partida.log.AgregarAlLog($"[{DateTime.Now}][{this.partida.JugadorActual.Nombre}][PASA TURNO]");
            this.partida.SiguienteJugador();
            this.actualizar();

        }

        private void PartidaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.hayGanador)
            {
                DialogResult respuesta = MessageBox.Show("Esta seguro que desea cancelar la partida actual ?", "Uno Pac", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    respuesta = MessageBox.Show("Desea guardar los datos de la partida actual ?", "Uno Pac", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        string duracion = this.cronometro.DetenerCronometro();
                        //AGREGO LOG GANADOR
                        this.partida.log.AgregarAlLog($"[{DateTime.Now}][GANADOR: sin ganador TIEMPO: {duracion} PUNTOS: -]");
                        this.partida.log.AgregarAlLog($"[{DateTime.Now}][PARTIDA CANCELADA]");
                        ArchivosDeTexto.AgregarAlArchivo(this.partida.log);

                        //AGREGO DATO EN SQL
                        PartidaSQL dato = new PartidaSQL();
                        dato.Fecha = DateTime.Now.ToString();
                        dato.Jugador1 = this.partida.Jugadores[0].Nombre;
                        dato.Jugador2 = this.partida.Jugadores[1].Nombre;
                        dato.Ganador = "sin ganador";
                        dato.PuntosGanador = "sin ganador";
                        dato.Duracion = duracion;
                        SQL.AgregarDato(dato);
                    }
                }
            }
            this.hayGanador = false;
           
        }

        private void ActualizarTiempo(DateTime tiempo)
        {

            if (this.lblDuracion.InvokeRequired)
            {
                DelegadoCronometro delegado = this.ActualizarTiempo;
                object[] obj = new object[] { tiempo };
                this.lblDuracion.Invoke(delegado, tiempo);
            }
            else
            {
                this.lblDuracion.Text = $"Duracion: {tiempo.Hour}:{tiempo.Minute}:{tiempo.Second}";
            }
 
        }


    }
}
