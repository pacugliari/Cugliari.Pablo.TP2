<p align="center">
<img src="https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/logo.png">
</p>


UNO Pac
=============

Sobre mi
=============
###### Mi nombre es Pablo Cugliari, fue un desafio en cuanto a tiempo ya que resulto un proyecto bastante extenso,divertido trabajar con la parte visual y poder salir de los programas de consola que venimos trabajando en programacion I .

Resumen
=============
###### La aplicacion es un simulador de juegos de mesa centrado en el juego UNO basado en el juevo 1vs1, una vez dentro de la aplicacion nos encontramos  la pantalla de inicio donde podemos jugar nuevas partidas o consultar los datos historicos,tambien tenemos la posibilidad de cancelar el sonido del juego dandole al boton que tiene el simbolo (🔊),dentro del menu podremos hacer:


##### 1. Crear nueva partida
Dandole click en este boton nos pide los nombres de los jugadores,dandole a continuar (▶️) creamos una nueva sala de juego,
ademas tendremos la posibilidad de cancelar y volver al menu inicial (🏠) antes de crear la sala

##### 2. Consultar datos historicos
Dandole click al boton del historico (🔍) nos lleva a una nueva pantalla donde tendremos 2 opciones:


- **Ver logs de partidas :**
Nos permite ver todos los archivos de texto pudiendo consultar su contenido, el cual tiene los logs de las partidas jugadas donde nos indica acciones del
jugador y de la partida.

- **Ver estadisticas de partidas :** Podremos consultar las estadisticas de las partidas y los jugadores donde tendremos fecha, nombre de los jugadores,
ganador , puntos del ganador y la duracion de la partida

Juego vista
=============
<p align="center">
<img src="https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/tablero.png">
</p>

- **1) Indicador jugador actual**<br>
- **2) Tiempo transcurrido de la partida**<br>
- **3) Mutear sonido**<br>
- **4) Color actual de la partida**<br>
- **5) Mazo de cartas (Click para recoger)**<br>
- **6) Cartas ya jugadas**<br>
- **7) Nombre jugador**<br>
- **8) Cartas del jugador**<br>

Consideraciones
=============
El juego tiene la modalidad con las reglas del UNO,con lo cual, el mazo cuenta con 19 cartas azules, 19 cartas verdes, 19 cartas rojas y 19 cartas amarillas. 
También vienen 8 cartas especiales Roba Dos (un 2 antecedido de un signo +, y vienen dos de cada color), 8 cartas especiales Cambio de Sentido (2 de cada color),8 cartas especiales Pierde el Turno o Bloqueo (2 de cada color),4 cartas especiales Comodín Cambio de Color (cada una representa en sí a los cuatro colores) y
4 cartas especiales Comodín Cambio de Color y Roba Cuatro (cada una representa a los cuatro colores y tiene un 4 antecedido del signo +).
Por otro lado, como parte de la consigna eran realizar partidas cortas el juego cuando inicia reparte 3 cartas para cada jugador con un maximo de 7 cartas (es decir el jugador no puede tener mas de 7 cartas en la mano, esto se hizo asi para reducir el tiempo de las partidas), ademas de tirar una carta aleatoria. Si esta carta aleatoria sale un +2, +4, Salteo de turno o cambio de ronda, se ve afectado el primer jugador que inicia que en este caso siempre es el jugador 1.
Como el juego esta hecho para 1vs1, el cambio de ronda y el salteo de turno tiene el mismo efecto, al igual que el +2 y +4 , ademas que le hace sumar 2 o 4 cartas al oponente. El macheo de cartas se hace por numero o por color (este ultimo es indicado durante la partida por un color al lado de las cartas tiradas o por esta ultima).
Por ultimo en el caso que ninguno de los jugadores pueda tirar ninguna carta/levantar una del mazo,etc se podra cancelar la partida con la cruz del cierre de programa (❌) preguntandole al usuario si desea guardar los datos de esa partida


Diagrama de clases
=============
### Enumerados:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/Enumerados.png)

### Archivos:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/Archivos.png)

### Interfaces con clases que las implementan:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/Interfaz.png)

### Excepciones:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/Excepciones.png)

### SQL:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/ClasesSQL.png)

### Clases de logica:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/Logica.png)

### Clases de GUI:
![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/GUI.png)

Justificacion tecnica
=============
### Tema 10 - Excepciones
###### 
Usamos el tema de excepciones para lanzarlas en temas criticos como la apertura,lectura,escritura,etc tanto en archivos de texto como SQL,y ademas de la definicion de 
excepciones propias del programa como:<br>

-**MensajeGanadorException**, es lanzada cuando alguno de los jugadores gano la partida<br>
-**MensajeUnoException**,es lanzada cuando alguno de los jugadores tira una carta y se queda con una sola en la mano<br>
-**JugadorNoEsTurnoException**, es lanzada cuando alguno de los jugadores quiere jugar las cartas que no le corresponde o no es su turno<br>
-**SqlConexionException**,es lanzada cuando no es posible establecer una conexion con la base de datos<br>
-**CreacionCartaException**, es lanzada cuando se trata de crear una carta que no es valida para el juego<br>

### Tema 11 - Pruebas unitarias
###### 
Hay una clase del tipo TestClass por cada Class de la biblioteca Entidades probando todos los metodos y constructores publicos de toda la logica
del programa, probando escenarios donde el codigo podria generar problemas al momento de su ejecucion.

![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/test.png)

### Tema 12 - Tipos genéricos
###### 
Se creo una clase llamada Log el cual posee 1 metodo sobrecargado permitiendo mandar una lista o un solo dato de cualquier tipo,
esta clase la utilizamos al momento de guardar en un archivo de texto datos de la partida

```        
public void AgregarAlLog<T>(List<T> dato)
{
    foreach (T item in dato)
    {
        this.AgregarAlLog(item);
    }

}

public void AgregarAlLog<T>(T dato)
{
    this.texto.AppendLine(dato.ToString());
}
```

### Tema 13 - Interfaces
###### 
Creamos una interface que implementa 2 metodos que son necesarios para el estado del jugador, permitiendo segun el estado jugar y avanzar el turno, esta interface es 
implementado por 2 clases que son JugadorDisponible y JugadorOcupado, dependiendo el estado que tenga el jugador se realizaran distintas acciones, por ejemplo: si el jugador esta ocupado y se trata de jugar se lanzara una excepcion, sino tambien tenemos que al momento de avanzar el turno retorna una instancia nueva con el estado ocupado o disponible segun corresponda en el momento de la partida

```
public interface IEstadoJugador
{
    public void Jugar();
    public IEstadoJugador AvanzarTurno();
}

public class JugadorDisponible : IEstadoJugador
{
    public IEstadoJugador AvanzarTurno()
    {
        return new JugadorOcupado();
    }

    public void Jugar()
    {

    }

}

public class JugadorOcupado : IEstadoJugador
{
    public IEstadoJugador AvanzarTurno()
    {
        return new JugadorDisponible();
    }

    public void Jugar()
    {
        throw new JugadorNoEsTurnoException("No es el turno del jugador seleccionado");

    }
}

```

### Tema 14 - Archivos
###### 
Utilizando la clase Log nombrada anteriormente, utilizamos el tema de Archivos para almacenar todas las acciones importantes ocurridas durante la partida
por el juego o el jugador, durante este manejo de archivos realizamos las siguientes acciones:<br>

- ObtenerArchivos de un directorio<br>
- AgregarAlArchivo un Log<br>
- LeerArchivoHastaElFinal desde un path especifico<br>
- EliminarArchivo segun el path<br>

### Tema 15 - Serialización
###### 
Utilizamos la serializacion para guardar/consultar/eliminar la siguiente clase desde la base de datos SQL,esta clase almacena la informacion de la partida
cuando es finalizada por cancelacion o por que alguno de los jugadores gano, guardando los datos en esta clase luego se realiza la serializacion en formato JSON que
es guardado en la tabla partidas.
```
    public class PartidaSQL
    {
        public int id;
        public string fecha;
        public string jugador1;
        public string jugador2;
        public string ganador;
        public string puntosGanador;
        public string duracion;

        public int Id { get => id; set => id = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Jugador1 { get => jugador1; set => jugador1 = value; }
        public string Jugador2 { get => jugador2; set => jugador2 = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public string PuntosGanador { get => puntosGanador; set => puntosGanador = value; }
        public string Duracion { get => duracion; set => duracion = value; }

        public override string ToString()
        {
            return $"{this.id}-{this.fecha}-{this.jugador1}-{this.jugador2}-{this.ganador}-{this.puntosGanador}-{this.duracion}";
        }
    }
```

### Tema 16 - Introducción a bases de datos y SQL
###### 
Utilizando la clase PartidaSQL nombrada anteriormente, utilizamos el tema de base de datos para almacenar los datos de las partidas finalizadas, las acciones que se realizan hacia la base de datos son las siguientes:<br>

- Probar la conexion, si se pudo conectar o no<br>
- Obtener una lista de todos los datos <br>
- Agregar un dato del tipo PartidaSQL serializado en formato JSON<br>
- Eliminar dato por medio de ID<br>

### Tema 17 - Conexión a bases de datos
###### 
**String de conexion:** Server=localhost;Database=UnoPac;Trusted_Connection=True; <br>
**Estructura de la base de datos** <br>

![](https://github.com/pacugliari/Cugliari.Pablo.TP2/blob/main/Imagenes/sql.png)

### Tema 18 - Delegados y expresiones lambda
### Tema 19 - Programación multi-hilo y concurrencia
### Tema 20 - Eventos
###### 
Utilizamos ambos temas en la creacion de una clase Cronometro, el cual es una clase que lleva el tiempo que una partida se inicio, utilizando delegados y eventos para comunicar la informacion del tiempo desde la parte logica (Entidades) hacia la parte grafica (Forms), y por otro lado para que el tiempo no se detenga o congele
debido al uso del hilo principal del programa se ejecuta en otro aparte

**DECLARACIONES EN LA CLASE Cronometro.cs**
```
public delegate void DelegadoCronometro(DateTime tiempo);
public event DelegadoCronometro TiempoCumplido;
```

**SUSCRIPCION AL EVENTO EN LA CLASE PartidaForm.cs**
```
this.cronometro = new Cronometro(1000);
this.cronometro.TiempoCumplido += this.ActualizarTiempo;
```

**INVOCACION DEL EVENTO EN LA CLASE Cronometro.cs**
```
private void CorrerTiempo()
{

    while (!cancellationToken.IsCancellationRequested)
    {
        this.tiempo = this.tiempo.AddMilliseconds(this.intervalo);
        this.TiempoCumplido.Invoke(this.tiempo);
        Thread.Sleep(this.intervalo);
    }

}
```
**MANEJADOR DE EVENTO EN LA CLASE PartidaForm.cs**
```
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
```

Por otro lado en la parte del los Forms, para poder ejecutar varias partidas al mismo tiempo independientes entre si, se hizo una ejecucion por cada Form de partida nueva en un hilo separado utilizando expresion lambda

```
private void EjecutarNuevaPartida()
{
    object[] nombres = new object[] { this.txtNombreJ1.Text.ToString(), this.txtNombreJ2.Text.ToString() };
    Task.Run(() =>
    {
        PartidaForm partifaForm = new PartidaForm(nombres[0].ToString(), nombres[1].ToString());
        partifaForm.ShowDialog();
    });
}
```

### Tema 21 - Métodos de extensión
###### 
Por ultimo se utilizo los metodos de extension en una clase Extensora.cs en la parte visual, agregando metodos nuevo a los formularios y a los botones,


**AGREGA UNA AYUDA DE TEXTO CUANDO EL USUARIO PASA EL MOUSE SOBRE EL CONTROL DE UN FORM**
```
public static void MostrarAyuda(this Form formulario, Control control, string mensaje)
{
    ToolTip yourToolTip = new ToolTip();
    //yourToolTip.ToolTipIcon = ToolTipIcon.Info;
    //yourToolTip.IsBalloon = true;
    yourToolTip.ShowAlways = true;
    yourToolTip.SetToolTip(control, mensaje);
}
```

**REPRODUCE UN SONIDO AL HACER CLICK EN UN BOTON DEPENDIENDO SI ESTA HABILIDADO O NO EL SONIDO**
```
public static void ReproducirRuido (this Button boton,bool quitarSonido)
{
    if(!quitarSonido)
        sonidoUno.Play();
}
```
