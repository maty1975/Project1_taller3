using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public string tag;
    public UnityEvent onEnter, onStay, onExit;

    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.CompareTag(tag))
            {
                onExit.Invoke();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            onStay.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            onEnter.Invoke();
        }
    }
    public void Evento()
    {
        onEnter.Invoke();
    }
}

