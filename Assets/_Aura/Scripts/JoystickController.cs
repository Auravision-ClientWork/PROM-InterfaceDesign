using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler
{

    //get drag info
    //get finger up info
    //store info as a vector2
    //let interested listeners know

    [SerializeField] RectTransform joystickKnobTransform;

    private Vector2 anchoredPosition;

    #region Interface implementations

    private Vector2 startPosition;

    private void Start()
    {
        startPosition = joystickKnobTransform.anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
      //turn joystick anchored position to read from center of transform
      RectTransformUtility.ScreenPointToLocalPointInRectangle(
          joystickKnobTransform,
          eventData.position,
          null, out anchoredPosition);

        Debug.Log(anchoredPosition);
        joystickKnobTransform.anchoredPosition = anchoredPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        anchoredPosition = startPosition;
        joystickKnobTransform.anchoredPosition = anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
    #endregion
}
