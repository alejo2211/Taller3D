using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int puntos = 1;
    public bool TieneLlave = false;

    public void SumarPuntos()
    {
        puntos++;
        if(puntos>=10)
        {
            Destroy(gameObject);
        }
    }
    public void RecogerLlave()
    {
        TieneLlave = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        TieneLlave = true;
        Debug.Log("Ganoo");
    }


}
