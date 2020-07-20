using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameController : MonoBehaviour
{
    public List<GameObject> puntos;
    public List<Image> imagenes;

    public bool marcado1;
    public bool marcado2;

    //Esto es para hacer pruebas
    public Text textoDePrueba;

    public GameObject imagenPuntos;
    public GameObject imagenFinal;
    public GameObject partes;


    private void Start()
    {
        imagenPuntos.SetActive(true);
        partes.SetActive(true);
        imagenFinal.SetActive(false);
        for(int i = 0; i < imagenes.Count; i++)
        {
            imagenes[i].enabled = false;
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
                FindObjectOfType<AudioManager>().Play("Fallo");
                Reiniciar();
                marcado1 = false;
            }
            else if(puntos[0].GetComponent<PuntoController>().marcado == true)
            {
                Debug.Log("Orden correcto, ¡Continua!");
                textoDePrueba.text = "Orden correcto, ¡Continua!";
                FindObjectOfType<AudioManager>().Play("Acierto");
                puntos[0].GetComponent<PuntoController>().enabled = false;
                //Prueba visual de que funciona
                puntos[0].GetComponent<Image>().color = Color.red;
                puntos.Remove(puntos[0]);
            }
        }
    }

    public void Comprobar()
    {
        if(marcado1 == true && marcado2 == true)
        {
            if(puntos[0].GetComponent<PuntoController>().marcado == false)
            {
                Debug.Log("No se ha cogido el segundo correctamente");
                textoDePrueba.text = "No se ha cogido el segundo correctamente";
                FindObjectOfType<AudioManager>().Play("Fallo");
                marcado2 = false;
            }
            else if (puntos[0].GetComponent<PuntoController>().marcado == true)
            {
                Debug.Log("Orden correcto, ¡A dibujar!");
                textoDePrueba.text = "Orden correcto, ¡A dibujar!";
                FindObjectOfType<AudioManager>().Play("Acierto");
                Debug.Log("Sale la imagen");
                puntos[0].GetComponent<PuntoController>().enabled = false;
                //Prueba visual de que funciona
                puntos[0].GetComponent<Image>().color = Color.red;
                imagenes[0].enabled = true;
                imagenes.Remove(imagenes[0]);
                puntos.Remove(puntos[0]);
                ComprobarFinal();

                Reiniciar();
                marcado2 = false;
            }
        }
    }

    private void ComprobarFinal()
    {
        Debug.Log("Se comprueba los puntos que quedan");
        if(puntos.Count <= 0)
        {
            Debug.Log("No quedan puntos");
            Victoria();
        }
    }

    private void Reiniciar()
    {
        for(int i = 0; i < puntos.Count; i++)
        {
            puntos[i].GetComponent<PuntoController>().marcado = false;
        }
    }

    private void Victoria()
    {
        FindObjectOfType<AudioManager>().Play("Victoria");
        imagenPuntos.SetActive(false);
        partes.SetActive(false);
        imagenFinal.SetActive(true);
    }
}
