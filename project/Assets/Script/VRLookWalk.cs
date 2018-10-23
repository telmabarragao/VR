using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{

    public Transform vrCamera;

    public float toggleAngle = 45.0f;

    public float speed = 3.0f;

    public bool moveforward;
    public bool movebackward;

    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveforward = false;
            movebackward = true;
        }
        else if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x > 0.0f)
        {
            moveforward = true;
            movebackward = false;
        }
        else
        {
            moveforward = false;
            movebackward = false;
        }
        if (moveforward == true)
        {
            Vector3 forward = vrCamera.TransformDirection(new Vector3(Vector3.forward.x, Vector3.forward.y, Vector3.forward.z));

            cc.SimpleMove(forward * speed);
        }
        else if (movebackward == true)
        {
            Vector3 backward = vrCamera.TransformDirection(new Vector3(-Vector3.forward.x, Vector3.forward.z, -Vector3.forward.z));

            cc.SimpleMove(backward * speed);
        }
        else { }
    }
}
