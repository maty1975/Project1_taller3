using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Add_vida : MonoBehaviour
{
    public VariableInt playerhealth;
    public UnityEvent al_tocar_vida_Player_TRIGGER;
    private PolygonCollider2D polycolider;
    // Start is called before the first frame update
    void Start()
    {
        polycolider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            al_tocar_vida_Player_TRIGGER.Invoke();
        }
    }
    public void vida_plus()
    {
        playerhealth.valor += 1;
    }
}
