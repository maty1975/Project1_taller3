using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class META : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu_Completed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Avanzar_player()
    {
        Player.SetActive(false);
    }
    public void Active_Menu_Completed()
    {
        Menu_Completed.SetActive(true);
    }
}
