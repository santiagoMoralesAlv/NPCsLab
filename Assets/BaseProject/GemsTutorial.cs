using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;

public class GemsTutorial : MonoBehaviour
{
    public GameObject gemtext;
    public GameObject wall;
    public GameObject pastTutorial=null;
    int state = 0;
    [SerializeField]
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (state == 1)
        {
            Invoke("ChangeState", 6);
        }
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gemtext.SetActive(true);
            pastTutorial.SetActive(false);
            state = 1;
        }
    }
    private void ChangeState()
    {
        state = 0;
        gemtext.SetActive(false);
        wall.SetActive(false);
        
    }
}
