using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_script : MonoBehaviour
{
    Transform tr;
    Rigidbody rg;
    Animator anim;

    public Transform CameraShoulder;
    public Transform CameraHolder;
    private Transform cam;


    private float rotY = 0f;
    private float rotX = 0f;


    public float speed = 200;
    public float rotationSpeed = 25;
    public float minAngle = -70;
    public float maxAngle = 70;
    public float cameraSpeed = 24;


    // Use this for initialization
    void Start()
    {

        tr = this.transform;
        rg = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerControl();
        CameraControl();
        AnimControl();
    }

    private void PlayerControl()
    {

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;


        Vector3 side = speed * deltaX * deltaT * tr.right;
        Vector3 forward = speed * deltaZ * deltaT * tr.forward;

        Vector3 endSpeed = side + forward;

        rg.velocity = endSpeed;
    }

    private void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        float xrot = mouseX * deltaT * rotationSpeed;

        tr.Rotate(0, xrot, 0);

        rotY += mouseY * deltaT * rotationSpeed;
        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);


        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        CameraShoulder.localRotation = localRotation;

        cam.position = Vector3.Lerp(cam.position, CameraHolder.position, cameraSpeed * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, CameraHolder.rotation, cameraSpeed * deltaT);
    }

    private void AnimControl()
    {

    }
}
