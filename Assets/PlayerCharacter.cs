﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private int _health;
    void Start() {
        _health = 5;
    } // //////////////////////////////////////////////////////////

    void Update() {
    } // //////////////////////////////////////////////////////////

    public void Hurt(int damage) {
        _health -= damage;
        Debug.Log("Health: " + _health);
    } // //////////////////////////////////////////////////////////
} // **************************************************************
