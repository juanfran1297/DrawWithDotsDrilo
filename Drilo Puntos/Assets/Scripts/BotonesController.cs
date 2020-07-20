using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesController : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }

    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void ReproducirBorrar(string nombreSonido)
    {
        FindObjectOfType<AudioManager>().Play("Borrar");
    }
}
