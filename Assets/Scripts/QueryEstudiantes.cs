using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QueryEstudiantes: MonoBehaviour
{
    public JsonDataManager jsonDataManager;

    public ClassListaInformacionEstudiantesJson data;

    public TMP_Dropdown dropdown;

    public TMP_InputField inputFieldnombre;
    public TMP_InputField inputFieldApellido;
    public TMP_InputField inputFieldIdentificacion;
    public TMP_InputField inputFieldCorreo;
    public TMP_InputField inputFieldNota;

    public TextMeshProUGUI mensaje;

    public delegate void GameEventHandler();
    public event GameEventHandler EventRaised;
    public event GameEventHandler EventRefresh;
    public event GameEventHandler EventValidacion;

    public bool escalaNota;
    public bool notaCorrecta=false;
    public bool estudiantesCalificados= false;

    [ContextMenu("AgregarEstudiante(")]
    public void AgregarEstudiante()
    {
        if (CheckInputFiel())
        {
            InformacionEstudianteJson newData = new InformacionEstudianteJson();
            newData.nombre = inputFieldnombre.text;
            newData.apellido = inputFieldApellido.text;
            newData.identificacion = int.Parse(inputFieldIdentificacion.text);
            newData.correoInstitucional = inputFieldCorreo.text;
            newData.notaFinal = int.Parse(inputFieldNota.text);
            data.datos.Add(newData);
            GuardarDatosJson();
            LimpiezaEstudianteAgregado();
        }
    }
    bool CheckInputFiel()
    {
        return inputFieldnombre.text != null && inputFieldApellido.text != null && inputFieldIdentificacion.text != null
               && inputFieldCorreo.text != null && inputFieldNota.text != null;
    }
    public void LimpiezaEstudianteAgregado()
    {
        inputFieldnombre.text = "";
        inputFieldApellido.text = "";
        inputFieldIdentificacion.text = "";
        inputFieldCorreo.text = "";
        inputFieldNota.text = "";
    }
    [ContextMenu("MostrarDatosParaActualizar")]
    public void MostrarDatosParaActualizar()
    {
        inputFieldnombre.text = data.datos[dropdown.value].nombre;
        inputFieldApellido.text = data.datos[dropdown.value].apellido;
        inputFieldIdentificacion.text = data.datos[dropdown.value].identificacion.ToString();
        inputFieldCorreo.text = data.datos[dropdown.value].correoInstitucional;
        inputFieldNota.text = data.datos[dropdown.value].notaFinal.ToString();
    }
    [ContextMenu("ActualizarDatosEstudiantes")]
    public void ActualizarDatosEstudiantes()
    {
        data.datos[dropdown.value].nombre = inputFieldnombre.text;
        data.datos[dropdown.value].apellido = inputFieldApellido.text;
        data.datos[dropdown.value].identificacion = int.Parse(inputFieldIdentificacion.text);
        data.datos[dropdown.value].correoInstitucional = inputFieldCorreo.text;
        data.datos[dropdown.value].notaFinal = int.Parse(inputFieldNota.text);
        jsonDataManager.GuardarArchivoJson(data);
    }

    [ContextMenu("GuardarDatosJson")]
    void GuardarDatosJson()
    {
        jsonDataManager.GuardarArchivoJson(data);
        EventRefresh?.Invoke();
    }

    [ContextMenu("EliminarEstudiante")]
    public void EliminarEstudiante()
    {
        data.datos.RemoveAt(dropdown.value);
        GuardarDatosJson();
    }

    [ContextMenu("CambioFormatoNotas")]
    public void CambioFormatoNotas()
    {
        EventRaised?.Invoke();
        escalaNota = !escalaNota;
    }
    public List<string> ListaEstudiantes()
    {
        data.datos.Clear();
        data = jsonDataManager.LecturaArchivoJson();
        if (data != null)
        {
            List<string> Datos = new List<string>();
            foreach (InformacionEstudianteJson student in data.datos)
            {
                Datos.Add(student.nombre + " " + student.apellido + " " + student.identificacion.ToString());
            }
            return Datos;
        }
        return null;
    }
    public void ValidacionAprobado()
    {
        notaCorrecta = true;
        EventValidacion?.Invoke();
        if (notaCorrecta)
        {
            mensaje.text = "Calificado Correctamente";
        }
        else
        {
            mensaje.text = "Calificado Incorrectamente";
        }
    }
}
