using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class patrullar : MonoBehaviour
{
    public patrullar scriptPatrullar;
    [Header("EVENTOS")]

    public Transform[] ruta;
    [Header("EVENTOS ENTRE ENEMIGOS")]
    public bool Active_direction_change = true;
    public UnityEvent Detect_enemy;
    [Header("PARAMETROS")]
    public float velocidadInicial = 2f; // Velocidad inicial de movimiento del enemigo
    public float velocidadAumentada = 4f; // Velocidad cuando el jugador está dentro del collider trigger
    public float Time_wait;

    private int indiceActual = 0; // Índice del punto de ruta actual
    private Vector3 direccionAnterior = Vector3.zero; // Dirección de movimiento anterior

    [SerializeField]private bool aumentarVelocidad = false; // Indica si se debe aumentar la velocidad del enemigo

    void Start()
    {
        // Comenzar a moverse hacia el primer punto de la ruta
        StartCoroutine(Mover());
    }

    IEnumerator Mover()
    {
        while (true)
        {
            // Calcular la dirección hacia el siguiente punto de la ruta
            Vector3 direccion = (ruta[indiceActual].position - transform.position).normalized;

            // Determinar la dirección del movimiento actual
            if (direccion.x < 0) // Movimiento hacia la izquierda
            {
                transform.localScale = new Vector3(1, 1, 1); // Invertir el local scale en el eje X
            }
            else if (direccion.x > 0) // Movimiento hacia la derecha
            {
                transform.localScale = new Vector3(-1, 1, 1); // Mantener el local scale original
            }

            // Determinar la velocidad de movimiento actual
            float velocidadActual = aumentarVelocidad ? velocidadAumentada : velocidadInicial;

            // Moverse hacia el siguiente punto de la ruta
            transform.Translate(direccion * velocidadActual * Time.deltaTime);

            // Si el objeto ha alcanzado el punto de la ruta actual, pasar al siguiente punto
            if (Vector3.Distance(transform.position, ruta[indiceActual].position) < 0.1f)
            {
                indiceActual = (indiceActual + 1) % ruta.Length; // Avanzar al siguiente punto de forma cíclica
                yield return new WaitForSeconds(Time_wait); // Esperar un segundo en cada punto antes de avanzar
            }

            yield return null;
        }
    }


    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        patrullar otherPatrolScript = collision.gameObject.GetComponent<patrullar>();
        if (otherPatrolScript != null && otherPatrolScript != this && Active_direction_change == true)
        {
            Detect_enemy.Invoke();
            // Cambiar de ruta para el primer enemigo
            CambiarRuta();
            //Debug.Log("CAMBIO DIRECCION");

            // Cambiar de ruta para el segundo enemigo
            otherPatrolScript.CambiarRuta();
            
        }
    }

    public void persecution_speed()
    {
        aumentarVelocidad = true; // Aumentar la velocidad cuando el jugador colisiona con el collider trigger
    }

    public void no_persecution_speed()
    {
        aumentarVelocidad = false; // Restaurar la velocidad inicial cuando el jugador sale del collider trigger
    }

    public void CambiarRuta()
    {
        // Lógica para cambiar de ruta
        // Por ejemplo:
        int nuevaRutaIndex = (indiceActual + 1) % ruta.Length;
        indiceActual = nuevaRutaIndex;
    }
}
