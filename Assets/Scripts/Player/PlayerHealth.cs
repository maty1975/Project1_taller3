using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Collision2DEvent : UnityEvent<Collision2D> { }

public class PlayerHealth : MonoBehaviour
{
    public VariableInt playerHealth;
    public Collision2DEvent FueTocado_Collider;
    public UnityEvent CERO_VIDAS_Collider;
    public GameObject UI_Gameover;

    public UnityEvent AL_PERDER_VIDA;

    private void Start()
    {
        //GetComponent<Trampa>().SI_TOCO_ACIDO.AddListener(ReducirVida);
    }

    public void ReducirVida()
    {
        // Reducir la vida del jugador
        playerHealth.valor--;

        if (playerHealth.valor <= 0)
        {
            CERO_VIDAS_Collider.Invoke();

            // Manejar la muerte del jugador aquí (reiniciar nivel, mostrar pantalla de game over, etc.)
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //COLISION GLOBAL
        FueTocado_Collider.Invoke(collision);

        if (collision.collider.CompareTag("Enemy"))
        {
            AL_PERDER_VIDA.Invoke();
        }
        //muerto(collision); // Llamar a muerto y pasar la colisión

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    //------------------------------------------------------------
    //FUNCIONES

    public void muerto(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Si colisionó con un enemigo, reducir la vida del jugador
            playerHealth.valor--;
            transform.position = CheckPointSystem.instance.UltimaPos;
            // Actualizar la UI
            UpdateUI();

            // Verificar si el jugador ha perdido todas sus vidas
            if (playerHealth.valor <= 0)
            {
                CERO_VIDAS_Collider.Invoke();

                // Manejar la muerte del jugador aquí (reiniciar nivel, mostrar pantalla de game over, etc.)
            }
        }
    }
    public void muerto_trigger(Collider2D collision)
    {
        if (collision.CompareTag("Lava"))
        {
            // Si colisionó con un enemigo, reducir la vida del jugador
            playerHealth.valor--;
            transform.position = CheckPointSystem.instance.UltimaPos;
            // Actualizar la UI
            UpdateUI();

            // Verificar si el jugador ha perdido todas sus vidas
            if (playerHealth.valor <= 0)
            {
                CERO_VIDAS_Collider.Invoke();

                // Manejar la muerte del jugador aquí (reiniciar nivel, mostrar pantalla de game over, etc.)
            }
        }
    }

    private void UpdateUI()
    {
        // Actualizar el texto de la UI con la nueva cantidad de vidas del jugador
        FindObjectOfType<UI_Manager>().UpdateHealthText();
    }

    public void UI_GAMEOVER()
    {
        UI_Gameover.SetActive(true);
        Time.timeScale = 0;
    }
}
