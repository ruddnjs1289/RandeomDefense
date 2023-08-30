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
	//담아서 출력
	public int Hp;

	//설정 함수 
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
		Debug.Log("공격");
	}

	public void Init()
	{

		hp = Hp;
		Mp = 50;

	}





}
