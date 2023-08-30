using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public interface InterfaceEx
{
	public int hp { get; set; }
	public int Mp { get; set; }


	public void Init();
	public void Attack();
}
