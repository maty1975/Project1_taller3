using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Text_bandera : MonoBehaviour
{
    public TextMesh texto_mesh;
    private string mensaje;

    // Start is called before the first frame update
    void Start()
    {
        cambiar_Texto(mensaje);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambiar_Texto(string texto)
    {
        texto_mesh.text = texto.ToString();
    }

    public void destruir()
    {
        Destroy(gameObject);
    }
}
