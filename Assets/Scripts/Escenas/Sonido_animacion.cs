using UnityEngine;

public class Sonido_animacion : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource

    public void PlayAudio(AudioClip clipDeAudio)
    {
        // Comprobación de nulidad (null check)
        if (audioSource != null)
        {
            audioSource.clip = clipDeAudio; // Asigna el AudioClip al AudioSource
            audioSource.Play(); // Reproduce el audio
        }
        else
        {
            Debug.LogWarning("El AudioSource es nulo. No se puede reproducir el audio.");
        }
    }
    public void playoneshot(AudioClip clipaudioshot)
    {
        audioSource.PlayOneShot(clipaudioshot);
    }
}
