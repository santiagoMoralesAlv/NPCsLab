using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Text gemText;
    public Text level;
    public Text lives;

    public Text keysNeed;
    

    public Image fadeScreen;
    public float fadeSpeed;

    public GameObject levelCompleteText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayerStatsManager.instance.UpdatedStats += UpdateStats;
        UpdateStats();
    }


    public void UpdateStats()
    {
        gemText.text = PlayerStatsManager.instance.GemsCollected.ToString()+" / "+PlayerStatsManager.instance.GemsNeededToLevelUp.ToString();
        level.text = PlayerStatsManager.instance.CharactersLevel.ToString();
        lives.text = PlayerStatsManager.instance.Lives.ToString();
        keysNeed.text = LevelEndActived.levelinstance.needKeys.ToString() + " / " + PlayerStatsManager.instance.KeysCollect.ToString();
    }

    public IEnumerator FadeToBlack()
    {
        while (fadeScreen.color.a != 1f)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            yield return null;
        }
    }

    public IEnumerator FadeFromBlack()
    {
        while (fadeScreen.color.a != 0f)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, (fadeSpeed*3) * Time.deltaTime));
            yield return null;
        }
    }
}
