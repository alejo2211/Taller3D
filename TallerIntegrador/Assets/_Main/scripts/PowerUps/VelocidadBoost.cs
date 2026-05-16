using Unity.VisualScripting;
using UnityEngine;

public class VelocidadBoost : MonoBehaviour
{
    public float tiempoPowerUp = 5f; // Duración del power-up en segundos
    AgentModel stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stats = other.GetComponent<AgentModel>();
            stats.VelocidadX2();
            Invoke("TerminarPowerUP", tiempoPowerUp);
            Destroy(gameObject); // Destruye el power-up después de ser recogido
        }
    }
    public void TerminarPowerUP()
    {
        stats._playerStats.ResetearVelocidad(); // Restablece la velocidad del jugador a su valor original después de que el power-up haya terminado
    }
}
