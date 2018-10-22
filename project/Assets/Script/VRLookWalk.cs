using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{

    public Transform vrCamera;

    public float toggleAngle = 45.0f;

    public float speed = 3.0f;

    public bool moveforward;

    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("x "+vrCamera.eulerAngles.x);
        Debug.Log("y "+vrCamera.eulerAngles.y);
        Debug.Log("z "+vrCamera.eulerAngles.z);

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveforward = false;
        }
        else
        {
            moveforward = true;
        }
        if (moveforward == true)
        {
            Vector3 forward = vrCamera.TransformDirection(new Vector3(Vector3.forward.x, 0f, Vector3.forward.z));

            cc.SimpleMove(forward * speed);
        }
    }
}
