using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlar : MonoBehaviour
{
    public void cambiarEscena(string nombre)
    {
        Application.LoadLevel(nombre);
    }

    public void cerrarJuego()
    {
        Application.Quit();
    }
}
