using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Meta_evento : MonoBehaviour
{
    public UnityEvent alActivar;

    public ScoreUI scoreUI; // Referencia al script ScoreUI
    public Timer timer; // Referencia al script Timer

    public TextMeshProUGUI textoScore; // Referencia al objeto TextMeshPro para mostrar la puntuaci�n
    public TextMeshProUGUI textoTiempo; // Referencia al objeto TextMeshPro para mostrar el tiempo

    private void OnEnable()
    {
        // Suscribe los m�todos correspondientes a los eventos de ScoreUI y Timer
        scoreUI.onFinalScoreCalculated.AddListener(ActualizarTextoScore);
        timer.EndTimer.AddListener(ActualizarTextoTiempo);
        ActualizarTextoScore();
        ActualizarTextoTiempo();
        alActivar.Invoke();
    }

    private void OnDisable()
    {
        // Desuscribe los m�todos correspondientes a los eventos de ScoreUI y Timer
        scoreUI.onFinalScoreCalculated.RemoveListener(ActualizarTextoScore);
        timer.EndTimer.RemoveListener(ActualizarTextoTiempo);
    }

    // M�todo para actualizar el texto de la puntuaci�n
    private void ActualizarTextoScore()
    {
        // Encontrar la instancia de SystemSCORE en la escena
        SystemSCORE systemScore = FindObjectOfType<SystemSCORE>();

        // Verificar si se encontr� la instancia de SystemSCORE
        if (systemScore != null)
        {
            // Actualizar el texto del objeto TextMeshPro con el puntaje obtenido del SystemSCORE
            textoScore.text = "" + systemScore.score.ToString();
        }
        else
        {
            // Mostrar un mensaje de error si no se encontr� SystemSCORE en la escena
            Debug.LogError("Error: No se encontr� un objeto SystemSCORE en la escena.");
        }
    }

    // M�todo para actualizar el texto del tiempo
    private void ActualizarTextoTiempo()
    {
        // Actualizar el texto del objeto TextMeshPro con el tiempo transcurrido del Timer
        textoTiempo.text = ObtenerTiempoFormateado(timer.tiempoTranscurrido);
    }

    // M�todo para obtener el tiempo en formato de cron�metro (HH:MM:SS)
    private string ObtenerTiempoFormateado(float tiempo)
    {
        int horas = (int)(tiempo / 3600);
        int minutos = (int)((tiempo % 3600) / 60);
        int segundos = (int)(tiempo % 60);
        return string.Format("{0:00}:{1:00}:{2:00}", horas, minutos, segundos);
    }
}
