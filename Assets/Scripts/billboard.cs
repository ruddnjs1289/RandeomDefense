using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class billboard : MonoBehaviour
{
    //text 오브젝트 맞게 설정
    public Text timer;
    public Text round;
    public Text CurrentCount;

    //시간 설정

    //라운드
    public float _roundtime = 40f;
    //보스
    public float _bosstime = 70f;
    //현재시간 라운드 시작전 대기시간

    public float CurrentTime = 70f;

    //라운드 설정 
    public int roundcount = 0;
    public bool isBoss = false;


    //유닛카운트 설정 
    int MaxUnitCount =80;
    public int CurrentUnitCount;

    // 소환 간격 (초)
    public float spawnInterval = 1f;
    //한라운드당 최대 소환 횟수
    public int MaxCount = 10;
    //소환된 갯수
    public int SpwanCount;

	private void Start()
	{
     
    }
	// Update is called once per frame
	void Update()
    {
        //현재 시간을 계속 빼서 0보다 작아지면 라운드카운트를 1올림 
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0)
        {
            roundcount++;
            // 10으로 나눠서 몫이 0이면 보스 전 시작하고 현재 시간을 보스시간으로 교체 
            if (roundcount % 10 == 0)
            {
                CurrentTime = _bosstime;
                isBoss = true;
            }
            else
            {
                //아니라면 현재 시간을 라운드 시간으로 교체
                CurrentTime = _roundtime;
                isBoss = false;
                StartCoroutine("onSpwan");
             
            }
        }


        DisplayTime();



    }


    //float 타입  전자 시계로 바꾸기 
    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(CurrentTime / 60);
        int seconds = Mathf.FloorToInt(CurrentTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        round.text = "라운드: " + roundcount.ToString();
        CurrentCount.text = CurrentUnitCount.ToString();
    }


    public void Munit() 
    {
        CurrentUnitCount--;
    }
    //소환 함수
    public void spwan()
    {
        GameObject newOb = GameManager.instance.pool.Get(0);
        newOb.transform.position = GameObject.Find("PoolManager").transform.position;
        SpwanCount++;
        CurrentUnitCount++;
    }

    //1초마다 소환 하는함수 
    IEnumerator onSpwan() {
        while (true)
        {
            // // 현재횟수가  맥스 횟수보다 크거나 현재 시간이 0 보다 작으면 실행
            if (SpwanCount >= MaxCount || CurrentTime <= 0)
            {
                SpwanCount = 0;
                yield break;
            }
            else
            {
                spwan();
            }
            // 1초 기다리기
            yield return new WaitForSeconds(1f);
        }
    }
}
