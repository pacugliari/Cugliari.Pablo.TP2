using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cronometro
    {
        public delegate void DelegadoCronometro(DateTime tiempo);
        public event DelegadoCronometro TiempoCumplido;

        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private Task hilo;
        private int intervalo;
        private DateTime tiempo;

        /// <summary>
        /// Propiedad de tipo get que retorna si el hilo esta siendo usado
        /// </summary>
        public bool EstaActivo { get { return hilo is not null && (hilo.Status == TaskStatus.Running || 
                    hilo.Status == TaskStatus.WaitingToRun || hilo.Status == TaskStatus.WaitingForActivation);}}

        /// <summary>
        /// Propiedad del tipo get and set que permite obtener/consultar el valor del intervalo en miliseg
        /// </summary>
        public int Intervalo { get { return this.intervalo; } set { this.intervalo = value; } }


        /// <summary>
        /// Crea una instancia del tipo Cronometro con el intervalo en miliseg pasado por parametro
        /// </summary>
        /// <param name="intervalo"></param>
        public Cronometro(int intervalo)
        {
            this.intervalo = intervalo;
            this.tiempo = DateTime.Parse($"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} 00:00:00");

        }

        /// <summary>
        /// Inicia el cronometro, si el hilo se completo o no se creo, hace esto ultimo y si
        /// no esta activo lo inicia empezando a contar el tiempo
        /// </summary>
        public void IniciarCronometro()
        {
            if (this.hilo is null || this.hilo.IsCompleted)
            {
                this.cancellationTokenSource = new CancellationTokenSource();
                this.cancellationToken = this.cancellationTokenSource.Token;
                this.hilo = Task.Run(this.CorrerTiempo, this.cancellationToken);
            }

            if (!this.EstaActivo)
            {
                this.hilo.Start();
            }

        }

        /// <summary>
        /// Agrega el valor del intervalo al tiempo previo, disparando el evento TiempoCumplido
        /// </summary>
        private void CorrerTiempo()
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                this.tiempo = this.tiempo.AddMilliseconds(this.intervalo);
                this.TiempoCumplido.Invoke(this.tiempo);
                Thread.Sleep(this.intervalo);
            }

        }

        /// <summary>
        /// Detiene el cronometro,deteniendo el conteo del tiempo
        /// </summary>
        /// <returns>Retorna un string del tiempo transcurrido desde que se inicio con el formato HH\\:mm\\:ss </returns>
        public string DetenerCronometro()
        {
            if (this.hilo is not null && !this.hilo.IsCompleted)
            {
                cancellationTokenSource.Cancel();
            }
            return this.tiempo.ToString("HH\\:mm\\:ss");

        }
    
    }

}
