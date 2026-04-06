using UnityEngine;

public class AgentView : MonoBehaviour
{
    public enum Animations

    {
        walking,
        run,
        pain,
        heal,
        idle
    }

    [SerializeField]
    public Animator animator;
    Animations animations;



    public void AnimationState()
    {


    }
}
