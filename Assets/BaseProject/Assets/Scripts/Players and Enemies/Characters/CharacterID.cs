using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CharactersType
{
    Female,
    Police,
    Zombie
}

public class CharacterID : MonoBehaviour
{
    [SerializeField]
    private CharactersType type;
    public CharactersType CharacterType { get => type; set => type = value; }
}
