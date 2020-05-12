using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Используется на объекте MainCamera
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
	
	//При подключении к серверу, производится подключение к комнате
    public override void OnConnectedToMaster()
    {
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.IsVisible = false;
		roomOptions.MaxPlayers = 20;
		PhotonNetwork.JoinOrCreateRoom("MainRoom", roomOptions, TypedLobby.Default);
    }
}