using UnityEngine;

public class Escudo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si quien entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Busca el AgentModel del jugador
            AgentModel agentModel = other.GetComponent<AgentModel>();

            // Si existe, activa el escudo
            if (agentModel != null)
            {
                agentModel.ActivarEscudo();
            }

            // Destruye el pickup
            Destroy(gameObject);
        }
    }
}
