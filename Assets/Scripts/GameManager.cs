using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager pool;
	public billboard billboard;


	private void Awake()
	{
		instance = this;
	}

	public Vector3 position() {

		return pool.transform.position;
	}




}
