using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem particleSystem; // Referencia al sistema de partículas que quieres reproducir
    public float interval = 5f; // Intervalo en segundos entre cada reproducción

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; // Incrementa el temporizador con el tiempo transcurrido

        // Si el temporizador supera el intervalo, se reproduce el sistema de partículas y se reinicia el temporizador
        if (timer >= interval)
        {
            PlayParticleSystem();
            timer = 0f;
        }
    }

    void PlayParticleSystem()
    {
        // Verifica que el sistema de partículas no esté reproduciéndose actualmente antes de intentar reproducirlo nuevamente
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }
}
