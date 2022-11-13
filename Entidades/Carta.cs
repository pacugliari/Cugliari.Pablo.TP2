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

        /// <summary>
        /// Propiedad tipo get para consultar el tipo de carta
        /// </summary>
        public ETipo Tipo { get { return this.tipo; } }
        /// <summary>
        /// Propiedad tipo get para consultar el color de la carta
        /// </summary>
        public EColor Color { get { return this.color; } }
        /// <summary>
        /// Propiedad tipo get para consultar el numero de la carta
        /// </summary>
        public int Numero { get { return this.numero; } }

        /// <summary>
        /// Crea una instancia de Carta con el tipo y color del parametro validandolo,inicializa los numeros
        /// de las cartas especiales con negativos y el de numeros con 0
        /// </summary>
        /// <param name="tipo">ETipo, enumerado que contiene los tipos de cartas</param>
        /// <param name="color">EColor,enumerado que contiene los colores de cartas</param>
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

        /// <summary>
        /// Crea una instancia del tipo Carta con el tipo,color y numero del parametro validando los datos
        /// </summary>
        /// <param name="tipo">ETipo, enumerado con los valores del tipo de carta</param>
        /// <param name="color">EColor, enumerado con los valores de los colores de las cartas</param>
        /// <param name="numero">int, numero de la carta entre 0 y 9</param>
        public Carta(ETipo tipo,EColor color,int numero):this(tipo,color)
        {
            if (numero >= 0 && numero <= 9)
                this.numero = numero;
            else
                throw new CreacionCartaException();
            
        }

        /// <summary>
        /// Compara si 2 cartas son iguales por color,tipo y numero o si ambas son nulas
        /// </summary>
        /// <param name="c1">Carta 1 a comparar</param>
        /// <param name="c2">Carta 2 a comparar</param>
        /// <returns>Si c1 es igual a c2 retorna true , sino false</returns>
        public static bool operator ==(Carta c1,Carta c2)
        {
            bool retorno = false;
            if((c1 is null && c2 is null) || (c1.color == c2.color && c1.tipo == c2.tipo && c1.numero == c2.numero))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Compara si 2 cartas son distintas reutilizando el == negado
        /// </summary>
        /// <param name="c1">Carta 1 a comparar</param>
        /// <param name="c2">Carta 2 a comparar</param>
        /// <returns>Si c1 es distinto de c2 retorna true, sino false</returns>
        public static bool operator !=(Carta c1, Carta c2)
        {
            return !(c1 == c2);
        }
        
        /// <summary>
        /// Devuelve un string indicando el tipo, color o numero (si corresponde)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string texto="";
            if(this.tipo == ETipo.Numero)
            {
                texto += $"{this.color.ToString()} {this.numero}";
            }
            else
            {
                texto += $"{this.Tipo.ToString()} {this.color.ToString()}";
            }
            return texto;
        }

        /// <summary>
        /// Compara si el obj pasado por parametro es igual a la instancia que llama al metodo
        /// </summary>
        /// <param name="obj">De tipo Object, objeto a saber si es igual al que llama el metodo</param>
        /// <returns>si son iguales retorna true, sino false</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Carta)
            {
                retorno = this == ((Carta)obj);
            }

            return retorno;
        }

        /// <summary>
        /// Retorna el codigo Hash del objeto
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();  
        }
    }
}
