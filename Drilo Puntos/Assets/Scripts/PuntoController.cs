using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoController : MonoBehaviour
{
    public bool marcado;
    private void Start()
    {
        marcado = false;
    }
    private void OnMouseEnter()
    {
        if(marcado == false)
        {
            marcado = true;

            if (FindObjectOfType<GameController>().marcado1 == false)
            {
                FindObjectOfType<GameController>().marcado1 = true;
                FindObjectOfType<GameController>().ComprobarPrimero();
            }
            else if (FindObjectOfType<GameController>().marcado1 == true)
            {
                FindObjectOfType<GameController>().marcado2 = true;
                FindObjectOfType<GameController>().Comprobar();
            }
        }
        if(marcado == true)
        {
            return;
        }
    }
}
