using UnityEngine;
using UnityEngine.Events;

public class EnemyDetection2D : MonoBehaviour
{
    public Color gizmoColor = Color.yellow;
    [Range(0.1f, 50f)]
    public float detectionRadius = 5f;
    public LayerMask targetLayer;
    public Transform player;
    public bool isPlayerBehind = false;

    private Vector2 lastEnemyDirection = Vector2.right; // Inicialmente, asumimos que el enemigo mira hacia la derecha

    void Update()
    {
        if (player == null)
            return;

        // Verificar si el jugador está dentro del radio de detección
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Obtener la dirección del jugador relativa al enemigo
            Vector2 directionToPlayer = player.position - transform.position;

            // Obtener la dirección hacia adelante del enemigo
            Vector2 enemyForward = transform.right; // Usamos transform.right para representar el eje hacia adelante del enemigo en 2D

            // Determinar si el enemigo ha girado
            if (Vector2.Dot(enemyForward, lastEnemyDirection) < 0)
            {
                // El enemigo ha girado, invertir la dirección
                enemyForward *= -1f;
            }

            // Almacenar la última dirección del enemigo
            lastEnemyDirection = enemyForward;

            // Verificar si el jugador está detrás del enemigo
            float dotProduct = Vector2.Dot(directionToPlayer.normalized, enemyForward.normalized);
            isPlayerBehind = (dotProduct < 0);
            Debug.Log(isPlayerBehind ? "ESTA DETRAS" : "ESTA DELANTE");
        }
        else
        {
            isPlayerBehind = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
