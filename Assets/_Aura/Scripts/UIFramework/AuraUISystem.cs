using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aura
{
    public class AuraUISystem : MonoBehaviour
    {
        //reference to all the screens
        public AuraUIScreen[] screens;
        public AuraUIScreen firstScreen;
        //reference to the current screen
        private AuraUIScreen currentScreen;
        //reference to the previous screen
        private AuraUIScreen previousScreen;
        //reference to the first screen

        public UnityEvent OnSwitchScreens = new UnityEvent();

        private void Start()
        {
            screens = GetComponentsInChildren<AuraUIScreen>(true);
         
            SwitchScreens(firstScreen);
        }

        public void SwitchScreens(AuraUIScreen aScreen)
        {
            if (currentScreen)
            {
                //close it
                currentScreen.CloseScreen();
                //make it the previous screen
                previousScreen = currentScreen;
            }
            currentScreen = aScreen;
            currentScreen.gameObject.SetActive(true);
            //call the start method on it
            //let interested listeners know that we have switched screens
            OnSwitchScreens?.Invoke();
        }

        public void GoToPreviousScreen()
        {
            Debug.Log("in Go to previous screen");
            if(previousScreen)
            SwitchScreens(previousScreen);
        }

        public void TurnOffAllScreens()
        {
            Debug.Log("inside TurnOffAllScreens");
            foreach (var aScreen in screens)
            {
                aScreen.gameObject.SetActive(false);
            }
        }
    } 
}
