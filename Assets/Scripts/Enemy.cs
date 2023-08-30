using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Status
{
    public bool isstun;
    public float stuntime =3f;
    public float timer;






	private void Update()
	{
        if (isstun) {
            timer += Time.deltaTime;
            Debug.Log("스턴중");
           
            if (timer > stuntime) {
                Debug.Log("스턴 풀림");
                isstun = false;
                timer = 0;

            }
        
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Bullet"))
        {
            hp -= other.GetComponent<Bullet>().damage;
        }

        if (other.CompareTag("CC")) {
            isstun = true;
            Debug.Log("CC맞음");
        }
        if (hp > 0)
        {

        }
        else {
            Dead();
        }




	}

    void Dead() {

        gameObject.SetActive(false);
        GameManager.instance.billboard.Munit();
        //체력 초기화
        hp = stat.hp;
        //포지션 초기화
    }





}
