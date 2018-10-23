using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeadpool : MonoBehaviour {

    void OnEnterCollision(Collider col){
        if (col.gameObject.name == "deadpool_reference.001")
        {
            Destroy(col.gameObject);
        }
    }

}
