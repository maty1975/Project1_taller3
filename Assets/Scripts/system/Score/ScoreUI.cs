using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Referencia al objeto TextMeshProUGUI donde se mostrará el puntaje
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI FinalNunmber;
    public SystemSCORE scoreSystem; // Referencia al sistema de puntaje

    public UnityEvent onFinalScoreCalculated; // Nuevo evento Unity

    private void Start()
    {
        // Actualiza el texto del puntaje al inicio
        UpdateScoreText();
    }

    private void OnEnable()
    {
        // Suscribe el método UpdateScoreText al evento de cambio de puntaje
        scoreSystem.onScoreChange.AddListener(UpdateScoreText);
    }

    private void OnDisable()
    {
        // Desuscribe el método UpdateScoreText del evento de cambio de puntaje
        scoreSystem.onScoreChange.RemoveListener(UpdateScoreText);
    }

    // Método para actualizar el texto del puntaje en la interfaz de usuario
    private void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + scoreSystem.score;
    }

    public void FINALSCORE()
    {
        FinalScore.text = "FINAL SCORE ";
        FinalNunmber.text = "" + scoreSystem.score;

        // Dispara el evento cuando se calcula el puntaje final
        onFinalScoreCalculated.Invoke();
    }
}
