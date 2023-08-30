using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Scanner scanner;

	public bool isMove;

	public bool isAim;

	public bool isAttack;

	private void Awake()
	{
        scanner = GetComponent<Scanner>();
	}


	
}
