using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] float m_offsetAbove;
    [SerializeField] float m_offsetBehind;
    [SerializeField] float m_maxLookUp, m_maxLookDown;
    [SerializeField] float m_minZ, m_maxZ;
    [SerializeField] float m_lookSensitivity;
    //reference to input from touch
    TouchInputController m_TouchInputController;
    //reference to camera target (in this case the player)
    Vector3 m_cameraTarget;
    //reference to the player Gameobject
    GameObject m_player;

    //cache rotation about x axis(left to right on mouse)
    float m_rotationX;
    //cache rotation about y axis(up and down on mouse)
    float m_rotationY;

    public Vector2 m_moveInput { get; private set; }

    private void Awake()
    {
        m_TouchInputController = FindObjectOfType<TouchInputController>();
    }
    private void OnEnable()
    {
        //register to listen for touch input
        m_TouchInputController.OnTouchDrag += SetMoveInput;
    }
    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        m_cameraTarget = m_player.transform.position;
        m_cameraTarget.y += m_offsetAbove;


        m_rotationX += m_moveInput.x * m_lookSensitivity;
        m_rotationY -= m_moveInput.y * m_lookSensitivity;
        m_rotationY = Mathf.Clamp(m_rotationY, m_maxLookUp, m_maxLookDown);

    }

    private void LateUpdate()
    {
        //create a quaternion for camera rotation
        Quaternion cameraRotation = Quaternion.Euler(m_rotationY, m_rotationX, 0f);

        Vector3 offset = new Vector3(0, 0, -m_offsetBehind);

        transform.position = m_cameraTarget + cameraRotation * offset;

        transform.LookAt(m_cameraTarget);
    }

    private void SetMoveInput(Vector2 incomingInput)
    {
        m_moveInput = incomingInput;
    }
}
