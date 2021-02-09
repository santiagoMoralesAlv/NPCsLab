using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealBar : MonoBehaviour
{
    public PlayerID id;
    public Slider slider;
    private CharacterHealth health;

    private void Awake()
    {
        if (Core.NumPlayers == 1 && id == PlayerID.Player2) //Si es single player y eesta es la barra de vida del 2do jugador entonces se destruye
        {
            gameObject.SetActive(false);
        }
        else
        {
            LevelManager.instance.Spawned += StartHealthDisplay; //se suscribe al evento para inicializar la barra siempre q se haga respawn de personajes.
        }


    }

    public void UpdateCharacterHealthReference()  //actualiza la referencia
    {
        if (id == PlayerID.Player1)
        {
            health = Player.instancePlayer1.Character.GetComponent<CharacterHealth>();
        }
        else
        {
            health = Player.instancePlayer2.Character.GetComponent<CharacterHealth>();
        }
    }

    public void StartHealthDisplay() //inicializa las barras cuando se inicia el juego o cuando se hace respawn
    {
        UpdateCharacterHealthReference(); //llama el evento de arriba, actualiza la referencia

        health.updateHealth += UpdateHealthDisplay; //se suscribe a los cambios de vida


        //configura los tamaños de la barra de vida
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;
    }

    public void UpdateHealthDisplay() //actualiza los valores de vida
    {
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;
    }
}
