/*using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcangelHealt : MonoBehaviour
{
    public event EventHandler MuerteJugador; // Evento para Game Over

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("proyectil"))
        {
            // Eliminar el proyectil (opcional)
            Destroy(collision.gameObject);

            // Llamar al evento de muerte
            MuerteJugador?.Invoke(this, EventArgs.Empty);

            Debug.Log("Impacto detectado. Game Over.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Proyectil"))  // Si el objeto que golpea es un proyectil
        {
            Debug.Log("Personaje golpeado, cambiando a la pantalla de Game Over.");
            TerminarJuego();  // Llamar la función para cambiar de escena
        }
    }

    // Método para cambiar a la escena de Game Over
    void TerminarJuego()
    {
        SceneManager.LoadScene("GameOver");  // Carga la escena de Game Over
    }
}*/
