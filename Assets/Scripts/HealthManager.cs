using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public int maxHealth = 100;

    public static int playerHealth;

    Text text;

    public bool isDead;

    public HealthBar healthBar;

    private LifeManager lifeSystem;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void Start()
    {
        text = GetComponent<Text>();

        playerHealth = maxHealth;

        lifeSystem = FindObjectOfType<LifeManager>();

        isDead = false;

        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(playerHealth == 0)
        {
            lifeSystem.TakeLife();
            player.transform.position = respawnPoint.transform.position;
            playerHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            isDead = true;
        }
        isDead = false;
    }

    void OnTriggerEnter(Collider coli)
    {
        if (coli.tag == "Enemy")
        {
            HurtPlayer(25);
        }
    }

    void HurtPlayer(int damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
    }
}
