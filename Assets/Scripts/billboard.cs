using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class billboard : MonoBehaviour
{
    //text ������Ʈ �°� ����
    public Text timer;
    public Text round;
    public Text CurrentCount;

    //�ð� ����

    //����
    public float _roundtime = 40f;
    //����
    public float _bosstime = 70f;
    //����ð� ���� ������ ���ð�

    public float CurrentTime = 70f;

    //���� ���� 
    public int roundcount = 0;
    public bool isBoss = false;


    //����ī��Ʈ ���� 
    int MaxUnitCount =80;
    public int CurrentUnitCount;

    // ��ȯ ���� (��)
    public float spawnInterval = 1f;
    //�Ѷ���� �ִ� ��ȯ Ƚ��
    public int MaxCount = 10;
    //��ȯ�� ����
    public int SpwanCount;

	private void Start()
	{
     
    }
	// Update is called once per frame
	void Update()
    {
        //���� �ð��� ��� ���� 0���� �۾����� ����ī��Ʈ�� 1�ø� 
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0)
        {
            roundcount++;
            // 10���� ������ ���� 0�̸� ���� �� �����ϰ� ���� �ð��� �����ð����� ��ü 
            if (roundcount % 10 == 0)
            {
                CurrentTime = _bosstime;
                isBoss = true;
            }
            else
            {
                //�ƴ϶�� ���� �ð��� ���� �ð����� ��ü
                CurrentTime = _roundtime;
                isBoss = false;
                StartCoroutine("onSpwan");
             
            }
        }


        DisplayTime();



    }


    //float Ÿ��  ���� �ð�� �ٲٱ� 
    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(CurrentTime / 60);
        int seconds = Mathf.FloorToInt(CurrentTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        round.text = "����: " + roundcount.ToString();
        CurrentCount.text = CurrentUnitCount.ToString();
    }


    public void Munit() 
    {
        CurrentUnitCount--;
    }
    //��ȯ �Լ�
    public void spwan()
    {
        GameObject newOb = GameManager.instance.pool.Get(0);
        newOb.transform.position = GameObject.Find("PoolManager").transform.position;
        SpwanCount++;
        CurrentUnitCount++;
    }

    //1�ʸ��� ��ȯ �ϴ��Լ� 
    IEnumerator onSpwan() {
        while (true)
        {
            // // ����Ƚ����  �ƽ� Ƚ������ ũ�ų� ���� �ð��� 0 ���� ������ ����
            if (SpwanCount >= MaxCount || CurrentTime <= 0)
            {
                SpwanCount = 0;
                yield break;
            }
            else
            {
                spwan();
            }
            // 1�� ��ٸ���
            yield return new WaitForSeconds(1f);
        }
    }
}
