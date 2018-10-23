using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeadpool : MonoBehaviour {

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag.Equals("DeadPool"))
        {
            Destroy(col.gameObject);
        }
    }

}
