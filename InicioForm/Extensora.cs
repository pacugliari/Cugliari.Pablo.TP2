using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnoPacGUI
{


    public static class Extensora
    {

        private static SoundPlayer sonidoUno;

        /// <summary>
        /// Constructor estatico que inicializa el sonido que va a reproducir el metodo ReproducirRuido
        /// </summary>
        static Extensora() {
            Extensora.sonidoUno = new SoundPlayer();
            sonidoUno.Stream = Properties.Resources.uno;
        }

        /// <summary>
        /// Metodo de extension que sirve para asignar un ToolTip al control del parametro que pertenece al
        /// formulario del parametro, dicho mensaje de ayuda sera el valor del mensaje del parametro
        /// </summary>
        /// <param name="formulario">Form, contiene el control que desea el mensaje de ayuda</param>
        /// <param name="control">Control, control que necesita mensaje de ayuda</param>
        /// <param name="mensaje">string, mensaje a mostrar en la ayuda</param>
        public static void MostrarAyuda(this Form formulario, Control control, string mensaje)
        {
            ToolTip yourToolTip = new ToolTip();
            //yourToolTip.ToolTipIcon = ToolTipIcon.Info;
            //yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            yourToolTip.SetToolTip(control, mensaje);
        }

        /// <summary>
        /// Metodo de extension que sirve para reproducir sonido cuando es accionado el boton siempre y cuando
        /// el parametro quitarSonido este en false
        /// </summary>
        /// <param name="boton">Boton que se le asigna el sonido</param>
        /// <param name="quitarSonido">bool, indica si esta habilitado o no el sonido</param>
        public static void ReproducirRuido (this Button boton,bool quitarSonido)
        {
            if(!quitarSonido)
                sonidoUno.Play();
        }

    }
}
