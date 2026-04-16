using UnityEngine;


public class DañosTrampa : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AgentModel stats = other.GetComponent<AgentModel>();

            if (stats != null)
            {
                stats.RecibirDaño(20f);
            }
        }
    }


}
