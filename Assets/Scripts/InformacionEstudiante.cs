using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformacionEstudiante : MonoBehaviour
{
    public QueryEstudiantes puenteConsultas;

    public Image image;

    public TextMeshProUGUI nombre;
    public TextMeshProUGUI apellido;
    public TextMeshProUGUI identificacion;
    public TextMeshProUGUI correo;
    public TextMeshProUGUI nota;
    public TextMeshProUGUI inicial;

    public bool aprobado;

    private void Start()
    {
        AsignarEstado();
    }
    void AsignarEstado()
    {
        if (puenteConsultas.escalaNota)
        {
            if (int.Parse(nota.text) >= 60)
            {
                aprobado = true;
            }
            else
            {
                aprobado = false;
            }
        }
        else
        {
            if (int.Parse(nota.text) >= 3)
            {
                aprobado = true;
            }
            else
            {
                aprobado = false;
            }
        }
    }
    public void AsignacionDatos(string nombre, string apellido, string identificacion, string correo, string nota)
    {
        this.nombre.text = nombre;
        this.apellido.text = apellido;
        this.identificacion.text = identificacion;
        this.correo.text = correo;
        this.nota.text = nota;
        this.inicial.text = nombre[0].ToString();
    }
}
