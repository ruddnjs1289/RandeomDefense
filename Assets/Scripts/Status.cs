using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Stat stat;

    //���� ü������ ��ȯ 
    public float hp;
 
    void Start()
    {
        hp = stat.hp;
    }

 
 
  
}
