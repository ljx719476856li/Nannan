using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMgr : MonoBehaviour
{

    public float turnSpeed = 10f;
    public float walkSpeed = 1f;
    public float runSpeed = 5f;
    public KeyCode sprintJoystick = KeyCode.JoystickButton2;
    public KeyCode sprintKeyboard = KeyCode.LeftShift;

    private float turnSpeedMultiplier;
    private bool isSprinting = false;
    private Animator anim;
    private Vector3 targetRotation;
    private Vector3 targetDirection;
    private Vector2 input;
    private Quaternion freeRotation;
    private Camera mainCamera;
    private Rigidbody rig;
    private float lastInputX;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
        rig = GetComponent<Rigidbody>();
        lastInputX = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        isSprinting = ((Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && input != Vector2.zero);
        anim.SetBool("Run", isSprinting);
        anim.SetBool("Walk", input != Vector2.zero);

        UpdateTargetRotation();
        if (input != Vector2.zero)
        {
            if ((Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)))
            {
                transform.position=Vector3.Slerp(transform.position, transform.position + targetDirection, runSpeed * Time.deltaTime);

            }
            else
            {
                transform.position = Vector3.Slerp(transform.position, transform.position + targetDirection, walkSpeed * Time.deltaTime);
            }
        }
        
        Vector3 lookDirection = targetRotation.normalized;
        freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
        var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
        var eulerY = transform.eulerAngles.y;

        if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
        var euler = new Vector3(0, eulerY, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
        
    }

    public virtual void UpdateTargetRotation()
    {

        turnSpeedMultiplier = 1f;
        var forward = mainCamera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        
        //get the right-facing direction of the referenceTransform
        var right = mainCamera.transform.TransformDirection(Vector3.right);
        if (input.x > 0)
        {
            targetRotation = forward;
            lastInputX = 1;
        }
        else if (input.x < 0)
        {
            targetRotation = -forward;
            lastInputX = -1;
        }
        else
        {
            targetRotation = forward*lastInputX;
        }
        targetDirection = forward * input.y + right * input.x;
        if (targetDirection.magnitude > 1)
            targetDirection.Normalize();

    }
}
