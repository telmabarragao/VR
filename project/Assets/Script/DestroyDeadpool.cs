using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeadpool : MonoBehaviour {

    void OnTriggerEnter(Collider col){
        if (col.gameObject.name == "Deadpool")
        {
            Destroy(col.gameObject);
        }
    }

}
