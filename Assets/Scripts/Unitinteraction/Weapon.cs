using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    public float timer;

 

    UnitController unitController;

	private void Awake()
	{
        unitController = GetComponentInParent<UnitController>();
	}
	private void Start()
	{
        Init();
	}
	void Update()
    {
        switch (id)
        {
            case 0:
                break;
      
            default:
                timer += Time.deltaTime;
                if (timer > speed && !unitController.isMove)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }

    public void Init() 
    {
        switch (id) {
            case 0:
                speed = -150;
                break;

            default:
                //���� �ӵ� 
                speed = 0.3f;
                break;
        }

    }

    /* ������ ���� �ڵ� �̿ϼ�
    void Batch() {
        for (int index = 0; index < count; index++) {
          Transform bullet=  GameManager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;  
        }
    }*/

    void Fire() {
        if (!unitController.scanner.nearestTarget)
            return;

        //ũƼ��Ƽ�� Ȯ�� �̱� 
        int critical = Random.Range(1,101);
        Vector3 targetPos = unitController.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;
 
        

        //n% �ۼ�Ʈ�� Ȯ���� �̱�  
        if (critical <= 30)
		{
			Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.position = transform.position;
            bullet.GetComponent<Bullet>().Init(2 * damage, dir);
            Debug.Log("�ι��� ������ ");
        } 
        //10%��ƮȮ�� 31 ~ 40 ������ Ȯ��
        else if (critical <= 70) {
            //�� Ȯ���϶��� ���� ���� �¾��� �� 

            Transform CC = GameManager.instance.pool.Get(2).transform;
            CC.GetComponent<Bullet>().Init(2 * damage, dir);
            CC.position = transform.position;

            Debug.Log("CC");
        }
		else
		{
            Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.position = transform.position;
            bullet.GetComponent<Bullet>().Init(damage, dir);
            Debug.Log("�⺻ ������");
        }
    }
}
