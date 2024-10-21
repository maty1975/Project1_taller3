using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFloat : MonoBehaviour
{
    public GameObject textoPrefab;
    public Transform spawnPoint;
    public float tiempoDestruccion = 3f;
    TextMesh tm;

    private void Awake()
    {
        tm = GetComponentInChildren<TextMesh>();
    }


    private void Start()
    {
        tm.text = (150 * SystemSCORE.comboMultiplier).ToString();
    }

    public void Destruirse()
    {
        Destroy(gameObject);
    }
}
