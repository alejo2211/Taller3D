using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Enemigo : MonoBehaviour
{
    public Estados estado;
    public float distanciaSeguir;
    public float distanciaAtacar;
    public float distanciaEscapar;
    public float distancia;
    public bool vivo = true;
    public Transform target;
    public bool autoseleccionarTarget = true; 

    public void Awake()
    {
        if (autoseleccionarTarget)
          target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CalcularDistancia());
    }
    private void LateUpdate()
    {
        CheckEstado();
    }
    private void CheckEstado()
    {
        switch (estado)
        {
            case Estados.Idle:
                EstadoIdle();
                break;
            case Estados.Perseguir:
                EstadoPerseguir();
                break;
            case Estados.Atacar:
                EstadoAtacar();
                break;
            case Estados.Morir:
                EstadoMuerto();
                break;
            default:
                break;
        }
    }
    public void CambiarEstado(Estados nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case Estados.Idle:
                break;
            case Estados.Perseguir:
                break;
            case Estados.Atacar:
                break;
            case Estados.Morir:
                vivo = false;
                break;
            default:
                break;
        }
        estado = nuevoEstado;
    }

    public virtual void EstadoIdle() 
    {
        if (distancia < distanciaSeguir)
        {
            CambiarEstado(Estados.Perseguir);
        }
    }
    public virtual void EstadoAtacar()
    {
        if
            (distancia > distanciaAtacar + 0.4f)
        {
            CambiarEstado(Estados.Perseguir);
        }
    }
    public virtual void EstadoPerseguir()
    {
        if (distancia < distanciaAtacar)
        {
            CambiarEstado(Estados.Atacar);
        }
        else if (distancia > distanciaEscapar)
        {
            CambiarEstado(Estados.Idle);
        }
    }
   public virtual void EstadoMuerto()
    {

    }
    IEnumerator CalcularDistancia()
    {
        while (vivo)
        {
            if (target != null)
            {
                distancia = Vector3.Distance(transform.position, target.position);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
     


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaSeguir);
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaAtacar);
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, Vector3.up, distanciaEscapar);
    }
#endif
    private void OnDrawGizmos()
    {
        int icono = (int)estado;
        icono++;
        Gizmos.DrawIcon(transform.position + Vector3.up * 2f, "0" + icono + ".png",false);
    }

    
}
public enum Estados
{
    Idle = 0,
    Perseguir = 1,
    Atacar = 2,
    Morir = 3
}