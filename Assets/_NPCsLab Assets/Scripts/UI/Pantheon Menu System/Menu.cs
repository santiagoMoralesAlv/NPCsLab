using UnityEngine;

namespace NTC_MenuAndGUISystem
{

    public class Menu : MonoBehaviour
    {
        #region attributes
        [SerializeField]
        protected string menuName;
        
        public delegate void SetMenusState(bool state);
        public event SetMenusState e_openMenu;
        public event SetMenusState e_closeMenu;
        public static event SetMenusState e_closeAllMenus;

        [SerializeField]
        protected Menu parent;

        [SerializeField] protected bool startInAwake;
            
        protected bool openAnimateMenu=false, returnAnimateMenu;
        [SerializeField]
        protected bool isActiveMenu;
        protected static bool menuSystemOn;

        [SerializeField]
        protected GameObject[] persistentComponents, activeMenuComponents;
        #endregion

        #region properties
        public string MenuName
        {
            get
            {
                return menuName;
            }

        }
        public Menu Parent
        {
            get
            {
                return parent;
            }

        }
        public bool IsActiveMenu
        {
            get
            {
                return isActiveMenu;
            }

        }
        public bool AnimateMenu
        {
            get
            {
                return openAnimateMenu;
            }

        }
        public static bool MenuSystemOn
        {
            get
            {
                return menuSystemOn;
            }

            set
            {
                menuSystemOn = value;
            }
        }
        #endregion

        protected void Awake()
        {
            MenuManager.Instance.Menus.Add(this);
            StartMenu();
        }

        protected void StartMenu()
        {
            if (startInAwake)
            {
                menuSystemOn = true;
                SetMenuActive(true);
            }
            else {
                for (int i = 0; i < persistentComponents.Length; i++)
                {
                    persistentComponents[i].SetActive(false);
                }
                for (int i = 0; i < activeMenuComponents.Length; i++)
                {
                    activeMenuComponents[i].SetActive(false);
                }
            }

            if (parent != null) {
                parent.e_closeMenu += SetMenuActive;
            }
        }
        
        public void SetMenuActive(bool state) //Cambia el estado del menu 
        {
            //Cierra los demas menus activos
            if (state)
            {
                if (parent != null) //si se tiene padre, se minimiza 
                {
                    parent.MinimizeMenu();
                }
                if (!openAnimateMenu)
                {
                    OpenMenu();
                }
                else {
                    StartOpenAnimation();
                }
            }
            else
            {
                CloseMenu();
            }
        }

        public void ReturnActive() //Cambia el estado del menu 
        {
            if (!returnAnimateMenu)
            {
                MaximizeMenu();
            }
            else
            {
                StartReturnAnimation();
            }
        }

        public void StartOpenAnimation()
        {
            MenuManager.Instance.StartOpenAnimation();
            MenuManager.Instance.e_finishAnimation += OpenAnimationFinish;
        }
        public void StartReturnAnimation()
        {
            MenuManager.Instance.StartReturAnimation();
            MenuManager.Instance.e_finishAnimation += ReturnAnimationFinish;
        }

        public void OpenAnimationFinish()
        {
            MenuManager.Instance.e_finishAnimation -= OpenAnimationFinish;
            OpenMenu();
        }
        public void ReturnAnimationFinish()
        {
            MenuManager.Instance.e_finishAnimation -= ReturnAnimationFinish;
            MaximizeMenu();
        }

        private void OpenMenu()
        {
            menuSystemOn = true;
            isActiveMenu = true;
            e_closeAllMenus += SetMenuActive;

            for (int i = 0; i < persistentComponents.Length; i++)
            {
                persistentComponents[i].SetActive(true);
            }
            for (int i = 0; i < activeMenuComponents.Length; i++)
            {
                activeMenuComponents[i].SetActive(true);
            }

            try
            {
                e_openMenu(true);
            }
            catch
            {
                //no existen hijos
            }
        }

        virtual public void DecorateOpenMenu() {

        }

        public void MinimizeMenu() //Cierra un menu
        {
            for (int i = 0; i < activeMenuComponents.Length; i++)
            {
                activeMenuComponents[i].SetActive(false);
            }
        }
        public void MaximizeMenu() //Cierra un menu
        {
            for (int i = 0; i < activeMenuComponents.Length; i++)
            {
                activeMenuComponents[i].SetActive(true);
            }
        }

        private void CloseMenu() //Cierra un menu
        {
            for (int i = 0; i < persistentComponents.Length; i++)
            {
                persistentComponents[i].SetActive(false);
            }
            MinimizeMenu();


            isActiveMenu = false;
            e_closeAllMenus -= SetMenuActive;

            //intenta cerrar los hijos
            try
            {
                e_closeMenu(false);
            }
            catch
            {
                //no existen hijos
            }
        }

        public static void CloseAll() //ciera los menus suscritos al evento restartMenu
        {
            try
            {
                menuSystemOn = false;
                e_closeAllMenus(false);
            }
            catch (System.NullReferenceException e)
            {
                Debug.LogWarning("Sin menus para cerrar");

            }
        }

        public static void CloseAndCleanAllMenusInControl() //Desuscribe todos los menus del evento restartMenu, esto para cuando se cambia de scena 
        {
            CloseAll();
            e_closeAllMenus = null;
        }
        
        public void ReturnToParent() //Vuelve al menu principal 
        {
            this.SetMenuActive(false);

            if (parent != null)
            {
                parent.ReturnActive();
            }
            else {
                menuSystemOn = false;
            }          
        }
        
    }
}
