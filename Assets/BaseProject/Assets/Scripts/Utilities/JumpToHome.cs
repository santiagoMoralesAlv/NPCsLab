using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (Core.instance == null) {
            SceneManager.LoadScene("Home3D");
        }
    }

}
