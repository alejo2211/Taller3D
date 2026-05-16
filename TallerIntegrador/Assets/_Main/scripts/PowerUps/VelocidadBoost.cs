using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VelocidadBoost : MonoBehaviour
{
    public float tiempoPowerUp = 5f; // Duración del power-up en segundos
    AgentModel stats;
    [SerializeField]
    private GameObject speedBoostImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stats = other.GetComponent<AgentModel>();
            stats.VelocidadX2();
            Invoke("TerminarPowerUP", tiempoPowerUp);
            speedBoostImage.SetActive(true);
        }
        
    }
   
    public void TerminarPowerUP()
    {
        stats._playerStats.ResetearVelocidad(); // Restablece la velocidad del jugador a su valor original después de que el power-up haya terminado
        speedBoostImage.SetActive(false); 
    }
}
