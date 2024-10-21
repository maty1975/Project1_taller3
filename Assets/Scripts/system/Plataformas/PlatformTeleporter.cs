using UnityEngine;

public class PlatformTeleporter : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float teleportInterval = 2f; // Intervalo de tiempo entre teleportaciones

    private Transform currentTarget;
    private float lastTeleportTime; // Tiempo en el que se realizó la última teleportación

    void Start()
    {
        // Inicialmente, la plataforma está en el punto A
        transform.position = pointA.position;
        currentTarget = pointB;
        lastTeleportTime = Time.time; // Inicializar el tiempo de la última teleportación
    }

    void Update()
    {
        // Verificar si es momento de teletransportar nuevamente
        if (Time.time - lastTeleportTime >= teleportInterval)
        {
            TeleportPlatform(); // Teletransportar la plataforma
        }
    }

    // Teleporta la plataforma al punto objetivo
    public void TeleportPlatform()
    {
        transform.position = currentTarget.position;

        // Cambiar el objetivo de teletransporte para la próxima vez
        currentTarget = (currentTarget == pointA) ? pointB : pointA;

        // Actualizar el tiempo de la última teleportación
        lastTeleportTime = Time.time;
    }

    // Cuando el jugador entra en contacto con la plataforma
    

    // Dibuja un gizmo para visualizar la línea entre los puntos A y B, y la plataforma en cada punto
    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            // Dibujar la línea entre los puntos A y B
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(pointA.position, pointB.position);

            // Dibujar la plataforma en el punto A
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(pointA.position, transform.localScale);

            // Dibujar la plataforma en el punto B
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(pointB.position, transform.localScale);
        }
    }

    // Función para teletransportar instantáneamente la plataforma al otro punto y reiniciar el conteo
    public void InstantTeleportToOtherPoint()
    {
        TeleportPlatform(); // Teletransportar instantáneamente
    }
}
