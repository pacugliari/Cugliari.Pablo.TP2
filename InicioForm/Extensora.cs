using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnoPacGUI
{
    public static class Extensora
    {
        public static void MostrarAyuda(this Form formulario, Control control, string mensaje)
        {
            ToolTip yourToolTip = new ToolTip();
            //yourToolTip.ToolTipIcon = ToolTipIcon.Info;
            //yourToolTip.IsBalloon = true;
            yourToolTip.ShowAlways = true;
            yourToolTip.SetToolTip(control, mensaje);
        }
    }
}
