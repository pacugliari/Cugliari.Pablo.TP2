using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
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
        private Cronometro cronometro;
        private bool hayGanador;
        private static SoundPlayer sonidoCarta;
        private static SoundPlayer sonidoMazo;
        private static SoundPlayer sonidoGanador;
        private static SoundPlayer sonidoUno;
        private bool quitarSonido;

        /// <summary>
        /// Constructor estatico que inicializa los sonidos del juego
        /// </summary>
        static PartidaForm()
        {

            PartidaForm.sonidoCarta = new SoundPlayer();
            PartidaForm.sonidoCarta.Stream = Properties.Resources.carta;

            PartidaForm.sonidoMazo = new SoundPlayer();
            PartidaForm.sonidoMazo.Stream = Properties.Resources.mazo;

            PartidaForm.sonidoGanador = new SoundPlayer();
            PartidaForm.sonidoGanador.Stream = Properties.Resources.victoria;

            PartidaForm.sonidoUno = new SoundPlayer();
            PartidaForm.sonidoUno.Stream = Properties.Resources.uno;
        }

        /// <summary>
        /// Crea una instancia del tipo PartidaForm, inicializando el nombre de los jugadores con los del parametro,el cronometro,
        /// mensajes de ayuda,la partida y controles a valores validos
        /// </summary>
        /// <param name="nombreJ1"></param>
        /// <param name="nombreJ2"></param>
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
            this.lblPaginaCartasJugador1.Text = this.jugadorUno.PaginaCartas.ToString();
            this.lblPaginaCartasJugador2.Text = this.jugadorDos.PaginaCartas.ToString();
            this.ActualizarColorPartida();
            this.cronometro.IniciarCronometro();
            this.Actualizar();

            this.MostrarAyuda(this.btnColorActual, "Color actual de la partida");
            this.MostrarAyuda(this.btnMazo, "Click para agarrar una carta del mazo");
            this.MostrarAyuda(this.btnPasarTurno, "Click para pasar turno al siguiente jugador");
            this.MostrarAyuda(this.btnTiradas, "Cartas ya jugadas");
            this.MostrarAyuda(this.lblJ1, "Jugador 1");
            this.MostrarAyuda(this.lblJ2, "Jugador 2");
            this.MostrarAyuda(this.pbManoJ1, "Jugador Actual");
            this.MostrarAyuda(this.pbManoJ2, "Jugador Actual");
            this.MostrarAyuda(this.lblDuracion, "Tiempo transcurrido de la partida");

            this.quitarSonido = false;

            //SUSCRIBO AL EVENTO CAMBIO DE COLOR DE LOS JUGADORES LA FUNCION QUE MUESTRA EL FORMULARIO
            //DE SELECCION DE COLOR
            this.jugadorUno.cambioColor += this.HabilitarCambioColor;
            this.jugadorDos.cambioColor += this.HabilitarCambioColor;

        }

        /// <summary>
        /// Habilita la visibilidad de cartas sumadas por un +2 o +4 por el oponente
        /// </summary>
        private void HabilitarVisionCartasSumadas()
        {
            this.partida.JugadorActual.ActualizarJugador(this.partida);
            this.CargarImagenesCartas();
        }

        /// <summary>
        /// Deshabilita el boton saltear turno si no recogio carta
        /// </summary>
        private void HabilitarPasoTurno()
        {
            if (!this.partida.JugadorActual.RecogioCarta)
                this.btnPasarTurno.Visible = false;
        }

        /// <summary>
        /// Muestra el formulario de cambio de color de partida si corresponde
        /// </summary>
        private void HabilitarCambioColor()
        {
            //SI SE TIRO CARTA DE CAMBIO DE COLOR MUESTRA EL FORMULARIO DE SELECCION
            SeleccionColorForm color = new SeleccionColorForm(this.partida);
            color.ShowDialog();
            this.ActualizarColorPartida();
        }

        /// <summary>
        /// Carga el color correspondiente a la partida
        /// </summary>
        private void ActualizarColorPartida()
        {

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

        }

        /// <summary>
        /// Verifica si la ultima carta tirada genera un salteo de jugador, caso afirmativo hace el cambio de turno
        /// </summary>
        private void SalteoJugadorActual()
        {
            //SALTEA EL TURNO DEL JUGADOR PORQUE LA ULTIMA CARTA TIRADA FUE SALTEO,+2,+4,INVERSION DE RONDA
            if (!this.partida.yaSeSalteo && (this.partida.UltimaCartaTirada.Tipo != ETipo.Numero && this.partida.UltimaCartaTirada.Tipo != ETipo.CambioColor))
            {
                this.partida.SiguienteJugador();
                this.partida.yaSeSalteo = true;
            }
        }


        /// <summary>
        /// Habilita el pictureBox que indica el jugador actual
        /// </summary>
        private void ActualizarIndicadorJugadorActual()
        {
            if (this.partida.JugadorActual.NumeroJugador == (int)EJugadores.Jugador1)//1
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



        /// <summary>
        /// Ejecuta serie de funciones para actualizar la vista,controles,etc cuando se realiza una accion y poder
        /// reflejar tanto los cambios en la vista y en la logica
        /// </summary>
        private void Actualizar()
        {
            this.HabilitarPasoTurno();
            this.HabilitarVisionCartasSumadas();
            this.CargarImagenesCartas();
            this.ActualizarColorPartida();
            this.SalteoJugadorActual();
            this.ActualizarIndicadorJugadorActual();
            this.ContarCartas();
        }

        /// <summary>
        /// Actualiza los label que lleva el control de la cantidad de cartas en el mazo y las ya jugadas
        /// </summary>
        private void ContarCartas()
        {
            this.lblCantidadMazo.Text = this.partida.Mazo.CantidadCartas.ToString();
            this.lblCantidadTiradas.Text = this.partida.CartasTiradas.Count.ToString();
        }


        /// <summary>
        /// Carga las imagenes de las cartas segun las cartas que tiene los jugadores
        /// </summary>
        private void CargarImagenesCartas()
        {
            List<Button> lista;
            Bitmap imagen;
            Carta ultimaTirada;

            foreach (Jugador jugador in this.partida.Jugadores)
            {
                lista = this.cartasJ1;
                imagen = null;
                ultimaTirada = this.partida.CartasTiradas.Peek();

                if (jugador.NumeroJugador == 2)
                {
                    lista = this.cartasJ2;
                }

                this.btnTiradas.BackgroundImage = this.BuscarImagenCarta(ultimaTirada);


                foreach (Button botonCarta in lista)
                {
                    switch (botonCarta.Name)
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
                    {
                        botonCarta.BackgroundImage = imagen;
                        botonCarta.Visible = true;
                    }
                    else
                        botonCarta.Visible = false;
                }

            }
            
        }

        /// <summary>
        /// Busca el Bitmap(imagen del Properties.Resources) de la carta pasada por parametro
        /// </summary>
        /// <param name="carta">Carta que se requiere el bitmap</param>
        /// <returns>Bitmap buscado</returns>
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


        /// <summary>
        /// Muestra el formulario con el jugador ganador, cargando el acontecimiento en el log de la partida, agregando dicha
        /// partida finalizada en la base de datos y cerrando el formulario principal de la partida
        /// </summary>
        /// <param name="jugador"></param>
        private void MensajeGanador(string jugador)
        {
            if(!this.quitarSonido)
                PartidaForm.sonidoGanador.Play();

            int puntosGanador = this.partida.JugadorActual.ObtenerPuntos();
            string duracion = this.cronometro.DetenerCronometro();
            string texto = $"GANADOR: {jugador} TIEMPO: {duracion} PUNTOS: {puntosGanador}";
            GanadorForm ganador = new GanadorForm(jugador, puntosGanador.ToString(), duracion);
            ganador.ShowDialog();

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
            if(SQL.ProbarConexion())
                SQL.AgregarDato(dato);

            this.hayGanador = true;
            this.Close();

            foreach (Control item in this.Controls)
            {
                 item.Visible = false;
            }
        }

        /// <summary>
        /// Habilita una imagen para indicar que el jugador tiene 1 sola carta
        /// </summary>
        /// <param name="numeroJugador">int, numero del jugador que se quedo con 1 sola carta</param>
        private void MensajeUno(int numeroJugador)
        {
            if (!this.quitarSonido)
                PartidaForm.sonidoUno.Play();
            if (numeroJugador == 1)
            {
                this.pbUnoJ1.Visible = true;
            }
            else
            {
                this.pbUnoJ2.Visible = true;
            }
        }


        /// <summary>
        /// Evento click de la carta seleccionada por el jugador al momento de hacer una jugada, comprobando que pudo tirar la
        /// carta, ocultandola si fue tirada con exito y capturando las excepciones MensajeGanadorException o MensajeUnoException
        /// si fuese necesario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarta_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            bool jugoCarta = false;
            try
            {

                switch (boton.Name)
                {
                    case "btnCarta1J1":
                        this.btnCarta1J1.Visible = !(jugoCarta = this.jugadorUno.Jugar(this.partida,0));
                        break;
                    case "btnCarta2J1":
                        this.btnCarta2J1.Visible = !(jugoCarta= this.jugadorUno.Jugar(this.partida,1));
                        break;
                    case "btnCarta3J1":
                        this.btnCarta3J1.Visible = !(jugoCarta = this.jugadorUno.Jugar(this.partida,2));
                        break;
                    case "btnCarta4J1":
                        this.btnCarta4J1.Visible = !(jugoCarta=this.jugadorUno.Jugar(this.partida,3));
                        break;
                    case "btnCarta5J1":
                        this.btnCarta5J1.Visible = !(jugoCarta = this.jugadorUno.Jugar(this.partida,4));
                        break;
                    case "btnCarta6J1":
                        this.btnCarta6J1.Visible = !(jugoCarta=this.jugadorUno.Jugar(this.partida,5));
                        break;
                    case "btnCarta7J1":
                        this.btnCarta7J1.Visible = !(jugoCarta=this.jugadorUno.Jugar(this.partida,6));
                        break;
                    case "btnCarta1J2":
                        this.btnCarta1J2.Visible = !(jugoCarta=this.jugadorDos.Jugar(this.partida,0));
                        break;
                    case "btnCarta2J2":
                        this.btnCarta2J2.Visible = !(jugoCarta = this.jugadorDos.Jugar(this.partida,1));
                        break;
                    case "btnCarta3J2":
                        this.btnCarta3J2.Visible = !(jugoCarta = this.jugadorDos.Jugar(this.partida,2));
                        break;
                    case "btnCarta4J2":
                        this.btnCarta4J2.Visible = !(jugoCarta = this.jugadorDos.Jugar(this.partida,3));
                        break;
                    case "btnCarta5J2":
                        this.btnCarta5J2.Visible = !(jugoCarta = this.jugadorDos.Jugar(this.partida,4));
                        break;
                    case "btnCarta6J2":
                        this.btnCarta6J2.Visible = !(jugoCarta =this.jugadorDos.Jugar(this.partida,5));
                        break;
                    case "btnCarta7J2":
                        this.btnCarta7J2.Visible = !(jugoCarta = this.jugadorDos.Jugar(this.partida,6));
                        break;
                }
                if (jugoCarta  && !this.quitarSonido)
                    PartidaForm.sonidoCarta.Play();

            }
            catch (MensajeGanadorException ex)//0
            {
                this.MensajeGanador(ex.Message);   
            }
            catch (MensajeUnoException ex)//1
            {
                this.MensajeUno(int.Parse(ex.Message));
                this.timer1.Enabled = true;
                this.timer1.Stop();
                this.timer1.Start();
            }
            finally
            {
                this.Actualizar();
            }

        }

        /// <summary>
        /// Agrega una carta a la mano del jugador que hizo el click sobre el mazo, agregando dicho acontecimiento 
        /// al log y actualizando la vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMazo_Click(object sender, EventArgs e)
        {

            List<int> posiciones;

            if (this.partida.JugadorActual.CantidadCartas == 108)
            {
                this.btnPasarTurno.Visible = true;
            }else if (!this.partida.JugadorActual.RecogioCarta)
            {
                posiciones = this.partida.JugadorActual.AgregarCartas(this.partida.Mazo.ObtenerCartas(this.partida, 1));
                if (posiciones.Count > 0)
                {
                    this.btnPasarTurno.Visible = true;
                    if (!this.quitarSonido)
                        PartidaForm.sonidoMazo.Play();
                    this.partida.JugadorActual.RecogioCarta = true;
                    this.partida.log.AgregarAlLog($"[{DateTime.Now}][{this.partida.JugadorActual.Nombre}][AGARRA CARTA DEL MAZO]");
                }
                this.Actualizar();
            }
  
        }

        /// <summary>
        /// Permite pasar el turno al siguiente jugador en el caso que no pueda realizar ninguna accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPasarTurno_Click(object sender, EventArgs e)
        {
            ((Button)sender).ReproducirRuido(quitarSonido);
            this.partida.log.AgregarAlLog($"[{DateTime.Now}][{this.partida.JugadorActual.Nombre}][PASA TURNO]");
            this.partida.SiguienteJugador();
            this.Actualizar();

        }

        /// <summary>
        /// Pregunta de confirmacion si desea cancelar la partida con posibilidiad de guardarla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        if (SQL.ProbarConexion())
                            SQL.AgregarDato(dato);
                    }
                }
            }
            this.hayGanador = false;
           
        }

        /// <summary>
        /// Actualiza el Label que lleva la duracion de la partida
        /// </summary>
        /// <param name="tiempo"></param>
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

        /// <summary>
        /// Una vez pasado el tiempo de intervalo del timer , deshabilita el picture box del jugador que mostro
        /// la imagen de ultima carta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pbUnoJ1.Visible = false;
            this.pbUnoJ2.Visible = false;
            this.timer1.Stop();
        }

        /// <summary>
        /// Permite deshabilitar el sonido del juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMusica_Click(object sender, EventArgs e)
        {
            if (!this.quitarSonido)
            {
                this.btnMusica.BackgroundImage = Properties.Resources.mutearMusica;
            }
            else
            {
                this.btnMusica.BackgroundImage = Properties.Resources.musica;
            }
            this.quitarSonido = !this.quitarSonido;
        }

        /// <summary>
        /// Permite avanzar a las paginas de cartas superiores del jugador 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDerecha1_Click(object sender, EventArgs e)
        {
            if(this.partida.IndiceJugadorActual == (int)EJugadores.Jugador1)
            {
                this.partida.JugadorActual.AvanzarPaginaCartas();
                this.CargarImagenesCartas();
            }
            this.lblPaginaCartasJugador1.Text = this.jugadorUno.PaginaCartas.ToString();
            
        }

        /// <summary>
        /// Permite avanzar a las paginas de cartas inferiores del jugador 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIzquierda1_Click(object sender, EventArgs e)
        {
            if (this.partida.IndiceJugadorActual == (int)EJugadores.Jugador1)
            {
                this.partida.JugadorActual.RetrocederPaginaCartas();
                this.CargarImagenesCartas();
            }
            this.lblPaginaCartasJugador1.Text = this.jugadorUno.PaginaCartas.ToString();
        }

        /// <summary>
        /// Permite avanzar a las paginas de cartas superiores del jugador 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDerecha2_Click(object sender, EventArgs e)
        {
            if (this.partida.IndiceJugadorActual == (int)EJugadores.Jugador2)
            {
                this.partida.JugadorActual.AvanzarPaginaCartas();
                this.CargarImagenesCartas();
            }
            this.lblPaginaCartasJugador2.Text = this.jugadorDos.PaginaCartas.ToString();
        }

        /// <summary>
        /// Permite avanzar a las paginas de cartas inferiores del jugador 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIzquierda2_Click(object sender, EventArgs e)
        {
            if (this.partida.IndiceJugadorActual == (int)EJugadores.Jugador2)
            {
                this.partida.JugadorActual.RetrocederPaginaCartas();
                this.CargarImagenesCartas();
            }
            this.lblPaginaCartasJugador2.Text = this.jugadorDos.PaginaCartas.ToString();
        }
    }
}
