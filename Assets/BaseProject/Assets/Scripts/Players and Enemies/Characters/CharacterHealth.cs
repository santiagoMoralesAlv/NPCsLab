using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour, PersonajeDestruible
{
    public UnityAction updateHealth;

    public int currentHealth, maxHealth;
    public float invencibleLenght;
    public float invencibleCounter;

    public GameObject deathEffect;
    public GameObject DeathEffect
    {
        get { return deathEffect; }
    }

    // Start is called before the first frame update
    void Awake()
    {

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (invencibleCounter > 0)
        {
            invencibleCounter -= Time.deltaTime;
        }
    }
    public void DealTotalDamage()
    {
        currentHealth = 0;
        Dead();
        updateHealth();


        LevelManager.instance.DeadCharacters();
    }

    public void DealDamage()
    {
        if (invencibleCounter <= 0 && !LevelManager.instance.invulneravility)
        {

            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Dead();


                LevelManager.instance.DeadCharacters();
            }
            else
            {
                invencibleCounter = invencibleLenght;
            }
            updateHealth();
        }
    }

    public void Dead()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
    }

    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        updateHealth();
    }
}
