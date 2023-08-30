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
                //연사 속도 
                speed = 0.3f;
                break;
        }

    }

    /* 근접을 위한 코딩 미완성
    void Batch() {
        for (int index = 0; index < count; index++) {
          Transform bullet=  GameManager.instance.pool.Get(prefabId).transform;
            bullet.parent = transform;  
        }
    }*/

    void Fire() {
        if (!unitController.scanner.nearestTarget)
            return;

        //크티리티컬 확률 뽑기 
        int critical = Random.Range(1,101);
        Vector3 targetPos = unitController.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;
 
        

        //n% 퍼센트의 확률로 뽑기  
        if (critical <= 30)
		{
			Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
            bullet.position = transform.position;
            bullet.GetComponent<Bullet>().Init(2 * damage, dir);
            Debug.Log("두배의 데미지 ");
        } 
        //10%센트확률 31 ~ 40 사의이 확률
        else if (critical <= 70) {
            //그 확률일때만 실행 적이 맞았을 때 

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
            Debug.Log("기본 데미지");
        }
    }
}
