using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Используется на объекте Player
//Передвижение персонажа
public class InputPlayer : MonoBehaviourPunCallbacks
{
	[SerializeField]
    private CharacterController characterController;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
		//Выполнение передвижения персонажа с клавиатуры, если тот является вашим
		if (photonView.IsMine)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection *= speed;
			
			characterController.Move(moveDirection * Time.deltaTime);
		}
    }
}
