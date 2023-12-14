using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    Animator anim;
    public float restart = 5f;
    float restartTimer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (PlayerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("game over");
            restartTimer += Time.deltaTime;
            if (restartTimer > restart)
            {
                PlayerHealth.currentHealth = 100;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
