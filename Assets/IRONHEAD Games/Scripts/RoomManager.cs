using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    private string mapType;

    // public TextMeshProUGUI OccupancyRateText_ForSchool;
    public TextMeshProUGUI OccupancyRateText_MeetingArea;
    public TextMeshProUGUI OccupancyRateText_Language;
    public TextMeshProUGUI OccupancyRateText_Sight;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region UI Callback Methods
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }



    public void OnEnterButtonClicked_FloatingMarketSingle()
    {
        SceneManager.LoadScene("02_FloatingMarketSingle_Intro");
    }

    public void OnEnterButtonClicked_FloatingMarketSingle_Speaking()
    {
        SceneManager.LoadScene("02_FloatingMarketSingle_Speaking");
    }

    public void OnEnterButtonClicked_TempleSingle()
    {
        SceneManager.LoadScene("02_TempleSingle_Intro");
    }

    public void OnEnterButtonClicked_02_TempleSingle_Bun()
    {
        SceneManager.LoadScene("02_TempleSingle_Bun");
    }

    public void OnEnterButtonClicked_02_TempleSingle_Bun_Praying()
    {
        SceneManager.LoadScene("02_TempleSingle_Bun_Praying");
    }

    public void OnEnterButtonClicked_02_TempleSingle_Kwan()
    {
        SceneManager.LoadScene("02_TempleSingle_Kwan");
    }

    public void OnEnterButtonClicked_02_TempleSingle_Kwan_PhuangMalai()
    {
        SceneManager.LoadScene("02_TempleSingle_Kwan_PhuangMalai");
    }


    public void OnEnterButtonClicked_MeetingArea()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_MEETINGAREA;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }


    public void OnEnterButtonClicked_LanguageMulti()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_LANGUAGE;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    public void OnEnterButtonClicked_SightMulti()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SIGHT;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);
    }

    /*
    public void OnEnterButtonClicked_School()
    {
        mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL;
        ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
        PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties,0);
    }
    */
    #endregion

    #region Photon Callback Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to servers again.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("A room is created with the name: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The Local player: " + PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " Player count " + PhotonNetwork.CurrentRoom.PlayerCount);

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY))
        {
            object mapType;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY,out mapType))
            {
                Debug.Log("Joined room with the map: " + (string)mapType);
                /*
                if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL)
                {
                    //Load the school scene
                    PhotonNetwork.LoadLevel("World_School");

                }
                */
                if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_MEETINGAREA)
                {
                    //Load the meeting area scene
                    PhotonNetwork.LoadLevel("03_MeetingArea");

                }
                else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_LANGUAGE)
                {
                    //Load the language scene
                    PhotonNetwork.LoadLevel("03_FloatingMarketMulti");

                }
                else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_SIGHT)
                {
                    //Load the sight scene
                    PhotonNetwork.LoadLevel("03_TempleMulti");

                }
            }
        }


    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to: " + "Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (roomList.Count == 0)
        {
            //There is no room at all
            // OccupancyRateText_ForSchool.text = 0 + " / " + 20;
            OccupancyRateText_MeetingArea.text = 0 + " / " + 20;
            OccupancyRateText_Language.text = 0 + " / " + 20; 
            OccupancyRateText_Sight.text = 0 + " / " + 20; 

        }

        foreach (RoomInfo room in roomList)
        {
            Debug.Log(room.Name);
            if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_MEETINGAREA))
            {
                Debug.Log("Room is a Meeting Area map. Player count is: " + room.PlayerCount);
                OccupancyRateText_MeetingArea.text = room.PlayerCount + " / " + 20;
            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_LANGUAGE))
            {
                //Update the Language room occupancy field
                Debug.Log("Room is a Language map. Player count is: " + room.PlayerCount);

                OccupancyRateText_Language.text = room.PlayerCount + " / " + 20;

            }
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_SIGHT))
            {
                Debug.Log("Room is a Sight map. Player count is: " + room.PlayerCount);
                OccupancyRateText_Sight.text = room.PlayerCount + " / " + 20;
            }
            /*
            else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL))
            {
                Debug.Log("Room is a School map. Player count is: " +room.PlayerCount);
                OccupancyRateText_ForSchool.text = room.PlayerCount + " / " + 20;
            }
            */
        }


    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the Lobby.");
    }
    #endregion

    #region Private Methods
    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room_" +mapType + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;


        string[] roomPropsInLobby = { MultiplayerVRConstants.MAP_TYPE_KEY };
        //We have 2 different maps
        //1. Outdoor = "outdoor"
        //2. School = "school"

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { {MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };

        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;

        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);

    }


    #endregion
}
