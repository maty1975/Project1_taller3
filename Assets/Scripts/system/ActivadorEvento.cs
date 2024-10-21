using UnityEngine;
using UnityEngine.Events;

public class ActivadorEvento : MonoBehaviour
{
    public UnityEvent eventoColisionPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (eventoColisionPlayer != null)
            {
                eventoColisionPlayer.Invoke();
            }
        }
    }

}
