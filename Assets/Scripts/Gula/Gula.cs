using UnityEngine;

public class Gula : MonoBehaviour
{
    public Vector3 puntoInicial = new Vector3(5, 9, 0); // Posición inicial
    public Vector3 puntoCambioTamano = new Vector3(5, -9, 0); // Punto donde cambiará de tamaño
    public Vector3 puntoFinal = new Vector3(5, 0, 0); // Punto final
    public float velocidadMovimiento = 3f; // Velocidad de movimiento
    public Vector3 escalaReducida = new Vector3(0.5f, 0.5f, 0.5f); // Nueva escala al cambiar de tamaño
    public Vector3 nuevaPosicion = new Vector3(12, 0, 0); // Nueva posición al finalizar el temporizador

    public GameObject proyectilPrefab; // Prefab del proyectil
    public float tiempoEntreAtaques = 2f; // Tiempo entre ataques del cañón
    public float velocidadProyectil = 3f; // Velocidad del proyectil
    public float limiteSuperior = 4f; // Límite superior del movimiento del cañón
    public float limiteInferior = -4f; // Límite inferior del movimiento del cañón

    private bool haReducidoTamaño = false; // Indica si se ha reducido el tamaño
    private bool haAlcanzadoFinal = false; // Indica si se ha llegado al punto final
    private Temporizador temporizador; // Referencia al temporizador
    private bool moviendoHaciaArriba = true; // Controla la dirección del movimiento del cañón
    private float contadorTiempo = 0f; // Contador para el tiempo entre ataques

    void Start()
    {
        transform.position = puntoInicial;
        temporizador = FindObjectOfType<Temporizador>();
    }

    void Update()
    {
        if (!haReducidoTamaño)
        {

            MoverHaciaPunto(puntoCambioTamano);
            if (transform.position == puntoCambioTamano)
            {
                transform.localScale = escalaReducida;
                haReducidoTamaño = true;
            }
        }
        else if (!haAlcanzadoFinal)
        {
            MoverHaciaPunto(puntoFinal);
            if (transform.position == puntoFinal)
            {
                haAlcanzadoFinal = true;
                if (temporizador != null)
                {
                    temporizador.IniciarTemporizador();
                }
            }
        }
        else if (temporizador != null && temporizador.TemporizadorActivo())
        {
            LanzarAtaque(); // Ataca mientras el temporizador esté activo
            MoverCanon(); // Mueve el cañón mientras el temporizador esté activo
        }
        else if (temporizador != null && !temporizador.TemporizadorActivo())
        {
            MoverHaciaPunto(nuevaPosicion); // Mueve a la nueva posición cuando el temporizador termina
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
                Debug.LogError("El prefab del proyectil no está asignado en el Canon.");
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
