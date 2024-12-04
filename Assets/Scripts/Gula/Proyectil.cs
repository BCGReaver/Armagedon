using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float tiempoVida = 4f;  // Tiempo antes de que el proyectil se destruya

    void Start()
    {
        // Destruir el proyectil después de un tiempo
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar colisiones
        if (other.CompareTag("Arcangel")) 
        {
            // Aquí puedes agregar lógica para dañar al jugador
            Debug.Log("Game Over ");

         

            Destroy(gameObject); // Destruir el proyectil al impactar
        }
    }
}

