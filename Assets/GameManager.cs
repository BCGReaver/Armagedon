using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PauseGO;
    private bool isPaused = false; // Estado de pausa

    // M�todo para mostrar y ocultar el men� de pausa
    public void TogglePause()
    {
        isPaused = !isPaused; // Alternar el estado de pausa

        if (isPaused)
        {
            PauseGO.SetActive(true); // Mostrar el men� de pausa
            Time.timeScale = 0f; // Detener el tiempo
        }
        else
        {
            PauseGO.SetActive(false); // Ocultar el men� de pausa
            Time.timeScale = 1f; // Reanudar el tiempo
        }
    }

    // Opcional: Detectar entrada para pausar/reanudar
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Puedes cambiar la tecla si lo prefieres
        {
            TogglePause();
        }
    }
}
