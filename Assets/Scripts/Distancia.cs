using UnityEngine;
using TMPro;

public class MedidorDistancia : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad constante en unidades de distancia por segundo
    public TMP_Text textoDistancia; // Texto para mostrar la distancia

    private float distanciaRecorrida = 0f;
    private bool medidorActivo = false; // Indica si el medidor está activo

    void Start()
    {
        distanciaRecorrida = 0f; // Inicializa la distancia
        textoDistancia.text = "Distancia: " + distanciaRecorrida.ToString("F2") + " m"; // Muestra la distancia inicial
    }

    void Update()
    {
        if (medidorActivo)
        {
            // Aumenta la distancia en función de la velocidad y el tiempo transcurrido desde el último frame
            distanciaRecorrida += velocidad * Time.deltaTime;

            // Actualiza el texto en la UI
            textoDistancia.text = "Distancia: " + distanciaRecorrida.ToString("F2") + " m"; // Muestra la distancia con dos decimales
        }
    }

    public void IniciarMedidor() // Método para iniciar el medidor
    {
        medidorActivo = true; // Activa el medidor
        distanciaRecorrida = 0f; // Reinicia la distancia cuando se inicia
    }

    public bool MedidorActivo() // Método para verificar si el medidor está activo
    {
        return medidorActivo;
    }
}
