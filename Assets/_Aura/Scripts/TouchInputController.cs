using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour
{

    [field: SerializeField] public Vector2 moveDirection { get; private set; }

    [SerializeField] private Vector2 initialTouchPos;
    [SerializeField] private Vector2 dragTouchPos;

    public event Action<Vector2> OnTouchDrag;

    private void Update()
    {
     
        GetTouchPositions();

        moveDirection =  CalculateMoveDirection(initialTouchPos, dragTouchPos);

        //send moveDirection out to listeners
        OnTouchDrag?.Invoke(moveDirection);
    }

    private void GetTouchPositions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            dragTouchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            initialTouchPos = Vector2.zero;
            dragTouchPos = Vector2.zero;
        }

    }

    private Vector2 CalculateMoveDirection(Vector2 initialTouchPos, Vector2 dragTouchPos)
    {
        Vector2 newMoveDirection = Vector2.zero;

        moveDirection = dragTouchPos - initialTouchPos;

        float absoluteValueOfX = 0f;
        float absoluteValueOfY = 0f;

        //Is the finger dragging to the right or to the left? >0 = right, <0 = left
        //set x value to the absolute value -1 0r 1 respectively
        if (moveDirection.x < 0)
        {
            absoluteValueOfX = -1;
        }
        else if (moveDirection.x > 0)
        {
            absoluteValueOfX = 1;
        }


        //Is the finger dragging up or down >0 = up, <0 = down
        //set y value to the absolute value -1 0r 1 respectively

        if (moveDirection.y < 0)
        {
            absoluteValueOfY = -1;
        }
        else if (moveDirection.y > 0)
        {
            absoluteValueOfY = 1;
        }

      //cache this value and return
      newMoveDirection = new Vector2(absoluteValueOfX, absoluteValueOfY);
      return newMoveDirection;
    }
}
