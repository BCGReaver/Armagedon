using UnityEngine;

public class Lujuria : MonoBehaviour
{
    // Variables 
    public Vector3 puntoInicial = new Vector3(15, 0, 0); // Posici�n inicial
    public Vector3 puntoFinal = new Vector3(7, 0, 0); // Punto donde comienza el temporizador y los ataques
    public float velocidadMovimiento = 10f; // Velocidad de movimiento
    public Vector3 nuevaPosicion = new Vector3(15, 0, 0); // Nueva posici�n al finalizar el temporizador

    public float floatingSpeed = 1.5f;
    public float minHeight = .5f;
    public float maxHeight = 3f;
    public float moveSpeed = -7f; // Velocidad de movimiento hacia la izquierda
    public float targetXPosition = -7f; // Posici�n objetivo en el eje X

    private bool movingUp = true; // Direcci�n actual (subiendo o bajando)
    private Rigidbody2D rb;
    private bool hasReachedTarget = false; // Indica si alcanz� la posici�n objetivo en X
    
    private bool hasArrived = false; // Indica si ha llegado al punto final
    private Temporizador temporizador; // Referencia al temporizador
    //private bool moviendoHaciaArriba = true; // Controla la direcci�n del movimiento del ca��n
    private float contadorTiempo = 0f; // Contador para el tiempo entre ataques


    void Start()
    {
        transform.position = puntoInicial;
        temporizador = FindObjectOfType<Temporizador>();

        // Rigidbody2D del enemigo
        rb = GetComponent<Rigidbody2D>();

        // Desactivar la gravedad para que el enemigo flote
        rb.gravityScale = 0f;
    }

    void Update()
    {
        // Mover hacia la izquierda hasta alcanzar la posici�n objetivo
        if (!hasArrived)
        {
            MoverHaciaPunto(puntoFinal);
            if(transform.position == puntoFinal)
            {
                hasArrived=true;

                if (temporizador != null)
                {
                    temporizador.IniciarTemporizador();
                }
            }

            /* Verificar si alcanz� o pas� la posici�n objetivo en X
            if (transform.position.x <= targetXPosition)
            {
                hasReachedTarget = true;
                rb.velocity = new Vector2(0, rb.velocity.y); // Detener el movimiento horizontal
            }*/
        }

        // Verificar si el enemigo est� subiendo o bajando
        else if (temporizador != null && temporizador.TemporizadorActivo())
        {
            MoverLujuria();
            //vacio

            /* Si est� subiendo, agregar una velocidad positiva hacia arriba
            rb.velocity = new Vector2(rb.velocity.x, floatingSpeed);

            // Si alcanza la altura m�xima, cambiar direcci�n
            if (transform.position.y >= maxHeight)
            {
                movingUp = false;
            }*/
        }
        else if (temporizador !=null && !temporizador.TemporizadorActivo()) 
        {
            MoverHaciaPunto(nuevaPosicion);

            /* Si est� bajando, agregar una velocidad negativa hacia abajo
            rb.velocity = new Vector2(rb.velocity.x, -floatingSpeed);

            // Si alcanza la altura m�nima, cambiar direcci�n
            if (transform.position.y <= minHeight)
            {
                movingUp = true;
            }*/
        }
    }
    void MoverHaciaPunto(Vector3 destino)
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);
    }

    void MoverLujuria()
    {
        if (movingUp)
        {
            // Si est� subiendo, agregar una velocidad positiva hacia arriba
            rb.velocity = new Vector2(rb.velocity.x, floatingSpeed);

            // Si alcanza la altura m�xima, cambiar direcci�n
            if (transform.position.y >= maxHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            // Si est� bajando, agregar una velocidad negativa hacia abajo
            rb.velocity = new Vector2(rb.velocity.x, -floatingSpeed);

            // Si alcanza la altura m�nima, cambiar direcci�n
            if (transform.position.y <= minHeight)
            {
                movingUp = true;
            }
        }
    }
}