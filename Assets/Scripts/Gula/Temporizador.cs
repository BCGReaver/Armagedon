using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.SceneManagement; // Importa esta l�nea para usar TextMeshPro

public class NewTimer : MonoBehaviour
{
    public static IEnumerator AwaitCoroutine(float seconds, System.Action onFinish = null)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("se acabo el time");
        if (onFinish != null)
        {
            onFinish();
        }
    }
}
public class Temporizador : MonoBehaviour
{
    public float tiempoLimite = 60f; // Tiempo l�mite en segundos
    public TMP_Text textoTemporizador; // Cambia a TMP_Text para TextMeshPro
    public string escenaSiguiente;

    private float tiempoRestante;
    private bool temporizadorActivo = false; // Indica si el temporizador est� activo

    void Start()
    {
        tiempoRestante = tiempoLimite; // Inicializa el tiempo restante
        textoTemporizador.text = "Tiempo: " + tiempoRestante.ToString("F2") + " s"; // Muestra el tiempo inicial
    }

    void Update()
    {
        if (temporizadorActivo)
        {
            // Resta el tiempo transcurrido
            tiempoRestante -= Time.deltaTime;

            // Aseg�rate de que el tiempo no sea menor que 0
            if (tiempoRestante < 0)
            {
                tiempoRestante = 0;
                temporizadorActivo = false; // Desactiva el temporizador
                // Aqu� puedes agregar l�gica que quieras que suceda cuando se acabe el tiempo

                StartCoroutine(NewTimer.AwaitCoroutine(5.0f, () => SiguienteEscena(escenaSiguiente)));
            }

            // Actualiza el texto en la UI
            textoTemporizador.text = "Tiempo: " + tiempoRestante.ToString("F2") + " s"; // Muestra el tiempo con dos decimales
        }
    }

    public void IniciarTemporizador() // M�todo para iniciar el temporizador
    {
        temporizadorActivo = true; // Activa el temporizador
    }

    public bool TemporizadorActivo() // M�todo para verificar si el temporizador est� activo
    {

        return temporizadorActivo;
    }
    public void SiguienteEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
