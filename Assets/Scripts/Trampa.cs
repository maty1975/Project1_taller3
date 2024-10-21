using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Trampa : MonoBehaviour
{
    public UnityEvent SI_TOCO_ACIDO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SI_TOCO_ACIDO.Invoke();
            collision.transform.position = CheckPointSystem.instance.UltimaPos;
        }
    }
    

}
