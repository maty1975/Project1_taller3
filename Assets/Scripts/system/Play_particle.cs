using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_particle : MonoBehaviour
{
    public ParticleSystem particula;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reproducir_particular()
    {
        particula.Play();
    }

    public void Detener_particula()
    {
        particula.Stop();
    }
}
