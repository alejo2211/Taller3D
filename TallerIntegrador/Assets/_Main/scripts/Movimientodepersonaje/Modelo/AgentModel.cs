using UnityEngine;

public class AgentModel : MonoBehaviour
{
    [SerializeField]
    private AgentController _agentController;
    [SerializeField]
    private float _velocidad = 20f;
    [SerializeField]
    public Rigidbody _rb;
    [SerializeField]
    private AgentView _agentView;
    [SerializeField]
    private Transform _agentTrasnform; // el grafico para la rotacion del personaje
    [SerializeField]
    private float _velocidadCorrer;
    [SerializeField]
    private float _fuerzaSalto = 5f;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private float _radioSuelo = 0.2f;
    [SerializeField]
    private LayerMask _sueloLayer;

    public bool _estaEnSuelo;
    public void Movimineto()
    {
        float vel2 = _velocidad;
        if (_agentController.runValue > 0)
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
        if (_agentController.jumpPressed && _estaEnSuelo)
        {
            _rb.linearVelocity = new Vector3(
                _rb.linearVelocity.x,
                0,
                _rb.linearVelocity.z
            );
            _rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.Impulse);
        }
    }

    void Update()
    {
        _agentView.animator.SetFloat("velocidad", _rb.linearVelocity.magnitude);
        _agentView.animator.SetBool("isGrounded", _estaEnSuelo);
        _agentView.animator.SetFloat("velocidadY", _rb.linearVelocity.magnitude);
        Movimineto();
    }
    public void SetGrounded(bool value)
    {
        _estaEnSuelo = value;
    }

}



