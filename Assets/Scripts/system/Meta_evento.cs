using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Meta_evento : MonoBehaviour
{
    public UnityEvent alActivar;

    public ScoreUI scoreUI; // Referencia al script ScoreUI
    public Timer timer; // Referencia al script Timer

    public TextMeshProUGUI textoScore; // Referencia al objeto TextMeshPro para mostrar la puntuación
    public TextMeshProUGUI textoTiempo; // Referencia al objeto TextMeshPro para mostrar el tiempo

    private void OnEnable()
    {
        // Suscribe los métodos correspondientes a los eventos de ScoreUI y Timer
        scoreUI.onFinalScoreCalculated.AddListener(ActualizarTextoScore);
        timer.EndTimer.AddListener(ActualizarTextoTiempo);
        ActualizarTextoScore();
        ActualizarTextoTiempo();
        alActivar.Invoke();
    }

    private void OnDisable()
    {
        // Desuscribe los métodos correspondientes a los eventos de ScoreUI y Timer
        scoreUI.onFinalScoreCalculated.RemoveListener(ActualizarTextoScore);
        timer.EndTimer.RemoveListener(ActualizarTextoTiempo);
    }

    // Método para actualizar el texto de la puntuación
    private void ActualizarTextoScore()
    {
        // Encontrar la instancia de SystemSCORE en la escena
        SystemSCORE systemScore = FindObjectOfType<SystemSCORE>();

        // Verificar si se encontró la instancia de SystemSCORE
        if (systemScore != null)
        {
            // Actualizar el texto del objeto TextMeshPro con el puntaje obtenido del SystemSCORE
            textoScore.text = "" + systemScore.score.ToString();
        }
        else
        {
            // Mostrar un mensaje de error si no se encontró SystemSCORE en la escena
            Debug.LogError("Error: No se encontró un objeto SystemSCORE en la escena.");
        }
    }

    // Método para actualizar el texto del tiempo
    private void ActualizarTextoTiempo()
    {
        // Actualizar el texto del objeto TextMeshPro con el tiempo transcurrido del Timer
        textoTiempo.text = ObtenerTiempoFormateado(timer.tiempoTranscurrido);
    }

    // Método para obtener el tiempo en formato de cronómetro (HH:MM:SS)
    private string ObtenerTiempoFormateado(float tiempo)
    {
        int horas = (int)(tiempo / 3600);
        int minutos = (int)((tiempo % 3600) / 60);
        int segundos = (int)(tiempo % 60);
        return string.Format("{0:00}:{1:00}:{2:00}", horas, minutos, segundos);
    }
}
