using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int escenaDestinoIndex = 2; // Índice de la escena a la que quieres hacer la transición
    public float duracionTransicion = 5.0f; // Duración en segundos

    private float tiempoTranscurrido = 0;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= duracionTransicion)
        {
            // Cargar la escena con el índice especificado
            SceneManager.LoadScene(escenaDestinoIndex);
        }
    }
}