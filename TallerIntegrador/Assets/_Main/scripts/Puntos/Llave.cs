using UnityEngine;

public class Llave : MonoBehaviour
{
    [SerializeField]
    private bool TieneLlave = false;
    [SerializeField]
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.TieneLlave = true;

            Destroy(gameObject);
        }
    }

}
