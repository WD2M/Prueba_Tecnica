using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject panel;

    public Transform content;
    public Transform scrollInicial;

    public List<InformacionEstudiante> informacionEstudiantesList;

    public bool aprobado;

    public DragSlot dragSlot;

    public QueryEstudiantes queryEstudiantes;

    public TextMeshProUGUI mensaje;

    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandler.itemDrag!=null)
        {
            item = DragHandler.itemDrag;
            item.transform.SetParent(content);
            informacionEstudiantesList.Add(item.GetComponent<InformacionEstudiante>());
            dragSlot.informacionEstudiantesList.Remove(item.GetComponent<InformacionEstudiante>());
            if (queryEstudiantes.data.datos.Count==(informacionEstudiantesList.Count+dragSlot.informacionEstudiantesList.Count))
            {
                queryEstudiantes.notaCorrecta = true;
                mensaje.text = "Bien calificado";
                Calificar();
                dragSlot.Calificar();
                panel.SetActive(true);
                queryEstudiantes.estudiantesCalificados = true;
            }
        }
    }
    public void Calificar()
    {
        for (int i = 0; i < informacionEstudiantesList.Count; i++)
        {
            if (informacionEstudiantesList[i].aprobado!=aprobado)
            {
                informacionEstudiantesList[i].image.color = Color.red;
                queryEstudiantes.notaCorrecta = false;
                queryEstudiantes.estudiantesCalificados = false;
                mensaje.text = "mal calificado, revisa de nuevo";
                informacionEstudiantesList[i].transform.SetParent(scrollInicial);
                informacionEstudiantesList.RemoveAt(i);
            }
            else
            {
                informacionEstudiantesList[i].image.color = Color.green;
            }
        }
    }
}
