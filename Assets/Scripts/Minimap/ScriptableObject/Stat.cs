using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Stat",menuName ="Stat/Sphere")]
public class Stat : ScriptableObject
{
	public Sprite face;
	public new string name;
	public float hp;
	



	public void Print() {

		Debug.Log(hp + ":" + name);
	}

}


