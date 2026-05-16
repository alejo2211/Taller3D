using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgentModel : MonoBehaviour
{
    [SerializeField]
    private AgentController _agentController;

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
    //[SerializeField]
    //private Transform _groundCheck;
    [SerializeField]
    private LayerMask _sueloLayer;
    [SerializeField]
    public PlayerStats _playerStats;
    [SerializeField]
    private ParticleSystem sangreParticula;
    [SerializeField] 
    private ParticleSystem escudoParticula;
    public bool _estaEnSuelo;
    [SerializeField]
    private UIManager _uiManager;
    public void Saltar() // Este método se encarga de aplicar una fuerza hacia arriba para que el personaje salte, además de activar la animación de salto.

    {
        _agentView.PlayJump(); // Activa la animación de salto
        _rb.linearVelocity = new Vector3(
            _rb.linearVelocity.x,
            0,
            _rb.linearVelocity.z
        );
        _rb.AddForce(Vector3.up * _fuerzaSalto, ForceMode.Impulse); // Aplica una fuerza hacia arriba para saltar
    }
    public void Caminar() // Este método se encarga de mover al personaje según la entrada del jugador, actualizando la animación de velocidad y haciendo que el personaje mire hacia la dirección del movimiento.

    {
        _agentView.animator.SetFloat("velocidad", _rb.linearVelocity.magnitude); // Actualiza la animación según la velocidad real
        float vel2 = _playerStats.VelocidadActual;
        if (_agentController.runValue > 0)
        {
            vel2 = _velocidadCorrer; // Decide si el jugador camina o corre
        }
        _rb.linearVelocity = new Vector3(
            _agentController.moveValue.x * vel2,
            _rb.linearVelocity.y,
            _agentController.moveValue.y * vel2); // Aplica el movimiento horizontal sin afectar la velocidad vertical

        if (_agentController.moveValue != Vector2.zero)
        {
            _agentTrasnform.forward = new Vector3(
                _agentController.moveValue.x,
                0,
                _agentController.moveValue.y); // Hace que el personaje mire hacia donde se mueve
        }
    }
    public void Movimineto() // Este método se encarga de procesar el movimiento del personaje, llamando al método de caminar y verificando si el jugador ha presionado el botón de salto para permitir saltar solo si el personaje está en el suelo.
    {
       Caminar();
        if (_agentController.jumpPressed && _estaEnSuelo) // Solo permite saltar si el jugador está en el suelo y ha presionado el botón de salto
        {
            Saltar();
        }
    }

    public void Morir() // Este método se encarga de manejar la muerte del jugador
    {
        _rb.linearVelocity = Vector3.zero;
        _rb.isKinematic = true;
        _agentView.PlayDeath();
        _agentController.enabled = false;
        StartCoroutine(MuerteCoroutine());
    }
    public void Curar(float cantidad) // Este método se encarga de curar al jugador en una cantidad específica
    {
        _playerStats.Vida(10);
    }

    public void VelocidadX2()
    {
        print("multiplicado");
        _playerStats.MultiplicarVelocidad(2);

    }

    public void RecibirDaño(float daño) // Reduce la vida y verifica si el jugador muere, además de reproducir partículas de sangre o escudo según corresponda
    { 
        _playerStats.CausarDaño(daño);
        if (_playerStats.vidaActual <= 0)
        {
            Morir();
        }  //Si la vida llega a 0  muere
        if (sangreParticula != null && _playerStats.chalecoActivo == false)
        {
            sangreParticula.Play(); // Reproduce partículas de sangre si el jugador recibe daño sin el chaleco activo
        }
        if(_playerStats.chalecoActivo)
        {
            if (escudoParticula != null)
            {
                escudoParticula.Play(); // Reproduce partículas de escudo si el jugador recibe daño con el chaleco activo
            }
            _playerStats.QuitarEscudo(); // El chaleco se desactiva después de absorber un golpe, lo que significa que el jugador solo puede bloquear un ataque con el chaleco antes de que se rompa
            _uiManager.MostrarMensaje("¡El escudo se ha roto!");

        }
    }
    public void ActivarEscudo()
    {
        _playerStats.ColocarEscudo(1);

        _uiManager.MostrarMensaje("🛡️ Escudo activado");
    }

    public IEnumerator MuerteCoroutine() // Esta corrutina se encarga de esperar un tiempo después de la muerte del jugador antes de reiniciar la escena, lo que permite que se reproduzca la animación de muerte y cualquier efecto visual asociado antes de que la escena se reinicie
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(2.5f);

        // Reinicia la escena actual
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }// 

    void Update()
    {
        _agentView.animator.SetBool("isGrounded", _estaEnSuelo); // Actualiza la animación de estar en el suelo
        Movimineto();   // Llama al método de movimiento en cada frame para procesar la entrada del jugador y actualizar la posición del personaje
    }
    public void SetGrounded(bool value)
    {
        _estaEnSuelo = value;
    }

}



