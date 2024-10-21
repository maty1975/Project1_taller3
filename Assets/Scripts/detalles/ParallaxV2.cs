using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ParallaxV2 : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public RawImage layerImage;
        public float parallaxSpeed = 1.0f; // Velocidad de parallax de la capa
        public bool freezeWidth = false; // Indica si se congela el movimiento en el eje X
        public bool freezeHeight = false; // Indica si se congela el movimiento en el eje Y
    }

    public List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>(); // Lista de capas de parallax

    public float cameraStopInterval = 5f; // Intervalo en segundos para detener el movimiento de la cámara
    private float timeSinceLastCameraStop = 0f; // Tiempo transcurrido desde la última vez que se detuvo la cámara
    private Vector3 previousCameraPosition; // Posición de la cámara en el fotograma anterior

    void Start()
    {
        previousCameraPosition = Camera.main.transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento de la cámara desde el fotograma anterior
        Vector3 cameraDelta = Camera.main.transform.position - previousCameraPosition;

        // Incrementa el tiempo transcurrido desde la última vez que se detuvo la cámara
        timeSinceLastCameraStop += Time.deltaTime;

        // Verifica si ha pasado el intervalo deseado para detener el movimiento de la cámara
        if (timeSinceLastCameraStop >= cameraStopInterval)
        {
            cameraDelta = Vector3.zero;
            timeSinceLastCameraStop = 0f; // Reinicia el temporizador
        }

        // Actualiza la posición de cada capa de parallax
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            if (layer.layerImage != null)
            {
                // Calcula el desplazamiento del UV
                float xOffset = (!layer.freezeWidth) ? cameraDelta.x * layer.parallaxSpeed : 0f;
                float yOffset = (!layer.freezeHeight) ? cameraDelta.y * layer.parallaxSpeed : 0f;

                // Actualiza el UV del RawImage
                Rect uvRect = layer.layerImage.uvRect;
                uvRect.x += xOffset * Time.deltaTime;
                uvRect.y += yOffset * Time.deltaTime;
                layer.layerImage.uvRect = uvRect;
            }
        }

        // Actualiza la posición de la cámara para el próximo fotograma
        previousCameraPosition = Camera.main.transform.position;
    }
}
