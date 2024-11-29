using UnityEngine;

public class Envidia : MonoBehaviour
{
    public Vector3 puntoInicial = new Vector3(5, 9, 0); // Posici�n inicial
    public Vector3 puntoFinal = new Vector3(5, 0, 0); // Punto donde comienza el temporizador y los ataques
    public float velocidadMovimiento = 3f; // Velocidad de movimiento

    public GameObject proyectilPrefab; // Prefab del proyectil
    public float tiempoEntreAtaques = 2f; // Tiempo entre ataques del ca��n
    public float velocidadProyectil = 3f; // Velocidad del proyectil
    public float limiteSuperior = 4f; // L�mite superior del movimiento del ca��n
    public float limiteInferior = -4f; // L�mite inferior del movimiento del ca��n

    public Vector3 nuevaPosicion = new Vector3(7, -7, 0); // Nueva posici�n al finalizar el temporizador

    private bool haLlegado = false; // Indica si ha llegado al punto final
    private Temporizador temporizador; // Referencia al temporizador
    private bool moviendoHaciaArriba = true; // Controla la direcci�n del movimiento del ca��n
    private float contadorTiempo = 0f; // Contador para el tiempo entre ataques

    void Start()
    {
        transform.position = puntoInicial;
        temporizador = FindObjectOfType<Temporizador>();
    }

    void Update()
    {
        if (!haLlegado)
        {
            // Mueve el objeto hacia el punto final
            MoverHaciaPunto(puntoFinal);
            if (transform.position == puntoFinal)
            {
                haLlegado = true;

                // Inicia el temporizador al llegar al punto final
                if (temporizador != null)
                {
                    temporizador.IniciarTemporizador();
                }
            }
        }
        else if (temporizador != null && temporizador.TemporizadorActivo())
        {
            LanzarAtaque(); // Ataca mientras el temporizador est� activo
            MoverCanon();   // Mueve el ca��n mientras el temporizador est� activo
        }
        else if (temporizador != null && !temporizador.TemporizadorActivo())
        {
            MoverHaciaPunto(nuevaPosicion); // Mueve a la nueva posici�n cuando el temporizador termina
        }
    }

    void MoverHaciaPunto(Vector3 destino)
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);
    }

    void LanzarAtaque()
    {
        contadorTiempo += Time.deltaTime;

        if (contadorTiempo >= tiempoEntreAtaques)
        {
            if (proyectilPrefab != null)
            {
                GameObject proyectil = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
                Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = new Vector2(-velocidadProyectil, 0);
                }
                else
                {
                    Debug.LogError("El proyectil no tiene un componente Rigidbody2D.");
                }
                contadorTiempo = 0f;
            }
            else
            {
                Debug.LogError("El prefab del proyectil no est� asignado en el Canon.");
            }
        }
    }

    void MoverCanon()
    {
        if (moviendoHaciaArriba)
        {
            transform.Translate(Vector2.up * velocidadMovimiento * Time.deltaTime);
            if (transform.position.y >= limiteSuperior)
            {
                moviendoHaciaArriba = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * velocidadMovimiento * Time.deltaTime);
            if (transform.position.y <= limiteInferior)
            {
                moviendoHaciaArriba = true;
            }
        }
    }
}

