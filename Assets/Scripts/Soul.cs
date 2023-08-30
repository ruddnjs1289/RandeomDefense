using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField]
    Transform Pos;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Zone"))
        {
            Debug.Log(other.tag);
            // 유닛 비활성화 , 새로운 유닛 랜덤으로 소환
            gameObject.SetActive(false);
            //랜덤 소환
           Transform rd = GameManager.instance.pool.Get(Random.Range(0, 2)).transform;
            rd.position = Pos.position;
        }
    }
}
