using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ManejoEstudiantes : MonoBehaviour
{
    public JsonDataManager jsonDataManager;

    public QueryEstudiantes queryEstudiantes;

    public GameObject panelInstancia;
    public GameObject canbas;

    public List<GameObject> listEstudiantes;

    public GameObject encender;
    public GameObject apagar;
    public GameObject aviso;

    public void InstanciaEstudiantes()
    {
        if (queryEstudiantes.estudiantesCalificados==false)
        {
            queryEstudiantes.data = jsonDataManager.LecturaArchivoJson();
            listEstudiantes.Clear();
            if (queryEstudiantes.data != null)
            {
                foreach (InformacionEstudianteJson student in queryEstudiantes.data.datos)
                {
                    GameObject estudiante = Instantiate(panelInstancia, canbas.transform);
                    listEstudiantes.Add(estudiante);
                    estudiante.GetComponent<InformacionEstudiante>().AsignacionDatos(student.nombre, student.apellido, student.identificacion.ToString(),
                                                                          student.correoInstitucional, student.notaFinal.ToString());

                    estudiante.GetComponent<InformacionEstudiante>().puenteConsultas = queryEstudiantes;
                }
            }
        }
    }
    public void InstanciaEstudiantesCalificar()
    {
        if (queryEstudiantes.estudiantesCalificados == false)
        {
            encender.SetActive(true);
            apagar.SetActive(false);
            queryEstudiantes.data = jsonDataManager.LecturaArchivoJson();
            listEstudiantes.Clear();
            if (queryEstudiantes.data != null)
            {
                foreach (InformacionEstudianteJson student in queryEstudiantes.data.datos)
                {
                    GameObject estudiante = Instantiate(panelInstancia, canbas.transform);
                    listEstudiantes.Add(estudiante);
                    estudiante.GetComponent<EstudiantesCalificar>().AsignacionDatos(student.nombre, student.apellido, student.identificacion.ToString(),
                                                                          student.correoInstitucional, student.notaFinal.ToString());

                    estudiante.GetComponent<EstudiantesCalificar>().puenteConsultas = queryEstudiantes;
                    estudiante.GetComponent<EstudiantesCalificar>().SuscripcionEventoValidacion();
                }
            }
        }
        else
        {
            aviso.SetActive(true);
        }
    }
}
