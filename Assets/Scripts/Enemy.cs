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
            Debug.Log("������");
           
            if (timer > stuntime) {
                Debug.Log("���� Ǯ��");
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
            Debug.Log("CC����");
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
        //ü�� �ʱ�ȭ
        hp = stat.hp;
        //������ �ʱ�ȭ
    }





}
