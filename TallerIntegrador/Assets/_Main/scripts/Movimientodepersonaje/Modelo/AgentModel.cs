using UnityEngine;

public class AgentModel : MonoBehaviour
{
    [SerializeField]
    private AgentController _agentController;
    [SerializeField]
    private float _velocidad = 20f;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private AgentView _agentView;


    public void Movimineto()
    {
        _rb.linearVelocity = new Vector3(_agentController.moveValue.x * _velocidad, _rb.linearVelocity.y, _agentController.moveValue.y * _velocidad);
    }

    void Update()
    {
        _agentView.animator.SetFloat("velocidad", _rb.linearVelocity.magnitude);
        Movimineto();
    }
}
