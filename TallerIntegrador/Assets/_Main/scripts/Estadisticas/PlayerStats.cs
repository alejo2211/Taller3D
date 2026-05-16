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
    public void Vida(float cantidad) // Aumenta la vida actual en la cantidad dada, pero no permite que supere la vida máxima
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima) // Evita que la vida actual supere la vida máxima
        {
            vidaActual = vidaMaxima; // Si la vida actual es mayor que la vida máxima, se establece en la vida máxima
        }
    }
    public void MultiplicarVelocidad(float multiplicado)
    {
        print("Resuelto");
        VelocidadActual = VelocidadBase * multiplicado; // Multiplica la velocidad base por un factor dado

    }
    public void ResetearVelocidad()
    {
        VelocidadActual = VelocidadBase; // Restablece la velocidad actual a la velocidad base
    }
    public void ColocarEscudo(float multiplicado) // Activa el chaleco, lo que hace que el jugador no reciba daño mientras el chaleco esté activo
    {
        chalecoActivo = true; // El chaleco se activa, lo que significa que el jugador no recibirá daño mientras el chaleco esté activo. El multiplicado no tiene un efecto directo en el funcionamiento del chaleco, pero podría ser utilizado para ajustar la duración o la resistencia del chaleco si se implementa esa funcionalidad adicional en el futuro.
    }

    public void QuitarEscudo() // Desactiva el chaleco, lo que hace que el jugador vuelva a recibir daño normalmente
    {
        chalecoActivo = false; //

    }
    public void CausarDaño(float amountdaño) // Reduce la vida actual en la cantidad de daño recibida, pero si el chaleco está activo, no se reduce la vida
    {
        if (chalecoActivo)
        {
            return; // Si el chaleco está activo, no se reduce la vida, el daño es absorbido por el chaleco
        }
        vidaActual -= amountdaño; // Reduce la vida actual en la cantidad de daño recibida
        vidaActual = Mathf.Max(vidaActual, 0); // Asegura que la vida actual no sea menor que 0, lo que evita valores negativos de vida

    }
}
