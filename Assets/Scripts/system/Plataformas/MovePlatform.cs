using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public List<Transform> routePoints;
    public float speed;

    private int currentTargetIndex = 0;

    private void Start()
    {
        // Comprobar si hay puntos de ruta en la lista
        if (routePoints.Count > 0)
        {
            SetNextTarget();
        }
        else
        {
            Debug.LogError("No se han especificado puntos de ruta en la lista.");
        }
    }

    private void Update()
    {
        // Verificar si hemos llegado al punto de destino
        if (Vector2.Distance(transform.position, routePoints[currentTargetIndex].position) < 0.05f)
        {
            // Establecer el siguiente punto de destino
            SetNextTarget();
        }

        // Mover la plataforma hacia el punto de destino
        transform.position = Vector3.MoveTowards(transform.position, routePoints[currentTargetIndex].position, speed * Time.deltaTime);
    }

    private void SetNextTarget()
    {
        // Incrementar el índice del punto de destino
        currentTargetIndex++;

        // Si hemos alcanzado el final de la lista, volver al principio
        if (currentTargetIndex >= routePoints.Count)
        {
            currentTargetIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar las líneas que conectan los puntos de ruta
        Gizmos.color = Color.green;
        for (int i = 0; i < routePoints.Count; i++)
        {
            int nextIndex = (i + 1) % routePoints.Count;
            Gizmos.DrawLine(routePoints[i].position, routePoints[nextIndex].position);
        }

        // Dibujar la plataforma en cada punto de ruta
        Gizmos.color = Color.red;
        foreach (Transform point in routePoints)
        {
            Gizmos.DrawWireCube(point.position, transform.localScale);
        }

        // Dibujar esferas en cada punto de ruta
        Gizmos.color = Color.yellow;
        foreach (Transform point in routePoints)
        {
            Gizmos.DrawSphere(point.position, 0.2f);
        }
    }
}
