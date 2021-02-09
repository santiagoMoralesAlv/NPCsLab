using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : MonoBehaviour
{

    public static Core instance;



    public bool InGame;
    public string SceneToStart;

    //public int numPlayersToStart;
    private static int numPlayers;
    [SerializeField]
    private GameObject[] characterPreFabs;
    [SerializeField]
    private Player[] players;

    public static int NumPlayers { get => numPlayers;}
    public Player[] Players { get => players;}

    private void Awake()
    {
        //Le pone al jugador 1 el arquero por defecto
        UpdateCharacter(0, 1);
        //le pone al jugador 2 el caballero por defecto
        UpdateCharacter(1, 0); 
        
        
        //singleton
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        numPlayers = 0;
    }

    private void Update()
    {
        //vuelve al menu principal
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home3D"); 
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneToStart);
    }

    public void SetNumPlayers(int num) //Usar este script para cambiar el numero de jugadores
    {
        numPlayers = num;
    }


    public void UpdateCharacter(int iPlayer, int iCharacter) 
    {
        players[iPlayer].CharacterPreFab = characterPreFabs[iCharacter];
    }
}
