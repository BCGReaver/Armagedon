using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using System;
using UnityEngine.UIElements;

public class Dialogo : MonoBehaviour
{
    public string dialogo;
    public TMP_Text tmp_text;
    public bool finTexto = false;

    // Start is called before the first frame update
    void Start()
    {
        tmp_text.text = dialogo;
        StartCoroutine(TypeLine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Skip();
        }
    }

    IEnumerator TypeLine()
    {
        tmp_text.text = string.Empty;

        //StartCoroutine(waitForDialogue(time));
        foreach (char c in dialogo.ToCharArray())
        {
            tmp_text.text += c;
            yield return new WaitForSeconds(.1f);
        }
        finTexto = true;
    }

    //Metodo siempre va con Mayuscula la primera y parentesis con sus llaves
    void Skip()
    {
        if (tmp_text.text == dialogo)
        {
            if (finTexto)
            {

            }
        }
        else
        {
            StopAllCoroutines();
            tmp_text.text = dialogo;
        }
    }
}
