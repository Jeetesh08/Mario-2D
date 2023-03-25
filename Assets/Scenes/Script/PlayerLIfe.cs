using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLIfe : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    public GameObject gameOverMenu;

    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")){
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play(); 
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        gameOverMenu.SetActive(true);

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
