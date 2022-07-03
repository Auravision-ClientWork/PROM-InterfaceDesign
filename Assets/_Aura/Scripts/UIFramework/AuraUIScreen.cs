using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Aura
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Animator))]
    public class AuraUIScreen : MonoBehaviour
    {
        Animator animator;

        public Selectable startSelectable;

        public UnityEvent OnStartScreen = new UnityEvent();
        public UnityEvent OnCloseScreen = new UnityEvent();

        private void Awake()
        {
            animator = GetComponent<Animator>();
            gameObject.SetActive(false);
        }

        public void StartScreen()
        {
            EventSystem.current.SetSelectedGameObject(startSelectable.gameObject);

            OnStartScreen?.Invoke();

            HandleAnimation("show");
        }

        public void CloseScreen()
        {
            Debug.Log("inside CloseScreen()");
            gameObject.SetActive(false);
            OnCloseScreen?.Invoke();
            HandleAnimation("hide");
        }

        private void HandleAnimation(string aTrigger)
        {
            animator.SetTrigger(aTrigger);
        }
    }
}
