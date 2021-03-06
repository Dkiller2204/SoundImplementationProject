﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CloudMovementUpDown : MonoBehaviour {
	private RigidbodyFirstPersonController playerController;
	public float movementSpeed;
	private float maxHeight;
	private float initialHeight;
	private bool isMaxHeight;
	private bool isPlayerColliding;
	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<RigidbodyFirstPersonController> ();
		movementSpeed = 5;
		initialHeight = transform.position.y;
		maxHeight = transform.position.y + 40;
		isMaxHeight = false;
		isPlayerColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move()
	{
		//move up until max height is reached and then move down and repeat

		if (transform.position.y < maxHeight && !isMaxHeight) {
			transform.Translate (Vector3.up * Time.deltaTime * movementSpeed);
		} else if(transform.position.y > initialHeight && isMaxHeight){
			transform.Translate(-Vector3.up * Time.deltaTime * movementSpeed);
			//move player down with cloud
			if (isPlayerColliding && !playerController.m_Jump) {
				playerController.transform.Translate(-Vector3.up * Time.deltaTime * movementSpeed);
			}
				
		}

		if (transform.position.y >= maxHeight) {
			isMaxHeight = true;
		} else if (transform.position.y <= initialHeight) {
			isMaxHeight = false;
		}
	}
		
	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player" ) {
			isPlayerColliding = true;
		}
	}

	void OnTriggerExit(Collider player) {
		if (player.tag == "Player") {			
			isPlayerColliding = false;

		}
	}

}
