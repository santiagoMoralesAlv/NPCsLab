using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.Events;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public UnityAction Spawned, DestroyCharacters;
    private bool isFirstSpawn = true;
    public float waitToRespawn;
    public string nextLevel;


    [SerializeField]
    private CinemachineTargetGroup targetGroup; //Esto esta hecho para seguir 2 gameobjets por la camara, en el evento DeadCharacters hay un ejemplo de como se usa
    public Transform[] deadPoints; //son los esqueletos que se quedan en el ultimo lugar de muerte

    public bool invulneravility = true;
    public float invulnerabiltyTime;

    private void Awake()
    {
        instance = this;
    }
    

    void Start()
    {
        StartCoroutine(SpawnCharactersCoroutine());
    }

    private void Update()
    {
        if (invulneravility)
        {
            invulnerabiltyTime += Time.deltaTime;

            if (invulnerabiltyTime > 30)
            {
                invulneravility = false;
            }
        }
    }


    private IEnumerator SpawnCharactersCoroutine()
    {

        // Si es un respawn entonces se hacen unos pasos adicionales
        if (isFirstSpawn)
        {
            //Pone la camara en el primer checkpoint
            targetGroup.m_Targets[0].target = CheckpointController.instance.currentCheckpoint.transform;
            isFirstSpawn = false;
        }
        else {

            //transicion de la pantalla normal a una pantalla en negro
            yield return StartCoroutine(UIController.instance.FadeToBlack());
        }

        //se instancias los personajes y se configuran las camaras
        Player.instancePlayer1.InstanceCharacter(); //instancia personaje
        targetGroup.m_Targets[0].target = Player.instancePlayer1.Character.transform; //lo pone como objetivo de las camaras
        if (Core.NumPlayers == 2) //lo mismo con el 2do jugador
        {
            Player.instancePlayer2.InstanceCharacter();
            targetGroup.m_Targets[1].target = Player.instancePlayer2.Character.transform;
        }

        PlayerStatsManager.instance.UpdatedStats();

        //transicion de la pantalla en negro a la pantalla de juego normal
        yield return StartCoroutine(UIController.instance.FadeFromBlack());

        //Avisa por un evento que los personajes se terminaron de respawnear, el evento del nivel del personaje esta ligado a este
        Spawned();
    }



    public void DeadCharacters() {

        DestroyCharacters();
        //Configura la camara mientras se esta muerto y los esqueletos que señalan el lugar de la muerte
        deadPoints[0].position = Player.instancePlayer1.Character.transform.position; targetGroup.m_Targets[0].target = deadPoints[0];
        Destroy(Player.instancePlayer1.Character); //destruye personaje
        if (Core.NumPlayers == 2)
        {
            deadPoints[1].position = Player.instancePlayer2.Character.transform.position;
            Destroy(Player.instancePlayer2.Character);
            targetGroup.m_Targets[1].target = deadPoints[1];
        }



        // el jugador sigue con vidas ? hacemos respawn o terminarmos el juego
        PlayerStatsManager.instance.LoseOneLive();
        if (PlayerStatsManager.instance.Lives <= 0)
        {
            StartCoroutine(LoseLevel());
        }
        else
        {
            StartCoroutine(SpawnCharactersCoroutine());
        }
    }


    public IEnumerator LoseLevel()
    {
        yield return StartCoroutine(UIController.instance.FadeToBlack());
        SceneManager.LoadScene("YouLose3D");
    }

    public IEnumerator EndLevel()
    {
        UIController.instance.levelCompleteText.SetActive(true);
        yield return StartCoroutine(UIController.instance.FadeToBlack());
        SceneManager.LoadScene(nextLevel);
    }
  
}
