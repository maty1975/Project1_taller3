using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public ParticleSystem particleSystem; // Referencia al sistema de part�culas que quieres reproducir
    public float interval = 5f; // Intervalo en segundos entre cada reproducci�n

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; // Incrementa el temporizador con el tiempo transcurrido

        // Si el temporizador supera el intervalo, se reproduce el sistema de part�culas y se reinicia el temporizador
        if (timer >= interval)
        {
            PlayParticleSystem();
            timer = 0f;
        }
    }

    void PlayParticleSystem()
    {
        // Verifica que el sistema de part�culas no est� reproduci�ndose actualmente antes de intentar reproducirlo nuevamente
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }
}
