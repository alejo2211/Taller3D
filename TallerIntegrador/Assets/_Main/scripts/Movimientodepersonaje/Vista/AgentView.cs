using UnityEngine;

public class AgentView : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    AgentModel model;
     void Update()
    {
        //animator.SetFloat("velocidad", model._rb.linearVelocity.magnitude);
        //animator.SetBool("isGrounded", model._estaEnSuelo);
        //animator.SetFloat("velocidadY", model._rb.linearVelocity.magnitude);
    }
}
