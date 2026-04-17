using UnityEngine;

public class Curacion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AgentModel stats = other.GetComponent<AgentModel>();
            if (stats != null) {
                stats.Curar(10);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
    }
}
