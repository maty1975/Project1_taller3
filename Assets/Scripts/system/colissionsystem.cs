using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class colissionsystem : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("TRIGGER 2D")]
    public UnityEvent Onenter_T, Onstay_T, Onexit_T;
    [Header("COLLISION 2D")]
    public UnityEvent Onenter_C, Onstay_C, Onexit_C;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Onenter_T.Invoke();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Onstay_T.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Onexit_T.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Onenter_C.Invoke();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Onstay_C.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Onexit_C.Invoke();
    }
    

}
