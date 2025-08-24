using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Faces_User : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {

        // Orientation vector defined by the difference between GameObjectA (which looks at ObjectB) and GameObjectB (which is looked at by GameObjectA and optionally moves)
        Vector3 orientation = target.position - transform.position;

        // GameObjectA looks at GameObjectB on basis of the defined orientation vector
        transform.rotation = Quaternion.LookRotation(orientation);

    }

}
