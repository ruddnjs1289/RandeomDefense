using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float speed =30f;
    private float zoomSpeed =10.0f;
    private float rotateSpeed =0.1f;

    private float maxHeight = 15f;
    private float minHeight = 4f;

 
	internal Ray ScreenPointToRay(Vector3 mousePosition)
	{
		throw new NotImplementedException();
	}

	private Vector2 p1;
    private Vector2 p2;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.06f;
            zoomSpeed = 20.0f;
        }
        else
        {
            speed = 0.035f;
            zoomSpeed = 10.0f;
        }

        if (transform.position.x > 50f)
        {
            transform.position = new Vector3(50f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -50f)
        {
            transform.position = new Vector3(-50f, transform.position.y, transform.position.z);
        }


        if (transform.position.z > 50f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 50f);
        } else if (transform.position.z < -50f) {

            transform.position = new Vector3(transform.position.x, transform.position.y, -50f);
        }



        float hsp = -transform.position.y *speed * Input.GetAxis("Horizontal");
        float vsp = -transform.position.y *speed *Input.GetAxis("Vertical");
    
        float scrollsp =Mathf.Log(transform.position.y)*-zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if ((transform.position.y >= maxHeight)&&(scrollsp >0))
        {
            scrollsp = 0;
        }
        else if ((transform.position.y <= minHeight)&&(scrollsp <0))
        {
            scrollsp = 0;
        }

        if ((transform.position.y+scrollsp)>maxHeight)
        {
            scrollsp = maxHeight - transform.position.y ;
        }
        else if ((transform.position.y+scrollsp)<minHeight)
        {
            scrollsp = minHeight - transform.position.y;
        }
      
       
        
        Vector3 verticalmove = new Vector3(0, scrollsp, 0);
        Vector3 latermove = hsp * -transform.right;
        Vector3 forwardMove = -transform.forward;
        
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalmove + latermove + forwardMove;

        transform.position += move;



        getcameraRatation();

    }


    void getcameraRatation()
    {
        if (Input.GetMouseButtonDown(2))
        {
            p1 = Input.mousePosition;
        }
        
        if (Input.GetMouseButton(2))
        {
            p2 = Input.mousePosition;
            float dx = (p2 - p1).x * rotateSpeed;
            float dy = (p2 - p1).y * rotateSpeed;
            
            transform.rotation *=Quaternion.Euler(new Vector3(0,dx,0));
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));
            p1 = p2;
        }
    }
}
