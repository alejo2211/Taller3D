using UnityEngine;

public class DetectorSuelo : MonoBehaviour

{
    public AgentModel model;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Suelo"))
        {
            
            model._estaEnSuelo = true;
            model.SetGrounded(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Suelo"))
        {
          model._estaEnSuelo = false;
          model.SetGrounded(false);
        }
    }
}
