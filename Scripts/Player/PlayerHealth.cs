using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public static int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSped = 5;
    public Color flashColour = new Color(1, 0, 0, 1);

    Animator anim;
    AudioSource playerAudio;
    PlayerController pc;
    PlayerShooting ps;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        pc = GetComponent<PlayerController>();
        ps = GetComponentInChildren<PlayerShooting>();
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (damaged)
            damageImage.color = flashColour;
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSped * Time.deltaTime);
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play();
        if (currentHealth <= 0 && !isDead)
            Death();
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        ps.DisableEffects();
        playerAudio.clip = deathClip;
        playerAudio.Play();
        ps.enabled = false;
        pc.enabled = false;
    }
}