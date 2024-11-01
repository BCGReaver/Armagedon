using UnityEngine;

public class Gula : MonoBehaviour
{
    public Vector3 puntoInicial = new Vector3(5, 9, 0);        // Posici�n inicial
    public Vector3 puntoCambioTamano = new Vector3(5, -9, 0);  // Punto donde cambiar� de tama�o
    public Vector3 puntoFinal = new Vector3(5, 0, 0);          // Punto final
    public float velocidadMovimiento = 3f;                     // Velocidad de movimiento
    public Vector3 escalaReducida = new Vector3(0.5f, 0.5f, 0.5f); // Nueva escala al cambiar de tama�o
    public Vector3 nuevaPosicion = new Vector3(12, 0, 0);     // Nueva posici�n a la que se mover� al finalizar el temporizador

    private bool haReducidoTama�o = false; // Indica si se ha reducido el tama�o
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
        if (!haReducidoTama�o)
        {
            // Mueve hacia el punto de cambio de tama�o
            transform.position = Vector3.MoveTowards(transform.position, puntoCambioTamano, velocidadMovimiento * Time.deltaTime);

            if (transform.position == puntoCambioTamano)
            {
                // Cambia de tama�o
                transform.localScale = escalaReducida;
                haReducidoTama�o = true; // Marca que el tama�o ha sido reducido
            }
        }
        else if (!haAlcanzadoFinal)
        {
            // Mueve hacia el punto final (5, 0) despu�s de reducir el tama�o
            transform.position = Vector3.MoveTowards(transform.position, puntoFinal, velocidadMovimiento * Time.deltaTime);

            if (transform.position == puntoFinal)
            {
                haAlcanzadoFinal = true; // Marca que se ha llegado al punto final
                // Inicia el temporizador
                if (temporizador != null)
                {
                    temporizador.IniciarTemporizador(); // Llama al m�todo para iniciar el temporizador
                }
            }
        }
        else if (temporizador != null && !temporizador.TemporizadorActivo())
        {
            // Mueve Gula a la nueva posici�n (12, 0, 0) cuando el temporizador ha finalizado
            transform.position = Vector3.MoveTowards(transform.position, nuevaPosicion, velocidadMovimiento * Time.deltaTime);
        }
    }
}
