using UnityEngine;
using TMPro;

public class MostrarTextoConEventos : MonoBehaviour
{
    public GameObject textoCanvas;
    public TextMeshProUGUI textoTMP;

    public void MostrarTexto()
    {
        textoTMP.text = "¡Has agarrado el objeto!";
        textoCanvas.SetActive(true);
    }

    public void OcultarTexto()
    {
        textoCanvas.SetActive(false);
    }
}
