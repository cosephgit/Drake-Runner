using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player health manager component
// created 18/8/23
// last modified 7/9/23

public class PlayerPawnHealth : MonoBehaviour
{
    [Header("Health settings")]
    [SerializeField] private int healthMax = 5;
    //[SerializeField] private UIHealthBar healthBar;
    [SerializeField] private UIHealthHearts healthHearts;
    [Header("Audio settings")]
    [SerializeField] private AudioClip[] painSounds;
    private int health;

    public void PreTutorial()
    {
        health = healthMax;
        healthHearts.gameObject.SetActive(false);
    }

    public void Initialise()
    {
        healthMax = GameManager.instance.upgrades.upgradeHealthPoints;
        health = healthMax;
        healthHearts.gameObject.SetActive(true);
        healthHearts.Initialise(healthMax);
    }

    public void TakeDamage(int damage, bool pain = true)
    {
        health = health - damage;
        healthHearts.ChangeHealth(health);

        AudioManager.instance.SoundPlayVaried(painSounds[Random.Range(0, painSounds.Length)], Vector2.zero);
    }
    public void GainHealth(int heal)
    {
        if (health < healthMax)
        {
            health = health + heal;
            healthHearts.ChangeHealth(health);
        }
    }

    public void FillHealth()
    {
        if (health < healthMax)
        {
            health = healthMax;
            healthHearts.ChangeHealth(health);
        }
    }
    public bool IsAlive()
    {
        return (health > 0);
    }
}
