using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoVida = 4f;  // Tiempo antes de que el proyectil se destruya

    void Start()
    {
        // Destruir el proyectil despu�s de un tiempo
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar colisiones
        if (other.CompareTag("Player")) // Cambia "Player" por la etiqueta de tu personaje
        {
            // Aqu� puedes agregar l�gica para da�ar al jugador
            Debug.Log("�Impacto en el jugador!");
            Destroy(gameObject); // Destruir el proyectil al impactar
        }
    }
}

