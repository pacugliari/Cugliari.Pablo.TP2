using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Carta
    {
        private ETipo tipo;
        private EColor color;
        private int numero;

        public ETipo Tipo { get { return this.tipo; } }
        public EColor Color { get { return this.color; } }
        public int Numero { get { return this.numero; } }

        public Carta(ETipo tipo, EColor color)
        {
            this.tipo = tipo;
            this.color = color;
            switch (tipo)
            {
                case ETipo.MasDos:
                    this.numero = -1;
                    break;
                case ETipo.Salteo:
                    this.numero = -2;
                    break;
                case ETipo.Invertir:
                    this.numero = -3;
                    break;
                case ETipo.CambioColor:
                    this.numero = -4;
                    break;
                case ETipo.MasCuatro:
                    this.numero = -5;
                    break;
                default:
                    this.numero = 0;
                    break;
            }
        }

        public Carta(ETipo tipo,EColor color,int numero):this(tipo,color)
        {
            this.numero = numero;
            
        }

        public static bool operator ==(Carta c1,Carta c2)
        {
            bool retorno = false;
            if(c1 is not null && c2 is not null)
            {
                if (c1.color == EColor.Negro && c2.color == EColor.Negro && c1.tipo == c2.tipo)
                {
                    retorno = true;
                }
                else if (c1.color == c2.color || c1.numero == c2.numero)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        public static bool operator !=(Carta c1, Carta c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            string texto = $"Tipo: {this.tipo.ToString()} Color: {this.color.ToString()}";

            return (this.tipo != ETipo.Numero) ? texto : texto + ($" Numero: {this.numero}");
        }
    }
}
