using UnityEngine;
using TMPro;
public class Disparo_Total : MonoBehaviour
{
    public int contadorDisparos = 0;
    public TextMeshProUGUI t_total_disparos;
    private void Start()
    {
        ControlesPlayer.Instance.onShoot.AddListener(ContarDisparo);
    }

    public void ContarDisparo()
    {
        contadorDisparos++;
        // Puedes hacer cualquier otra cosa que necesites con el contador de disparos
    }

    public void T_disparo_total()
    {
        t_total_disparos.text = contadorDisparos.ToString();
    }
}
