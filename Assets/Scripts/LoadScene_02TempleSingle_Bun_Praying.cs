using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_02TempleSingle_Bun_Praying : MonoBehaviourPunCallbacks
{

    public GameObject uiPraying;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        uiPraying.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        uiPraying.SetActive(false);
    }

    public void LoadScene_02TempleBunPraying()
    {
        // PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("02_TempleSingle_Bun_Praying");
    }



    /*
    #region Photon Callback Methods

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to: " + "Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.LoadLevel("01_PrivateArea");
    }

    #endregion
    */

}
