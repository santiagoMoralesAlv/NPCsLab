using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectorMode_Manager: MonoBehaviour
{

    [SerializeField]
    private GameObject[] arraycanvas = new GameObject[4];

    private int player;

    public string[] sceneName = new string[2];

    private void Start()
    {

        arraycanvas[0].SetActive(true);
        arraycanvas[1].SetActive(false);
        arraycanvas[2].SetActive(false);
    }

    public void SetMode(int _numPlayers)
    {
        Core.instance.GetComponent<Core>().SetNumPlayers(_numPlayers);

        arraycanvas[0].SetActive(false);
        arraycanvas[1].SetActive(true);
    }


    //antes era Players(), los nombres van con verbos
    public void SetCharacter(int _indexCharacter)
    {
        try
        {
            Core.instance.GetComponent<Core>().UpdateCharacter(0, _indexCharacter);
            Core.instance.GetComponent<Core>().UpdateCharacter(1, _indexCharacter);
            Core.instance.GetComponent<Core>().UpdateCharacter(2, _indexCharacter);
        }
        catch {
            //Esta excepcion ocurre porque puede estar formandose una partida de 1 jugador y intenta modificar el del tercero
        }

        arraycanvas[1].SetActive(false);
        arraycanvas[2].SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName[0]);
    }

    public void LoadLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
