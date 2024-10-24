using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneController : MonoBehaviour
{
    public UnityEvent Al_Cambiar_escena;
    public float delayTime = 2f; // Tiempo de retraso en segundos

    public void RestartScene()
    {
        // Obtener el nombre de la escena actual
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Iniciar la corutina para reiniciar la escena despu�s del retraso
        StartCoroutine(RestartSceneWithDelay(currentSceneName));
        
    }

    public void ChangeScene(string sceneName)
    {
        // Iniciar la corutina para cambiar de escena despu�s del retraso
        Al_Cambiar_escena.Invoke();
        StartCoroutine(ChangeSceneWithDelay(sceneName));
    }


    public void Salir()
    {
        // Salir del juego
        Application.Quit();
    }

    private IEnumerator RestartSceneWithDelay(string sceneName)
    {
        // Esperar el tiempo de retraso
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 1f;
        // Recargar la escena actual
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator ChangeSceneWithDelay(string sceneName)
    {
        // Esperar el tiempo de retraso
        yield return new WaitForSeconds(delayTime);

        // Cambiar a la nueva escena
        SceneManager.LoadScene(sceneName);
    }
}
