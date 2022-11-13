using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mazo
    {
        private List<Carta> cartas;

        /*
         El mazo del UNO está compuesto de cuatro colores: azul, verde, rojo y amarillo. 
        Las cartas comunes van del 1 al 9 y cada color tiene repetido 2 veces cada número, menos el cero que viene una sola vez en cada color.

        Con lo cual, el mazo cuenta con 19 cartas azules, 19 cartas verdes, 19 cartas rojas y 19 cartas amarillas. 
        También vienen 8 cartas especiales Roba Dos (un 2 antecedido de un signo +, y vienen dos de cada color); 
        8 cartas especiales Cambio de Sentido (2 de cada color); 
        8 cartas especiales Pierde el Turno o Bloqueo (2 de cada color);
        4 cartas especiales Comodín Cambio de Color (cada una representa en sí a los cuatro colores); y
        4 cartas especiales Comodín Cambio de Color y Roba Cuatro (cada una representa a los cuatro colores y tiene un 4 antecedido del signo +).
        
        19+19+19+19+8+8+8+4+4 = 108
         
         */

        /// <summary>
        /// Propiedad del tipo get con la cantidad de cartas del mazo
        /// </summary>
        public int CantidadCartas { get { return this.cartas.Count; } }

        /// <summary>
        /// Crea una instancia del tipo Mazo cargando todas las cartas mezcladas del uno en la lista
        /// </summary>
        public Mazo()
        {
            this.cartas = new List<Carta>();

            //GENERO CARTAS DE COLOR
            foreach (EColor item in Enum.GetValues(typeof(EColor)))
            {
                if(item != EColor.Negro)
                {
                    for (int i = 0; i <= 9; i++)
                    {
                        this.cartas.Add(new Carta(ETipo.Numero, item, i));
                        if (i != 0)
                            this.cartas.Add(new Carta(ETipo.Numero, item, i));
                    }
                    this.cartas.Add(new Carta(ETipo.MasDos, item));
                    this.cartas.Add(new Carta(ETipo.MasDos, item));
                    this.cartas.Add(new Carta(ETipo.Invertir, item));
                    this.cartas.Add(new Carta(ETipo.Invertir, item));
                    this.cartas.Add(new Carta(ETipo.Salteo, item));
                    this.cartas.Add(new Carta(ETipo.Salteo, item));
                }
            }

            //GENERO CARTAS ESPECIALES
            for (int i = 0; i < 4; i++)
            {
                this.cartas.Add(new Carta(ETipo.MasCuatro, EColor.Negro));
                this.cartas.Add(new Carta(ETipo.CambioColor, EColor.Negro));
            }


            this.MezclarMazo();
        }

        /// <summary>
        /// Mezcla aleatoriamente todas las cartas de la lista
        /// </summary>
        private void MezclarMazo()
        {
            //MEZCLO CARTAS
            Random rand = new Random();
            this.cartas = this.cartas.OrderBy(_ => rand.Next()).ToList();
        }

        /// <summary>
        /// Retira del mazo una cantidad de cartas segun el parametro cantidad, si el mazo no tiene suficientes cartas
        /// mezcla las cartas tiradas en la Partida generando un nuevo mazo para consumir
        /// </summary>
        /// <param name="partida">Partida, contiene las cartas tiradas para volver a cargar el mazo</param>
        /// <param name="cantidad">int, contiene la cantidad de cartas a retirar del mazo</param>
        /// <returns>List<Carta> lista de cartas retiradas del mazo</returns>
        public List<Carta> ObtenerCartas (Partida partida,int cantidad)
        {
            List<Carta> cartasObtenidas = null;

            if(this.cartas.Count < cantidad)
            {
                this.MezclarCartasTiradas(partida);
            }
            
            if(cantidad <= this.cartas.Count)
            {
                cartasObtenidas = new List<Carta>();

                for (int i = 0; i < cantidad; i++)
                {
                    cartasObtenidas.Add(this.cartas[i]);
                    
                }

                foreach (var item in cartasObtenidas)
                {
                    this.cartas.Remove(item);
                }

            }


            return cartasObtenidas;
        }

        /// <summary>
        /// Carga las cartas tiradas de la partida nuevamente al mazo mezclandolas
        /// </summary>
        /// <param name="partida">Partida, posee la lista de cartas tiradas </param>
        private void MezclarCartasTiradas(Partida partida)
        {
            Stack<Carta> cartasTiradas = partida.CartasTiradas;
            Carta aux = partida.UltimaCartaTirada;

            while(cartasTiradas.Count != 0)
            {
                this.cartas.Add(cartasTiradas.Pop());
            }
            partida.AgregarCartaTirada = this.cartas[this.cartas.IndexOf(aux)];
            this.cartas.Remove(aux);
            this.MezclarMazo();
        }

    }
}
