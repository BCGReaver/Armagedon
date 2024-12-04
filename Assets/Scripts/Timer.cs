using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this) {
            Destroy(gameObject);
        }
    }

    public void Wait(float seconds, Action accion)
    {
        StartCoroutine(AwaitCoroutine(seconds, accion));
        
    }

   private IEnumerator AwaitCoroutine(float seconds, Action accion)
   {
        yield return new WaitForSeconds(seconds);
        accion.Invoke();
        Debug.Log("se acabo el time");
   }
}
