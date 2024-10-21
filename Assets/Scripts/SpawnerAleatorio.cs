using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAleatorio : MonoBehaviour
{
    public Transform spawnPosition;
    public List<GameObject> prefabsVariados;

    public void SpawnearAleatorio()
    {
        if (prefabsVariados.Count == 0)
        {
            Debug.LogError("La lista de prefabs está vacía.");
            return;
        }

        int indiceAleatorio = Random.Range(0, prefabsVariados.Count);
        GameObject prefabSeleccionado = prefabsVariados[indiceAleatorio];
        Instantiate(prefabSeleccionado, spawnPosition.position, spawnPosition.rotation);
    }
}
