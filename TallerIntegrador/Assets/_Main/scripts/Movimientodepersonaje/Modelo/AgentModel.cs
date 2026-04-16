using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private PlayerStats _playerStats;
    [SerializeField]
    private ParticleSystem sangreParticula;
    [SerializeField] 
    private ParticleSystem escudoParticula;
    public bool _estaEnSuelo;
    public void Saltar()
    {
        _agentView.animator.SetTrigger("Jump");
        _rb.linearVelocity = new Vector3(
            _rb.linearVelocity.x,
            0,
            _rb.linearVelocity.z
        );
        _rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.Impulse);
    }
    public void Caminar()
    {
        _agentView.animator.SetFloat("velocidad", _rb.linearVelocity.magnitude);
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
    }
    public void Movimineto()
    {
       Caminar();
        if (_agentController.jumpPressed && _estaEnSuelo)
        {
            Saltar();
        }
    }

    public void Morir()
    {
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        _agentView.PlayDeath();
        _agentController.enabled = false;
        StartCoroutine(MuerteCoroutine());
    }

    public void RecibirDaño(float daño)
    { 
        _playerStats.CausarDaño(daño);
        if (_playerStats.vidaActual <= 0)
        {
            Morir();
        }
        if (sangreParticula != null && _playerStats.chalecoActivo == false)
        {
            sangreParticula.Play();
        }
        if(_playerStats.chalecoActivo)
        {
            if (escudoParticula != null)
            {
                escudoParticula.Play();
            }
            _playerStats.QuitarEscudo();
        }
    }
    public IEnumerator MuerteCoroutine()
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(2.5f);

        // Reinicia la escena actual
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }

    void Update()
    {
        _agentView.animator.SetBool("isGrounded", _estaEnSuelo);
        Movimineto();
    }
    public void SetGrounded(bool value)
    {
        _estaEnSuelo = value;
    }

}



