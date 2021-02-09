using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndActived : MonoBehaviour
{
    public static LevelEndActived levelinstance;

    public int needKeys;
    public GameObject door;
    private void Awake()
    {
        levelinstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStatsManager.instance.KeysCollect == needKeys)
        {
            door.SetActive(true);
        }
    }
}
