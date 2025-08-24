using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSkipButtonTransformations : MonoBehaviour
{
    public GameObject referenceObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(referenceObject.transform.position.x, referenceObject.transform.position.y - 0.65f, referenceObject.transform.position.z + 0.37f);

    }
}
