using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnHome : MonoBehaviour
{

    [SerializeField]
    GameObject button_returnHome;

    // Start is called before the first frame update
    void Start()
    {
        button_returnHome.GetComponent<Button>().onClick.AddListener(VirtualWorldManager.Instance.LeaveRoomAndLoadHomeScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
