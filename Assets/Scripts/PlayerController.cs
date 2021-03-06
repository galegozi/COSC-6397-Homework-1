﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public Text scoreText;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = CrossPlatformInputManager.VirtualAxisReference("Horizontal").GetValue;
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        //float moveHorizontal = Input.acceleration.x;
        //float moveVertical = Input.acceleration.y;
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //GetComponent<Rigidbody>().AddForce(movement * speed * 2);

        //float horiz = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horiz, 0, vert);

        //GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count += 1;
            scoreText.text = "Score: " + count;
        }
    }
}
