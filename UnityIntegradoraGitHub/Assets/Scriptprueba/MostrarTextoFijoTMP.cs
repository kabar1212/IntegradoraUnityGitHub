using UnityEngine;
using TMPro;

public class MostrarTextoConEventos : MonoBehaviour
{
    public GameObject textoCanvas;
    public TextMeshProUGUI textoTMP;

    public void MostrarTexto()
    {
        textoTMP.text = "¡Oscar es gay";
        textoCanvas.SetActive(true);
    }

    public void OcultarTexto()
    {
        textoCanvas.SetActive(false);
    }
}
