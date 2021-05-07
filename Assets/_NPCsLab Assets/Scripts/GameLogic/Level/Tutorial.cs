using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using GameLogic.Characters;
using GameLogic.Levels;


namespace GameLogic.Levels
{
    public class Tutorial : MonoBehaviour
    {
        private Text textComp;
        private string text;
        public int state = 0;
        private float nextTextCounter;
        private bool cumplido = false;
        [SerializeField] private float nextTextEvery;

        public void Awake()
        {
           // PlayerPrefs.SetInt("TutorialHasPlayed", 0);
            textComp = GetComponent<Text>();
            nextTextCounter = 2 * nextTextEvery;
        }

       
        public void Update()
        {
            if ((GameStatus.Instance.Status == Status.played) && PlayerPrefs.GetInt("TutorialHasPlayed", 0) <= 0) 
            {
                gameObject.SetActive(true);
                nextTextCounter -= Time.deltaTime/1.5f ;
                switch (state)
                {
                    case 0:
                        textComp.text = StartingTutorial();
                        break;
                    case 1:
                        textComp.text = JumpingCheck();
                        break;
                    case 2:
                        textComp.text = SlidingCheck();
                        break;
                    case 3:
                        textComp.text = LastMessage();
                        break;

                    case 4:
                        if (nextTextCounter < nextTextEvery)
                        {
                            PlayerPrefs.SetInt("TutorialHasPlayed", 1);
                            gameObject.SetActive(false);
                        }
                        break;
                }

            }
            else if ((GameStatus.Instance.Status == Status.played) && PlayerPrefs.GetInt("TutorialHasPlayed", 0) ==1)
            {
                gameObject.SetActive(true);
                textComp.text = "¿De nuevo en el principio Vark?, concentrate mas, asi nunca saldras de aqui...";
                StartCoroutine("troll");
            }


        }

        IEnumerator troll()
        {
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(false);
               
        }



        public string StartingTutorial()
        {

            if (nextTextCounter < 2 * nextTextEvery  && nextTextCounter >= nextTextEvery )
            {
                text = "Saludos Vark, esperamos que escapes con exito, pero primero deberas aprender lo basico";
            }
            else if (nextTextCounter < nextTextEvery)
            {
                text = "Vamos a ello";
            }
            
            if (nextTextCounter < 0)
            {
                state = 1;
                PassText();
            }
            return text;
        }

        public string JumpingCheck()
        {

            if (nextTextCounter < 2 * nextTextEvery && nextTextCounter >= nextTextEvery)
            {
                text = "Para saltar desliza hacia arriba";
                cumplido = false;
            }
            else if (nextTextCounter < nextTextEvery && cumplido == false)
            {
                text = "Esquiva estos obstaculos y acostumbrate al salto";
                nextTextCounter = nextTextEvery - 0.1f;
                 if (CharacterMov.Instance.jumping >= 10 )
                 {
                     cumplido = true;
                 }
            }
            else if (nextTextCounter < nextTextEvery && cumplido == true)
            {
                text = "Muy bien";
            }
            if (nextTextCounter < 0)
            {
                state = 2;
                PassText();
            }

            return text;

        }

        public string SlidingCheck()
        {
            if (nextTextCounter < 2 * nextTextEvery && nextTextCounter >= nextTextEvery)
            {
                text = "Ahora tendras que deslizarte, para eso desliza hacia abajo";
                cumplido = false;
            }
            else if (nextTextCounter < nextTextEvery && cumplido == false)
            {
                text = "Pongamoslo a prueba";
                nextTextCounter = nextTextEvery - 0.1f;
                if (CharacterMov.Instance.sliding>= 4)
                {
                    cumplido = true;
                }
            }
            else if (nextTextCounter < nextTextEvery && cumplido == true)
            {
                text = "Muy bien";
            }
            if (nextTextCounter < 0)
            {
                state = 3;
                PassText();
            }

            return text;
        }

        public string LastMessage()
        {
            if (nextTextCounter < 2 * nextTextEvery && nextTextCounter >= nextTextEvery)
            {
                text = "Ahora ve a buscar a tu familia, el doctor estara feliz por ti";
                cumplido = false;
            }
            else if (nextTextCounter < nextTextEvery && cumplido == false)
            {
                text = "Nos veremos pronto";
                nextTextCounter = nextTextEvery - 0.1f;
                cumplido = true;
            }

            if (nextTextCounter < 0)
            {
                state = 4;
                PassText();

            }
            return text;
        }


        public void PassText()
        {
            nextTextCounter = nextTextEvery * 2;
        }
    }
}
  
