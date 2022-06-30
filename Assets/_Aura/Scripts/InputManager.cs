using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    Joystick,
    ScreenDrag,

}
public class InputManager : MonoBehaviour
{
    #region Singleton Setup
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;

    }
    #endregion

    //reference to the controllers
    public TouchInputController touchInputController;

    public InputType inputType = InputType.Joystick;

    private void Update()
    {
        switch (inputType)
        {
            case InputType.Joystick:
                //disable TouchController, Enable JoystickController
                break;
            case InputType.ScreenDrag:
                //disable JoystickController, Enable TouchController
                break;
        }
    }
}
