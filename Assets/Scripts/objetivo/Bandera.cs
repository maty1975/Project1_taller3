using UnityEngine;
using UnityEngine.Events;

public class Bandera : MonoBehaviour
{
    public bool recolectada = false; // Indica si la bandera ha sido recolectada
    Animator anim;

    public UnityEvent OnRecolectar; // Evento que se dispara cuando la bandera es recolectada

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !recolectada)
        {
            recolectada = true;
            anim.Play("checkpointPaso");
            OnRecolectar.Invoke(); // Disparar el evento de recolección
        }
    }
}
