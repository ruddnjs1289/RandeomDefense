using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class InterfaceUser : MonoBehaviour,InterfaceEx
{

	void Start()
	{
		
		Init();
		Attack();

		Debug.Log("hp ="+ hp);
		Debug.Log("Mp =" +Mp);

	}

	// Update is called once per frame
	void Update()
	{

	}
	//��Ƽ� ���
	public int Hp;

	//���� �Լ� 
	public int hp { get { return Hp; } set {  Hp = value; } }


		
	public int GetHp()
	{
		return Hp;
	}
	public void SetHp(int value)
	{
		Hp = value;
	}
	public int Mp { get;  set; }

	public void Attack()
	{
		Debug.Log("����");
	}

	public void Init()
	{

		hp = Hp;
		Mp = 50;

	}





}
