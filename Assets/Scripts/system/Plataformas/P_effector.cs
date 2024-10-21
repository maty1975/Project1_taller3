using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class P_effector : MonoBehaviour
{
    public UnityEvent Al_tocar_platform, al_salir_platform;
    private BoxCollider2D bx2D;
    private PlatformEffector2D pt_effector2D;
    // Start is called before the first frame update
    void Start()
    {
        bx2D = GetComponent<BoxCollider2D>();
        pt_effector2D = GetComponent<PlatformEffector2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.S) && collision.collider.CompareTag("Player"))
        {
            Al_tocar_platform.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            al_salir_platform.Invoke();
        }
        
    }
    //ESTA DE MAS ESTO, PERO POR SI ACASO LO DEJARE, POR PAJERO
    public void default_rotacion()
    {
        pt_effector2D.rotationalOffset = 0;
    }
    public void rotacion_down()
    {
        pt_effector2D.rotationalOffset = 180;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
