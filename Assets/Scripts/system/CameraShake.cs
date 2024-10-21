using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    private CinemachineBasicMultiChannelPerlin[] noiseComponents;
    private int shakeCount = 0;

    // Variables para configurar la amplitud y frecuencia base
    public float baseAmplitude = 1f;
    public float baseFrequency = 1f;
    public float shakeDuration = 2f;

    void Start()
    {
        noiseComponents = new CinemachineBasicMultiChannelPerlin[virtualCameras.Length];
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            if (virtualCameras[i] != null)
            {
                noiseComponents[i] = virtualCameras[i].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            }
        }
    }

    public void ShakeCamera()
    {
        shakeCount++;
        for (int i = 0; i < noiseComponents.Length; i++)
        {
            if (noiseComponents[i] != null)
            {
                StartCoroutine(ShakeCoroutine(noiseComponents[i], shakeDuration, baseAmplitude * shakeCount, baseFrequency * shakeCount));
            }
        }
    }

    private IEnumerator ShakeCoroutine(CinemachineBasicMultiChannelPerlin noise, float duration, float amplitude, float frequency)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;

        yield return new WaitForSeconds(duration);

        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }

    public void ResetShakeCount()
    {
        shakeCount = 0;
    }
}
