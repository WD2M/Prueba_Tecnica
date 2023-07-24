using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListadoEstudiante : MonoBehaviour
{
    [SerializeField] QueryEstudiantes queryEstudiantes;
    [SerializeField] TMP_Dropdown dropdown;
    bool sincronizado=true;
    private void OnEnable()
    {
        if (sincronizado)
        {
            queryEstudiantes.EventRefresh += RefrescarLista;
            sincronizado = false;
        }
        RefrescarLista();
    }
    [ContextMenu("RefrescarLista")]
    void RefrescarLista()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(queryEstudiantes.ListaEstudiantes());
        Debug.Log("Regrescar");
    }
}
