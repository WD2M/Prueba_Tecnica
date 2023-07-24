using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstudiantesCalificar : InformacionEstudiante
{
    public Toggle toggleAprobado;
    public Toggle toggleReprobado;
    public void SuscripcionEventoValidacion()
    {
        puenteConsultas.EventValidacion += ValidacionAprobado;
        puenteConsultas.EventRaised += CambioFormaNota;
    }
    public void ToggleActico(Toggle toggle)
    {
        if (toggleAprobado.Equals(toggle) && toggleAprobado.IsActive())
        {
            toggleReprobado.isOn = false;
            toggleAprobado.enabled = false;
            toggleReprobado.enabled = true;
        }
        if (toggleReprobado.Equals(toggle) && toggleReprobado.IsActive())
        {
            toggleAprobado.isOn = false;
            toggleReprobado.enabled = false;
            toggleAprobado.enabled = true;
        }
    }
    public void CambioFormaNota()
    {
        if (puenteConsultas.escalaNota)
        {
            this.nota.text = (int.Parse(nota.text) / 20).ToString();
        }
        else
        {
            this.nota.text = (int.Parse(nota.text) * 20).ToString();
        }
    }
    void ValidacionAprobado()
    {
        if (puenteConsultas.escalaNota)
        {
            if (int.Parse(nota.text) >= 60 && toggleAprobado.isOn|| int.Parse(nota.text) < 60 && toggleReprobado.isOn)
            {
                image.color = Color.green;
                aprobado = true;
            }
            else
            {
                image.color = Color.red;
                puenteConsultas.notaCorrecta = false;
            }
        }
        else
        {
            if (int.Parse(nota.text) >= 3 && toggleAprobado.isOn|| int.Parse(nota.text) < 3 && toggleReprobado.isOn)
            {
                image.color = Color.green;
            }
            else
            {
                image.color = Color.red;
                puenteConsultas.notaCorrecta = false;
            }
        }
    }
}
