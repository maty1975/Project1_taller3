using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class combo_plus : MonoBehaviour
{
    public UnityEvent TOCAR_COMBO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TOCAR_COMBO.Invoke();
    }
}
