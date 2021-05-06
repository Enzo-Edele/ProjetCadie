﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerBehaviour : MonoBehaviour
{
    public GameObject[] player;

    private void Start()
    {
        Instantiate(player[GameManagerBehaviour.instance.playerSkin], this.transform.position, Quaternion.identity);
    }
}
