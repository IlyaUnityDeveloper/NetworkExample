using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Используется на объекте Enemy
public class EnemyBehavior : MonoBehaviourPunCallbacks, IPunObservable
{
    public int health;
	[SerializeField]
    private Vector3 centerOfObject; //То в каком месте будет отображаться здоровье врага
	[SerializeField]
    private bool hitable = false; //Можно ли производить нападение на врага
	
	void Start()
	{
		hitable = false; //Нельзя нападать на врага, пока игрок не подключен к комнате
	}
	
	void Update()
	{
		centerOfObject = Camera.main.WorldToScreenPoint(transform.position); //Здоровье врага будет отображаться в центре объекта
	}
	
	 //После подключения к комнате, на врага можно нападать
	public override void OnJoinedRoom()
	{
		hitable = true;
	}
	
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		stream.Serialize(ref health);
	}
	
	//Отображение здоровья врага
	void OnGUI()
	{
		if (hitable)
		{
			GUI.Box(new Rect(centerOfObject.x-50, Screen.height-centerOfObject.y-10, 100, 20), "Hit Counter: " + health);
		}
	}
	
	//Вызвать функцию, которая прибавит здоровье врага у всех игроков
	void OnMouseDown()
    {
		if (hitable)
		{
			photonView.RPC("HitMe", RpcTarget.All);
		}
    }
	
	[PunRPC]
	public void HitMe()
	{
		health += 1;
	}
}
