using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NTC_MenuAndGUISystem
{
    public class MenuManager : MonoBehaviour
    {
        #region singleton
        private static MenuManager instance;

        public static MenuManager Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        public delegate bool Request(bool value);
        public event System.Action e_finishAnimation;
        public event Request e_finishPopup;

        protected Animator m_Animator;
        private Menu animationMenu;
        private List<Menu> menus;

        public Animator Animator
        {
            get
            {
                return m_Animator;
            }

        }
        public Menu AnimationMenu
        {
            get
            {
                return animationMenu;
            }

            set
            {
                animationMenu = value;
            }
        }
        public List<Menu> Menus
        {
            get
            {
                return menus;
            }

            set
            {
                menus = value;
            }
        }

        private void Awake()
        {
            instance = this;
            //ControlGame.Instance.e_StartToLoadScene += CloseAndCleanAll;

            m_Animator = this.GetComponent<Animator>();
            menus = new List<Menu>();
        }

        public void OpenMenu(string t_menuName) {
            Menu menuToOpen =  menus.Find(t_menu => t_menu.MenuName== t_menuName);
            if (menuToOpen != null)
            {
                menuToOpen.SetMenuActive(true);
            }
            else {
                Debug.LogWarning("El menu no existe, validar los nombres");
            }
        }

        public void ForceFinishAnimation() {
            m_Animator.speed = 5;
            MenuManager.Instance.Animator.SetBool("FinishOpenMenu", true);
        }

        public void ReturnToParent(string t_menuName)
        {
            Menu menuToOpen = menus.Find(t_menu => t_menu.MenuName == t_menuName);
            if (menuToOpen != null)
            {
                menuToOpen.ReturnToParent();
            }
            else
            {
                Debug.LogWarning("El menu no existe, validar los nombres");
            }
        }

        public void CloseAndCleanAll()
        {
            Menu.CloseAndCleanAllMenusInControl();
        }

        public void StartOpenAnimation()
        {
            MenuManager.Instance.Animator.SetBool("OpenMenu", true);
            MenuManager.Instance.Animator.SetBool("FinishOpenMenu", false);
        }
        public void StartReturAnimation()
        {
            MenuManager.Instance.Animator.SetBool("ReturnMenu", true);
            MenuManager.Instance.Animator.SetBool("FinishReturnMenu", false);
        }

        public void OpenedAnimation()
        {
            StartCoroutine(OpenAnimationMenu());
            MenuManager.Instance.Animator.SetBool("OpenMenu", false);
        }
        public void ReturnedAnimation()
        {
            StartCoroutine(OpenAnimationMenu());
            MenuManager.Instance.Animator.SetBool("ReturnMenu", false);
        }

        public void FinishOpenAnimation()
        {
            StopAllCoroutines();
            animationMenu.SetMenuActive(false);
            MenuManager.Instance.Animator.SetBool("FinishOpenMenu", true);
            m_Animator.speed = 1;
            e_finishAnimation();
        }
        public void FinishReturnedAnimation()
        {
            StopAllCoroutines();
            animationMenu.SetMenuActive(false);
            MenuManager.Instance.Animator.SetBool("FinishReturnMenu", true);
            m_Animator.speed = 1;
            e_finishAnimation();
        }
        public IEnumerator OpenAnimationMenu() {
            
            yield return new WaitForSeconds(1f);
            animationMenu.SetMenuActive(true);
        }

        public void FinishPopup()
        {
            e_finishPopup(true);
        }
        public void FinishPopup(bool value)
        {
            e_finishPopup(value);
        }

    }
}
