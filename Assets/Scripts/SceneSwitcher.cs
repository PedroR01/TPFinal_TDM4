using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int escenaDestinoIndex = 2; // �ndice de la escena a la que quieres hacer la transici�n
    public float duracionTransicion = 5.0f; // Duraci�n en segundos

    private float tiempoTranscurrido = 0;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= duracionTransicion)
        {
            // Cargar la escena con el �ndice especificado
            SceneManager.LoadScene(escenaDestinoIndex);
        }
    }
}