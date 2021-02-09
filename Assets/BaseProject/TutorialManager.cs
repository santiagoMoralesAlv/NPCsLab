using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    #region mark of the players
    public GameObject markPlayer1, markPlayer2;
    Vector3 mark1Position, mark2Position;
    public float y;
    #endregion

    public GameObject[] captions;
    public GameObject barrer;
    public int state;

    // Start is called before the first frame update
    void Start()
    {
        state = 1;

    }

    // Update is called once per frame
    void Update()
    {
        #region Update mark of the players
        mark1Position = Player.instancePlayer1.Character.transform.position;
        mark2Position = Player.instancePlayer2.Character.transform.position;

        markPlayer1.transform.position = new Vector3(mark1Position.x,mark1Position.y+y,mark1Position.z);
        markPlayer2.transform.position = new Vector3(mark2Position.x, mark2Position.y + y, mark2Position.z);
        #endregion
        if (state == 0)
        {
            captions[0].SetActive(false);
            captions[1].SetActive(false);
            barrer.SetActive(false);
        }
        if (state == 1)
        {
            Player.instancePlayer2.Character.GetComponent<CharacterMove>().CanMove = false;
            if(Player.instancePlayer1.Character.GetComponent<CharacterMove>().Direccion.magnitude > 1.0f)
            {
                state = 2;
            }
        }
        if (state == 2)
        {
            Player.instancePlayer2.Character.GetComponent<CharacterMove>().CanMove = true;
            captions[0].SetActive(false);
            captions[1].SetActive(true);
            if (Player.instancePlayer2.Character.GetComponent<CharacterMove>().Direccion.magnitude > 1.0f)
            {
                state = 0;
            }
        }
    }
}
