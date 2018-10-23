using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeadpool : MonoBehaviour {

  public GameObject flame;

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag.Equals("DeadPool"))
        {
          Vector3 pos = col.gameObject.transform.position;
            Destroy(col.gameObject);

            Quaternion q = new Quaternion(-0.5f,0f,0f,1f);
            GameObject obj1 = Instantiate(flame, pos, q);
            pos += new Vector3(0f,5f,0f);
            GameObject obj2 = Instantiate(flame, pos, q);
            pos += new Vector3(0f,5f,0f);
            GameObject obj3 = Instantiate(flame, pos, q);

            Destroy(obj1, 5);
            Destroy(obj2, 5);
            Destroy(obj3, 5);

        }
    }

}
