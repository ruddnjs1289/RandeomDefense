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
        // 객체가 활성화되면 lifeTime 시간 후에 DeactiveObj 메서드 호출
        Invoke(nameof(DeactiveObj), 5f);
    }

    private void OnDisable()
    {
        // 객체가 비활성화되면 DeactiveObj 메서드 호출 예약 취소
        if (IsInvoking(nameof(DeactiveObj)))
        {
            CancelInvoke(nameof(DeactiveObj));
        }
    }

    private void DeactiveObj()
    {
        // 객체 비활성화 로직 구현
        gameObject.SetActive(false);
    }
    public void Init(float damage ,Vector3 dir) {
        this.damage = damage;
        //관통-1(무한)보다 큰 것에 대해서는 속도 적용
       
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

    /*군중제어기 만드는 법*/
    /*새로운 콜라이더 배치 -> 해제 해 두었다가  일정 확률로 콜라이더를 풀기 */
}
