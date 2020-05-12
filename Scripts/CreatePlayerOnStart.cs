using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Используется на объекте MainCamera
public class CreatePlayerOnStart : MonoBehaviourPunCallbacks
{
	//Создание персонажа, при подключении к комнате
    public override void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate("Player", new Vector3(0, 1, 0), Quaternion.identity, 0);
	}
}
