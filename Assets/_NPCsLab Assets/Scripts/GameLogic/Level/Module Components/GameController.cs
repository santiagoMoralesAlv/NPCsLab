using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Core;


namespace GameLogic.Levels
{
    public class GameController : MonoBehaviour
    {

        public static GameController control;       
        public static GameController Control => control;

        public bool doneTutorial;
        void Awake()
        {
            doneTutorial = false;
            if (control == null)
            {
                DontDestroyOnLoad(gameObject);
                control = this;
            }
            else if (control != this)
            {
                Destroy(gameObject);
            }
            
        }

        public void Save()
        {
            BinaryFormatter binFor = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/hola.quehace");
            Keeper keeper = new Keeper();

            keeper.tutorialHecho = doneTutorial;

            binFor.Serialize(file, keeper);
            file.Close();

            Debug.Log("Tutorial hecho");
        }

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/hola.quehace"))
            {
                BinaryFormatter binFor = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/hola.quehace", FileMode.Open);
                Keeper keeperleido = (Keeper)binFor.Deserialize(file);
                file.Close();

                Debug.Log("Tutorial jugado: " + keeperleido.tutorialHecho);

            }
                    

        }
    }

    [Serializable]
    class Keeper
    {
        public bool tutorialHecho=false;
    }
}

