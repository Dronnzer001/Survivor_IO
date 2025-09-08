using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.EventSystems.EventTrigger;

public class movementJoystick : MonoBehaviour
{
    public GameObject ArrowDirecteur;
    public GameObject Gun;
    public GameObject joystick;
    public GameObject joystickBG;

    public float moveSpeed = 5f;
    [HideInInspector] public Vector2 joystickVec; // Accessible from PlayerManager

    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }

    void Update()
    {
        // Arrow & Gun rotation based on joystickVec only
        if (joystickVec == Vector2.zero)
        {
            ArrowDirecteur.SetActive(false);
        }
        else
        {
            ArrowDirecteur.SetActive(true);
            float angle = Mathf.Atan2(-joystickVec.x, joystickVec.y) * Mathf.Rad2Deg;
            ArrowDirecteur.transform.eulerAngles = new Vector3(0, 0, angle);

            if (Gun.activeSelf)
                Gun.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

    public void PointerDown()
    {
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);
        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }
}
