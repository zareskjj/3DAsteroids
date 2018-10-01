﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageParticlesBehavior : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;	
	}
}
