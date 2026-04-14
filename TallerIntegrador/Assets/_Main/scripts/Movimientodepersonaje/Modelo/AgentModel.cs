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
    [SerializeField]
    private Transform _agentTrasnform; // el grafico para la rotacion del personaje
    [SerializeField]
    private float _velocidadCorrer;




    public void Movimineto()
    {
        float vel2 = _velocidad;
        if (_agentController.runValue>0)
        {
            vel2 = _velocidadCorrer;
        }
        _rb.linearVelocity = new Vector3(
            _agentController.moveValue.x * vel2, 
            _rb.linearVelocity.y, 
            _agentController.moveValue.y * vel2);

        if (_agentController.moveValue != Vector2.zero)
        {
            _agentTrasnform.forward = new Vector3(
                _agentController.moveValue.x,
                0,
                _agentController.moveValue.y);
        }
    }

    void Update()
    {
        _agentView.animator.SetFloat("velocidad", _rb.linearVelocity.magnitude);
        Movimineto();
    }
}
