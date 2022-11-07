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
            
            if ((tipo == ETipo.MasDos || tipo==ETipo.Salteo || tipo==ETipo.Invertir || tipo == ETipo.Numero) && color == EColor.Negro)
            {
                throw new CreacionCartaException();
            }

            this.color = color;
            this.tipo = tipo;
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
                    this.color = EColor.Negro;
                    break;
                case ETipo.MasCuatro:
                    this.numero = -5;
                    this.color = EColor.Negro;
                    break;
                default:
                    this.numero = 0;
                    break;
            }
        }

        public Carta(ETipo tipo,EColor color,int numero):this(tipo,color)
        {
            if (numero >= 0 && numero <= 9)
                this.numero = numero;
            else
                throw new CreacionCartaException();
            
        }

        public static bool operator ==(Carta c1,Carta c2)
        {
            bool retorno = false;
            if((c1 is null && c2 is null) || (c1.color == c2.color && c1.tipo == c2.tipo && c1.numero == c2.numero))
            {
                retorno = true;
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

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Carta)
            {
                retorno = this == ((Carta)obj);
            }

            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }
    }
}
