using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatsManager : MonoBehaviour
{
    public static PlayerStatsManager instance;
    public UnityAction UpdatedStats; //NOTIFICA stats por subidas de nivel, respawn de personajes, gemas colectadas, vidas perdidas, etc

    private static int charactersLevel = 0;
    private int gemsCollected;
    private int keysCollect;
    private int lives, maxLives = 3;
    private int gemsNeededToLevelUp = 3;

    public int CharactersLevel { get => charactersLevel;}
    public int GemsCollected { get => gemsCollected;}
    public int Lives { get => lives; set => lives = value; }
    public int MaxLives { get => maxLives;}
    public int GemsNeededToLevelUp { get => gemsNeededToLevelUp; }
    public int KeysCollect { get => keysCollect;}

    public int velocityBonus;

    private void Awake()
    {
        instance = this;
        maxLives = 3;
        lives = maxLives; 
        
        gemsNeededToLevelUp = (charactersLevel * charactersLevel) + 3;
    }

    private void Start()
    {
        LevelManager.instance.Spawned += UpdatedStats; //actualiza el nivel siempre q se haga respawn pq los personajes de reinician
    }

    public void LoseOneLive() {
        if (!LevelManager.instance.invulneravility)
        {
            lives--;
        }

        UpdatedStats();
    }

    public void CollectGem(int amount) {
        gemsCollected += amount;

         //comprueba si se puede subir de nivel

        if (gemsCollected == gemsNeededToLevelUp)
        {
            charactersLevel++;
            gemsNeededToLevelUp = (charactersLevel* charactersLevel)+3; //se sube nivel con las gemas 3, 6, 12, 24, 48 y asi sucesivamente
            
        
        }


        UpdatedStats();
    }
    public void CollectKey(int cant)
    {
        keysCollect += cant;
        UpdatedStats();
    }

    public void ReceiveHit() {
        velocityBonus += 5;
        UpdatedStats();
    }

}
