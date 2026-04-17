using Unity.VisualScripting;
using UnityEngine;

public class VelocidadBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AgentModel stats = other.GetComponent<AgentModel>();
            stats.VelocidadX2();

        }
    }
}
