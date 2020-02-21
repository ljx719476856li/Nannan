using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableCursor : MonoBehaviour
{
    [SerializeField] float speed = 100;

    RectTransform self;
    bool isHoldingMouse0;

    void Start()
    {
        self = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHoldingMouse0 = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isHoldingMouse0 = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (isHoldingMouse0)
        {
            float delta = Input.GetAxis("Mouse X");
            Vector2 newPos = self.anchoredPosition;
            newPos.x += delta * speed * Time.deltaTime;
            self.anchoredPosition = newPos;
        }
    }
}
