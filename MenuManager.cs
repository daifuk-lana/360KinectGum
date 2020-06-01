﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject Canvas;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

            Canvas.SetActive(false);

        }

        if (Input.GetKey(KeyCode.Escape))
        {

            Canvas.SetActive(true);

        }

    }
}