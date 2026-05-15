using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class eskeleto : Enemigo
{
    private NavMeshAgent agente;
    public Animator animaciones;

    private void Awake()
    {
        base.Awake();
        agente = GetComponent<NavMeshAgent>();
    }

    public override void EstadoIdle()
    {
        base.EstadoIdle();
        if (animaciones != null) 
        animaciones.SetFloat("velocidad", 0);
        animaciones.SetBool("atacando", false);
        agente.SetDestination(transform.position);
    }

    public override void EstadoPerseguir()
    {
        base.EstadoPerseguir();
        if (animaciones != null)
        animaciones.SetFloat("velocidad", 1);
        animaciones.SetBool("atacando", false);
        agente.SetDestination(target.position);
    }
    public override void EstadoAtacar()
    {
        base.EstadoAtacar();
        if (animaciones != null)
        animaciones.SetFloat("velocidad", 0);
        animaciones.SetBool("atacando", true);
        agente.SetDestination(transform.position);
        transform.LookAt(target, Vector3.up);   
    }
    override public void EstadoMuerto()
    {
        base.EstadoMuerto();
        if (animaciones != null)
        animaciones.SetBool("vivo", false);
        agente.enabled = false;
    }
}
