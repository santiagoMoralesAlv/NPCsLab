using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelExit : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(LevelManager.instance.EndLevel());
            //SceneManager.LoadScene("YouWin3D");
        }
    }
}
