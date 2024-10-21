using UnityEngine;
using UnityEngine.Events;

public class ImpactDetection2D : MonoBehaviour
{
    public UnityEvent onImpactWithBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si la colisión es con un objeto que tiene el tag "Bala"
        if (other.CompareTag("Bala"))
        {
            // Invoca el evento cuando hay colisión con una bala
            onImpactWithBullet.Invoke();
        }
    }
}
