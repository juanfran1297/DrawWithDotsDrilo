using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> puntos;

    public bool marcado1;
    public bool marcado2;

    //Esto es para hacer pruebas
    public Text textoDePrueba;

    public void Comprobar()
    {
        if(puntos[0].GetComponent<PuntoController>().marcado == true && puntos[1].GetComponent<PuntoController>().marcado == true)
        {
            Debug.Log("Orden correcto, ¡A dibujar!");
            textoDePrueba.text = "Orden correcto, ¡A dibujar!";
            puntos[0].GetComponent<PuntoController>().enabled = false;
            //Prueba visual de que funciona
            puntos[0].GetComponent<SpriteRenderer>().color = Color.red;
            ///////////////////////////////////////////////////////////
            puntos[1].GetComponent<PuntoController>().enabled = false;
            //Prueba visual de que funciona
            puntos[1].GetComponent<SpriteRenderer>().color = Color.red;
            ///////////////////////////////////////////////////////////
            puntos.Remove(puntos[0]);
            puntos.Remove(puntos[0]);
            Reiniciar();
        }
        else
        {
            Debug.Log("No está en el orden correcto");
            textoDePrueba.text = "No está en el orden correcto";
            Reiniciar();
        }
    }

    public void ComprobarPrimero()
    {
        if(marcado1 == true && marcado2 == false)
        {
            if(puntos[0].GetComponent<PuntoController>().marcado == false)
            {
                Debug.Log("No se ha cogido el primero correctamente");
                textoDePrueba.text = "No se ha cogido el primero correctamente";
                Reiniciar();
            }
        }
    }

    private void Reiniciar()
    {
        for(int i = 0; i < puntos.Count; i++)
        {
            puntos[i].GetComponent<PuntoController>().marcado = false;
            marcado1 = false;
            marcado2 = false;
        }
    }
}
