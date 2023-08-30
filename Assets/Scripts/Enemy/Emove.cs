using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emove : MonoBehaviour
{
    float speed = 5f;

    private Enemy enemy;


	private void Awake()
	{
        enemy = GetComponent<Enemy>();
	}
    private void OnEnable()
    {
        enemy.isstun = false;
        transform.Rotate(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward *Time.deltaTime*speed;
        if (enemy.isstun)
        {

            speed = 0;
        }
        else {
            speed = 5f;
        }


    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Wall") {
            transform.Rotate(0, -90, 0);
        }
            
	}

    //스턴 맞으면 멈추게 하기
}
