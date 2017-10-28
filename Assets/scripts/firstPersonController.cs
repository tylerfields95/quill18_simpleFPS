using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonController : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;

    float verticleRotation = 0;
    public float upDownRange = 60.0f;

	// Use this for initialization
	void Start () {
        //locks cursor to the game
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        //rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticleRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticleRotation = Mathf.Clamp(verticleRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticleRotation, 0, 0);

        //movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);

        speed = transform.rotation * speed;

        CharacterController cc = GetComponent<CharacterController>();

        cc.SimpleMove(speed);

	}
}
