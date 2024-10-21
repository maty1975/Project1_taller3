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

        // Verificar si el jugador est� dentro del radio de detecci�n
        if (Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Obtener la direcci�n del jugador relativa al enemigo
            Vector2 directionToPlayer = player.position - transform.position;

            // Obtener la direcci�n hacia adelante del enemigo
            Vector2 enemyForward = transform.right; // Usamos transform.right para representar el eje hacia adelante del enemigo en 2D

            // Determinar si el enemigo ha girado
            if (Vector2.Dot(enemyForward, lastEnemyDirection) < 0)
            {
                // El enemigo ha girado, invertir la direcci�n
                enemyForward *= -1f;
            }

            // Almacenar la �ltima direcci�n del enemigo
            lastEnemyDirection = enemyForward;

            // Verificar si el jugador est� detr�s del enemigo
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
