using System;
using UnityEngine;

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
}
