using UnityEngine;

public class AgentView : MonoBehaviour
{
    public Animator animator;
    

    public void PlayJump()
    {
        animator.SetTrigger("Jump");
    }
    public void SetVelocidad(float velocidad)
    {
        animator.SetFloat("velocidad", velocidad);
    }

    public void SetGrounded(bool grounded)
    {
        animator.SetBool("isGrounded", grounded);
    }
    public void PlayDeath()
    {
        Debug.Log("MURIÓ");
        animator.SetTrigger("Die");
    }


}
