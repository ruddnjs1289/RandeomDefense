using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
   public float damage;
   public int per;

    Rigidbody rigid;


	private void Awake()
	{
        rigid = GetComponent<Rigidbody>();
	}
    private void OnEnable()
    {
        // ��ü�� Ȱ��ȭ�Ǹ� lifeTime �ð� �Ŀ� DeactiveObj �޼��� ȣ��
        Invoke(nameof(DeactiveObj), 5f);
    }

    private void OnDisable()
    {
        // ��ü�� ��Ȱ��ȭ�Ǹ� DeactiveObj �޼��� ȣ�� ���� ���
        if (IsInvoking(nameof(DeactiveObj)))
        {
            CancelInvoke(nameof(DeactiveObj));
        }
    }

    private void DeactiveObj()
    {
        // ��ü ��Ȱ��ȭ ���� ����
        gameObject.SetActive(false);
    }
    public void Init(float damage ,Vector3 dir) {
        this.damage = damage;
        //����-1(����)���� ū �Ϳ� ���ؼ��� �ӵ� ����
       
        rigid.velocity = dir * 30f; 
        
    }



	private void OnTriggerEnter(Collider other)
	{
        if (!other.CompareTag("Enemy"))
            return;

        if (other.CompareTag("Enemy")) {
            rigid.velocity = Vector3.zero;
            gameObject.SetActive(false);
            

        }


	}

    /*��������� ����� ��*/
    /*���ο� �ݶ��̴� ��ġ -> ���� �� �ξ��ٰ�  ���� Ȯ���� �ݶ��̴��� Ǯ�� */
}
