using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeFloat : MonoBehaviour
{
    TextMesh textlife;

    private void Awake()
    {
        textlife = GetComponentInChildren<TextMesh>();
    }

    private void Start()
    {
        textlife.text = "+1"  + " life"; // Actualizamos el texto con la vida actual
    }

    public void autoDestruccion()
    {
        Destroy(gameObject);
    }
}
