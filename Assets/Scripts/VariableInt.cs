using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "variable int")]
public class VariableInt : ScriptableObject
{
    public int valor;


    public void Reset_HP()
    {
        valor = 5;
    }

    public void asignar_vida(int vida)
    {
        valor = vida;
    }
}
