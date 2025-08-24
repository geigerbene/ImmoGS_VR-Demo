using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryTransformations : MonoBehaviour
{
    public GameObject referenceObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The button is positioned in reference to the user
        this.transform.position = new Vector3(referenceObject.transform.position.x - 0.2f, referenceObject.transform.position.y - 0.5f, referenceObject.transform.position.z);

    }
}
