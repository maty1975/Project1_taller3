using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class AudioControl
{
    public string audioName; // Nombre identificador del AudioSource
    public AudioSource audioSource; // Referencia al AudioSource
    public Slider volumeSlider; // Referencia al slider para ajustar el volumen
    public Button increaseVolumeButton; // Bot�n para aumentar el volumen
    public Button decreaseVolumeButton; // Bot�n para disminuir el volumen
    public AudioClip volumeAdjustSound; // Sonido que se reproduce al ajustar el volumen
}

public class AudioManager : MonoBehaviour
{
    public List<AudioControl> audioControls = new List<AudioControl>(); // Lista de controles de audio

    void Start()
    {
        // Configurar cada control de audio
        foreach (var audioControl in audioControls)
        {
            // Cargar el volumen guardado o establecer el valor predeterminado
            float savedVolume = PlayerPrefs.GetFloat(audioControl.audioName + "_Volume", audioControl.audioSource.volume);
            audioControl.volumeSlider.value = savedVolume;
            audioControl.audioSource.volume = savedVolume;

            // Agregar un listener al slider para guardar el volumen cuando cambie
            audioControl.volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(audioControl); });

            // Agregar listener para aumentar el volumen si el bot�n est� presente
            if (audioControl.increaseVolumeButton != null)
            {
                audioControl.increaseVolumeButton.onClick.AddListener(delegate { IncreaseVolume(audioControl); });
            }

            // Agregar listener para disminuir el volumen si el bot�n est� presente
            if (audioControl.decreaseVolumeButton != null)
            {
                audioControl.decreaseVolumeButton.onClick.AddListener(delegate { DecreaseVolume(audioControl); });
            }
        }
    }

    // M�todo para cambiar el volumen de un AudioSource
    public void ChangeVolume(AudioControl audioControl)
    {
        audioControl.audioSource.volume = audioControl.volumeSlider.value;
        PlayerPrefs.SetFloat(audioControl.audioName + "_Volume", audioControl.volumeSlider.value); // Guardar el volumen
    }

    // M�todo para aumentar el volumen de un AudioSource
    public void IncreaseVolume(AudioControl audioControl)
    {
        audioControl.volumeSlider.value = Mathf.Min(audioControl.volumeSlider.value + 0.1f, 1.0f);
        ChangeVolume(audioControl); // Guardar el volumen despu�s de ajustarlo

        // Reproducir sonido de ajuste de volumen si est� configurado
        if (audioControl.volumeAdjustSound != null)
        {
            audioControl.audioSource.PlayOneShot(audioControl.volumeAdjustSound);
        }
    }

    // M�todo para disminuir el volumen de un AudioSource
    public void DecreaseVolume(AudioControl audioControl)
    {
        audioControl.volumeSlider.value = Mathf.Max(audioControl.volumeSlider.value - 0.1f, 0.0f);
        ChangeVolume(audioControl); // Guardar el volumen despu�s de ajustarlo

        // Reproducir sonido de ajuste de volumen si est� configurado
        if (audioControl.volumeAdjustSound != null)
        {
            audioControl.audioSource.PlayOneShot(audioControl.volumeAdjustSound);
        }
    }
}
