IMAGEN LOGO

Proyecto UNO Pac
=============

Sobre mi
=============
###### Mi nombre es Pablo Cugliari, fue un desafio en cuanto a tiempo ya que resulto un proyecto bastante extenso,divertido trabajar con la parte visual y poder salir de los programas de consola que venimos trabajando en programacion I .

Resumen
=============
###### La aplicacion es un simulador de juegos de mesa centrado en el juego UNO basado en el juevo 1vs1, una vez dentro de la aplicacion nos encontramos  la pantalla de inicio donde podemos jugar nuevas partidas o consultar los datos historicos,dentro del menu podremos hacer


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


Diagrama de clases
=============
### Enumerados:
![](https://githb.com/pacugliari/Cugliari.Pablo.P1.LabII.2A/blob/main/diagramas/enumerados.png)

### Clases de logica:
![](https://githb.com/pacugliari/Cugliari.Pablo.P1.LabII.2A/blob/main/diagramas/diagramaClases.png)

### Clases de GUI:
![](https://githu.com/pacugliari/Cugliari.Pablo.P1.LabII.2A/blob/main/diagramas/diagramaClasesGUI.png)

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

IMAGEN TEST

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

### Tema 16 - Introducción a bases de datos y SQL
###### 

### Tema 17 - Conexión a bases de datos
###### 

### Tema 18 - Delegados y expresiones lambda
###### 

### Tema 19 - Programación multi-hilo y concurrencia
###### 

### Tema 20 - Eventos
###### 

### Tema 21 - Métodos de extensión
###### 



