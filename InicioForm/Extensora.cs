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

        static Extensora() {
            Extensora.sonidoUno = new SoundPlayer();
            sonidoUno.Stream = Properties.Resources.uno;
        }


        public static void MostrarAyuda(this Form formulario, Control control, string mensaje)
        {
            ToolTip yourToolTip = new ToolTip();
            //yourToolTip.ToolTipIcon = ToolTipIcon.Info;
            //yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            yourToolTip.SetToolTip(control, mensaje);
        }

        public static void ReproducirRuido (this Button boton,bool quitarSonido)
        {
            if(!quitarSonido)
                sonidoUno.Play();
        }

    }
}
