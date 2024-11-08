using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa == false)
            {
                Objetomenupausa.SetActive(false);
                Pausa = true;
            }
        }
    }
}
