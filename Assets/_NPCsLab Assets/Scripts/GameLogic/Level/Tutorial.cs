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
        [SerializeField] private Text textComp;
        [SerializeField] private Text textSecond;
        private string text,secondaryText;
        public int state = 0;
        private float nextTextCounter;
        private bool cumplido = false;
        [SerializeField] private float nextTextEvery;

        public void Awake()
        {
          // PlayerPrefs.SetInt("TutorialHasPlayed", 0);
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
                        textComp.text = StartingTutorial(out secondaryText);
                        textSecond.text = secondaryText;
                        break;
                    case 1:
                        textComp.text = JumpingCheck(out secondaryText);
                        textSecond.text = secondaryText;
                        break;
                    case 2:
                        textComp.text = SlidingCheck(out secondaryText);
                        textSecond.text = secondaryText;
                        break;
                    case 3:
                        textComp.text = LastMessage(out secondaryText);
                        textSecond.text = secondaryText;
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

                if (CharacterMov.Instance.isVark)
                {
                    textComp.text = "¿De nuevo en el principio Vark?, concentrate mas, asi nunca saldras de aqui...";
                    textSecond.text = "";
                }
                else
                {
                    textComp.text = "¿Otra vez por aqui Dummy?, te falta odio zazuque, asi nunca encontraras a Vark...";
                    textSecond.text = "";
                }
                StartCoroutine("troll");
            }


        }

        IEnumerator troll()
        {
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(false);
               
        }



        public string StartingTutorial(out string secondaryText)
        {
            secondaryText = "";
            

            if (nextTextCounter < 2 * nextTextEvery  && nextTextCounter >= nextTextEvery )
            {
                if (CharacterMov.Instance.isVark)
                {
                    text = "Saludos Vark, esperamos que escapes con exito, pero primero deberas aprender lo basico";
                }
                else
                {
                    text = "Saludos Dummy, esperamos que encuentres a Vark, pero primero deberas aprender lo basico";
                }
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

            secondaryText = "";
            return text;
        }

        public string JumpingCheck(out string secondaryText)
        {
#if UNITY_ANDROID
            
            secondaryText = "Desliza hacia arriba";
#else
            secondaryText = "Clic izquierdo";

            #endif
            
            if (nextTextCounter < 2 * nextTextEvery && nextTextCounter >= nextTextEvery)
            {
                
                text = "Puedes saltar para evitar obstaculos y tomar otros caminos";
                
                cumplido = false;
            }
            else if (nextTextCounter < nextTextEvery && cumplido == false)
            {
                text = "esquiva estos obstaculos, recoge monedas y acostumbrate al salto";
                nextTextCounter = nextTextEvery - 0.1f;
                 if (CharacterMov.Instance.jumping >= 10 )
                 {
                     cumplido = true;
                 }
            }
            else if (nextTextCounter < nextTextEvery && cumplido == true)
            {
                text = "Muy bien!";
            }
            if (nextTextCounter < 0)
            {
                state = 2;
                PassText();
            }

            return text;

        }

        public string SlidingCheck(out string secondaryText)
        {
            
#if UNITY_ANDROID
            
            secondaryText = "Desliza con el dedo hacia abajo";
#else
            secondaryText = "Clic derecho para deslizar";

#endif
            
            if (nextTextCounter < 2 * nextTextEvery && nextTextCounter >= nextTextEvery)
            {
                text = "Ahora tendras que deslizarte";
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
                text = "Estas listo!";
            }
            if (nextTextCounter < 0)
            {
                state = 3;
                PassText();
            }

            return text;
        }

        public string LastMessage(out string secondaryText)
        {
            secondaryText = "";
            
            if (nextTextCounter < 2 * nextTextEvery && nextTextCounter >= nextTextEvery)
            {
                text = "Ahora ve a buscar a tu familia, el doctor estara feliz por ti";
                cumplido = true;
                nextTextCounter = nextTextEvery - 0.1f;

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
  
