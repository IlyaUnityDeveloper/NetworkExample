using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Используется на объекте Player
//Отображение имени персонажа, и его модификация
public class SyncNamePlayer : MonoBehaviourPunCallbacks, IPunObservable
{
	public string name;
	[SerializeField]
    private Vector3 centerOfObject; //То в каком месте будет отображаться имя персонажа
	
	void Update()
	{
		centerOfObject = Camera.main.WorldToScreenPoint(transform.position); //Имя персонажа будет отображаться в центре объекта
	}
	
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		stream.Serialize(ref name);
	}
	
	void OnGUI()
	{
		//Поле, где будет меняться имя персонажа
		if (photonView.IsMine)
		{
			name = GUI.TextField(new Rect(10, Screen.height-30, 200, 20), name, 20);
		}
		
		//Отображение имени персонажа
		GUI.Box(new Rect(centerOfObject.x-100, Screen.height-centerOfObject.y-10, 200, 20), name);
	}
}
