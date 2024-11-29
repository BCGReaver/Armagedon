using UnityEngine;

public class Querubin : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public float tiempoEntreAtaques = 4f;
    public float velocidadProyectil = 5f;
    public float velocidadMovimiento = 2f;
    public float limiteSuperior = 4f;
    public float limiteInferior = -4f;

    private float contadorTiempo = 0f;
    private bool moviendoHaciaArriba = true;
    private bool atacando = false;  // Indica si Querubín está atacando

    private Temporizador temporizador;
    private bool detenerMovimiento = false;

    void Start()
    {
        temporizador = FindObjectOfType<Temporizador>();
    }

    void Update()
    {
        if (temporizador != null && temporizador.TemporizadorActivo())
        {
            LanzarAtaque();
            MoverCanon();
        } 
        else if (temporizador == null)
        {
            DetenerAtaque();
            DetenerMovimiento();
            
        }
    }

    public void IniciarAtaque()
    {
        atacando = true;  // Habilita el ataque
        contadorTiempo = 0f;  // Reinicia el contador
    }

    public void DetenerAtaque()
    {
        atacando = false;  // Deshabilita el ataque
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
        // Movimiento hacia arriba o hacia abajo
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

    public void DetenerMovimiento()
    {
        detenerMovimiento = true;
    }
}