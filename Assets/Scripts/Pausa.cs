using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool estaEnPausa = false;  // Variable para controlar el estado de pausa

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaEnPausa == false)
            {
                ObjetoMenuPausa.SetActive(true);  // Muestra el menú de pausa
                estaEnPausa = true;
                Time.timeScale = 0f;  // Pausa el juego
            }
            else
            {
                ObjetoMenuPausa.SetActive(false);  // Oculta el menú de pausa
                estaEnPausa = false;
                Time.timeScale = 1f;  // Reanuda el juego
            }
        }
    }
}
