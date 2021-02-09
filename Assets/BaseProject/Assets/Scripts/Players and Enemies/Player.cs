using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum PlayerID { 
    Player1,
    Player2
}



public class Player : MonoBehaviour
{
    public static Player instancePlayer1, instancePlayer2;
    [SerializeField]
    private PlayerID id;

    //Inputs, hacer uso de estas entradas para las habilidades
    private string movAxis, jumpAxis, skillAButton, skillBButton;

    private GameObject character, characterPreFab;
    


    public GameObject Character { get => character;}
    public GameObject CharacterPreFab { set => characterPreFab = value; }
    public string MovAxis { get => movAxis; }
    public string JumpAxis { get => jumpAxis; }
    public string SkillAButton { get => skillAButton; }
    public string SkillBButton { get => skillBButton; }

    public void Awake()
    {
        switch (id) {
            case PlayerID.Player1:
                if (instancePlayer1 != null) {
                    Destroy(instancePlayer1.gameObject);
                }
                instancePlayer1 = this;
                break;
            case PlayerID.Player2:
                if (instancePlayer2 != null)
                {
                    Destroy(instancePlayer2.gameObject);
                }
                instancePlayer2 = this;
                break;
        }

        DontDestroyOnLoad(this);
        ConfigInputs();
    }

    private void ConfigInputs() {
        movAxis = "Horizontal" + id.ToString();
        jumpAxis = "Vertical" + id.ToString();
        skillAButton = "SkillA" + id.ToString();
        skillBButton = "SkillB" + id.ToString();
    }

    public void InstanceCharacter() {

        switch (id)
        {
            case PlayerID.Player1:
                character = Instantiate(characterPreFab, CheckpointController.instance.spawnPoint + new Vector3(0.8f, 0, 0.8f), Quaternion.identity);
                break;
            case PlayerID.Player2:

                character = Instantiate(characterPreFab, CheckpointController.instance.spawnPoint + new Vector3(-0.8f, 0, -0.8f), Quaternion.identity);
                break;
            default:
                break;
        }

        character.GetComponent<CharacterMove>().Player = this;
    }


}
