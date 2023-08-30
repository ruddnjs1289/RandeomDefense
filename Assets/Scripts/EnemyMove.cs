using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public List<Transform> wayPoints; // ��������Ʈ�� ����
    private int nextIdx; // ���� �� ���� ��ġ�� ����

    public float patrolSpeed = 5f; // �̵� �ӵ�
    public float rotationSpeed = 360.0f; // ȸ�� �ӵ�

    private NavMeshAgent agent;
    private Transform enemyTr; // Ʈ������
    private Enemy enemy;


	private void OnDisable()
	{
        nextIdx = 0;
        Debug.Log(nextIdx + "�ʱ�ȭ");

    }

	private void Awake()
	{
        FindWayPoints();

    }
	private void Start()
    {
        enemyTr = transform;
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        MoveToNextWayPoint();
        agent.speed = patrolSpeed; // �̵� �ӵ��� navmeshspeed�� ����
    }
    //��ü ���� ����Ʈ ã��
    private void FindWayPoints()
    {

        //��������Ʈ ã�� 
        var group = GameObject.Find("WayPoint");
        if (group != null)
        {
            //group�ȿ� �ִ� Transform ������Ʈ�� ���� ������Ʈ ���� ã��
            var waypoints = group.GetComponentsInChildren<Transform>();
            //��Ʈ����  �ֱ� 
            wayPoints.AddRange(waypoints);
            //0���� ���� 
            //���� ����  0������ ��κ� �ڱ� �ڽ��̴�  ����Ʈ�� �ʿ��ϹǷ� �׳� �����ȴ�.
            wayPoints.RemoveAt(0);
        }
    }

    /// <summary>
    /// ���� �̵��� ã��
    /// </summary>
    private void MoveToNextWayPoint()
    {
        //���� agent�� ��ΰ� �ֽ� ���°� �ƴ϶��, �� ��ΰ� ���ŵ��� �ʾҰų� ��ȿȭ�Ǿ��ٸ� �޼��带 �����մϴ�.
        if (agent.isPathStale) return;
        //agent�� �������� ���� ���������� �̵�
        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;
        // NavMeshAgent�� Ȱ��ȭ���� ���� ��� Ȱ��ȭ�մϴ�.
        if (!agent.enabled) agent.enabled = true;
    }


	private void FixedUpdate()
	{
        MoveSkill();
        
    }

	void MoveSkill() {

        if (enemy.isstun&&enemy.enabled==true)
        {
            // ���� ������ ��, ���� �̵��� ����ϴ�.
            agent.isStopped = true;
            patrolSpeed = 0;
            agent.velocity = Vector3.zero;
        }
        else
        {
            // ���� ���°� �ƴ� ��, ���� ��������Ʈ�� ���� �̵��մϴ�.
            agent.isStopped = false; // �̵��� �ٽ� �����մϴ�.


            // ������Ʈ�� �̵��ϰ� ���� ��, ������ �̵� �ӵ��� ȸ�� �ӵ��� �����ϸ� ��������Ʈ�� ���� �̵��մϴ�.
            if (!agent.isStopped)
            {
                agent.velocity = agent.desiredVelocity;
                //agent.velocity.sqrMagnitude �Ÿ��� ���Ҷ� ��� 
                if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f)
                {
                    //targetRotation�� ���ο� ȸ������ ��� �׸��� ������ �ٶ󺸰� ȸ��
                    Quaternion targetRotation = Quaternion.LookRotation(agent.desiredVelocity);
                    //�׸��� ȸ�� ��Ŵ 
                    enemyTr.rotation = Quaternion.RotateTowards(enemyTr.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
                //���������� ���� �Ÿ��� ���Ҷ� ��� 
                if (agent.remainingDistance <= 0.5f)
                {
                    //����  �����������̵� ����
                    //wayPoints.Count�� 5�̰� ���� nextIdx�� 3�� ���, (3 + 1) % 5�� 4�� ��ȯ�մϴ�.
                    nextIdx = (nextIdx + 1) % wayPoints.Count;
                    MoveToNextWayPoint();
                }
            }
        }
    }
}
