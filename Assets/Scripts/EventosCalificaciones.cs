using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosCalificaciones : MonoBehaviour
{
    public GameObject[] objetoApagar;
    public GameObject objetoEncender;
    public QueryEstudiantes queryEstudiantes;

    public void Validador()
    {
        if (queryEstudiantes.notaCorrecta)
        {
            queryEstudiantes.mensaje.text = "Calificado Correctamente";
            
            objetoEncender.SetActive(true);
            if (objetoEncender.GetComponent<ManejoEstudiantes>()!=null)
            {
                objetoEncender.GetComponent<ManejoEstudiantes>().InstanciaEstudiantes();
            }
            
            objetoApagar[1].SetActive(false);
        }
        else
        {
            queryEstudiantes.mensaje.text = "Calificado Incorrectamente";

        }
            objetoApagar[0].SetActive(false);
    }
}
