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
        public delegate void DelegadoTemporizador(DateTime tiempo);
        public event DelegadoTemporizador TiempoCumplido;

        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private Task hilo;
        private int intervalo;
        private DateTime tiempo;

        public bool EstaActivo { get { return hilo is not null && (hilo.Status == TaskStatus.Running || 
                    hilo.Status == TaskStatus.WaitingToRun || hilo.Status == TaskStatus.WaitingForActivation);}}
        public int Intervalo { get { return this.intervalo; } set { this.intervalo = value; } }
    
        private void CorrerTiempo()
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                this.tiempo = this.tiempo.AddMilliseconds(this.intervalo);
                this.TiempoCumplido.Invoke(this.tiempo);
                Thread.Sleep(this.intervalo);
            }

        }

        public string DetenerCronometro()
        {
            if (this.hilo is not null && !this.hilo.IsCompleted)
            {
                cancellationTokenSource.Cancel();
            }
            return this.tiempo.ToString("HH\\:mm\\:ss");

        }

        public void IniciarCronometro()
        {
            if(this.hilo is null || this.hilo.IsCompleted)
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


        public Cronometro(int intervalo)
        {
            this.intervalo = intervalo;
            this.tiempo = DateTime.Parse($"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} 00:00:00");

        }


    
    }

}
