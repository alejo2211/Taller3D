using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;
    public float VelocidadBase = 5f;
    public float VelocidadActual;
    public bool chalecoActivo;

    void Start()
    {
        vidaActual = vidaMaxima;
        VelocidadActual = VelocidadBase;
        chalecoActivo = false;
    }
    public void Vida(float cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }
    public void MultiplicarVelocidad(float multiplicado)
    {
        VelocidadActual = VelocidadBase * multiplicado;
    }
    public void ColocarEscudo(float multiplicado)
    {
        chalecoActivo = true;
    }
    public void CausarDaño(float amountdaño)
    {
        if (chalecoActivo)
        {
            return;
        }
        vidaActual -= amountdaño;
        if (vidaActual <0)
            vidaActual =0;
    }
}
