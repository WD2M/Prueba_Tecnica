using System.Collections;
using System.IO;
using UnityEngine;

public class JsonDataManager : MonoBehaviour
{
    string rutaJson;

    private void Awake()
    {
        rutaJson = Path.Combine(Application.streamingAssetsPath, "Estudiantes.json");
    }

    public ClassListaInformacionEstudiantesJson LecturaArchivoJson()
    {
        ClassListaInformacionEstudiantesJson ListaInformacion = null;

        if (File.Exists(rutaJson))
        {
            string jsonString = File.ReadAllText(rutaJson);
            ListaInformacion = JsonUtility.FromJson<ClassListaInformacionEstudiantesJson>(jsonString);
        }
        else
        {
            Debug.LogError("El archivo JSON no existe en la ruta: " + rutaJson);
        }

        return ListaInformacion;
    }

    public void GuardarArchivoJson(ClassListaInformacionEstudiantesJson jsonInformacion)
    {
        string jsonString = JsonUtility.ToJson(jsonInformacion);
        File.WriteAllText(rutaJson, jsonString);
    }

}
