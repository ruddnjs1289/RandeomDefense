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
            // ���� ��Ȱ��ȭ , ���ο� ���� �������� ��ȯ
            gameObject.SetActive(false);
            //���� ��ȯ
           Transform rd = GameManager.instance.pool.Get(Random.Range(0, 2)).transform;
            rd.position = Pos.position;
        }
    }
}
