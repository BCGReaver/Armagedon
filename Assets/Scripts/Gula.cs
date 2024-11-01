using UnityEngine;

public class Gula : MonoBehaviour
{
    public Vector3 puntoInicial = new Vector3(5, 9, 0);        // Posición inicial
    public Vector3 puntoCambioTamano = new Vector3(5, -9, 0);  // Punto donde cambiará de tamaño
    public Vector3 puntoFinal = new Vector3(5, 0, 0);          // Punto final
    public float velocidadMovimiento = 3f;                     // Velocidad de movimiento
    public Vector3 escalaReducida = new Vector3(0.5f, 0.5f, 0.5f); // Nueva escala al cambiar de tamaño
    public Vector3 nuevaPosicion = new Vector3(12, 0, 0);     // Nueva posición a la que se moverá al finalizar el temporizador

    private bool haReducidoTamaño = false; // Indica si se ha reducido el tamaño
    private bool haAlcanzadoFinal = false; // Indica si se ha llegado al punto final
    private Temporizador temporizador; // Referencia al temporizador

    void Start()
    {
        // Coloca el objeto en el punto inicial
        transform.position = puntoInicial;
        // Encuentra el temporizador en la escena
        temporizador = FindObjectOfType<Temporizador>();
    }

    void Update()
    {
        if (!haReducidoTamaño)
        {
            // Mueve hacia el punto de cambio de tamaño
            transform.position = Vector3.MoveTowards(transform.position, puntoCambioTamano, velocidadMovimiento * Time.deltaTime);

            if (transform.position == puntoCambioTamano)
            {
                // Cambia de tamaño
                transform.localScale = escalaReducida;
                haReducidoTamaño = true; // Marca que el tamaño ha sido reducido
            }
        }
        else if (!haAlcanzadoFinal)
        {
            // Mueve hacia el punto final (5, 0) después de reducir el tamaño
            transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidadMovimiento * Time.deltaTime);

            if (transform.position == puntoFinal)
            {
                haAlcanzadoFinal = true; // Marca que se ha llegado al punto final
                // Inicia el temporizador
                if (temporizador != null)
                {
                    temporizador.IniciarTemporizador(); // Llama al método para iniciar el temporizador
                }
            }
        }
        else if (temporizador != null && !temporizador.TemporizadorActivo())
        {
            // Mueve Gula a la nueva posición (12, 0, 0) cuando el temporizador ha finalizado
            transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velocidadMovimiento * Time.deltaTime);
        }
    }
}
