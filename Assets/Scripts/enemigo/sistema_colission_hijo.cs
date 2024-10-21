using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sistema_colission_hijo : MonoBehaviour
{
    public string targetTag; // La etiqueta que deseas comparar
    public UnityEvent onenter2DchildWithTag, onstay2DchildWithTag, onexit2DchildWithTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si la colisión es con el objeto deseado y tiene la etiqueta deseada
        if (collision.gameObject == gameObject && collision.CompareTag(targetTag))
        {
            // Invocar el evento de entrada al collider hijo con la etiqueta deseada
            onenter2DchildWithTag.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Verificar si la colisión es con el objeto deseado y tiene la etiqueta deseada
        if (collision.gameObject == gameObject && collision.CompareTag(targetTag))
        {
            // Invocar el evento de permanencia en el collider hijo con la etiqueta deseada
            onstay2DchildWithTag.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si la colisión es con el objeto deseado y tiene la etiqueta deseada
        if (collision.gameObject == gameObject && collision.CompareTag(targetTag))
        {
            // Invocar el evento de salida del collider hijo con la etiqueta deseada
            onexit2DchildWithTag.Invoke();
        }
    }
}
