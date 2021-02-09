using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : MonoBehaviour
{
    public UnityAction launchedSkill;

    protected CharacterMove character;
    protected Animator anim;


    virtual protected void Awake()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<CharacterMove>();

        PlayerStatsManager.instance.UpdatedStats += LevelUpUpgrades;
        LevelUpUpgrades();
    }

    void Update()
    {
        PlayerInput();
    }

    abstract protected void PlayerInput();

    private void LevelUpUpgrades()
    {
        //hay un try catch pq habia un bug raro, por el momento esto deberia de servir aunque no es muy seguro si el bug sigue existiendo
        try
        {
            anim.SetFloat("LevelUp", PlayerStatsManager.instance.CharactersLevel);
        }
        catch
        {
            //si aparece el bug se desuscribe el personaje del evento
            PlayerStatsManager.instance.UpdatedStats -= LevelUpUpgrades;
        }
    }
}
