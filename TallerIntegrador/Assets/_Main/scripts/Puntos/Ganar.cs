using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager = gameManager;
            if(gameManager.TieneLlave)
            {
                SceneManager.LoadScene("Ganar");
            }
        }
    }
}
