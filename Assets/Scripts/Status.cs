using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Stat stat;

    //현재 체력으로 변환 
    public float hp;
 
    void Start()
    {
        hp = stat.hp;
    }

 
 
  
}
