using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public List<Transform> wayPoints; // 웨이포인트를 지정
    private int nextIdx; // 도착 시 다음 위치를 지정

    public float patrolSpeed = 5f; // 이동 속도
    public float rotationSpeed = 360.0f; // 회전 속도

    private NavMeshAgent agent;
    private Transform enemyTr; // 트랜스폼
    private Enemy enemy;


	private void OnDisable()
	{
        nextIdx = 0;
        Debug.Log(nextIdx + "초기화");

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
        agent.speed = patrolSpeed; // 이동 속도를 navmeshspeed에 지정
    }
    //전체 웨이 포인트 찾기
    private void FindWayPoints()
    {

        //웨이포인트 찾기 
        var group = GameObject.Find("WayPoint");
        if (group != null)
        {
            //group안에 있는 Transform 컴포넌트를 가진 오브젝트 전부 찾기
            var waypoints = group.GetComponentsInChildren<Transform>();
            //리트스에  넣기 
            wayPoints.AddRange(waypoints);
            //0번지 제거 
            //제거 이유  0번지는 대부분 자기 자신이다  포인트만 필요하므로 그냥 지우면된다.
            wayPoints.RemoveAt(0);
        }
    }

    /// <summary>
    /// 다음 이동지 찾기
    /// </summary>
    private void MoveToNextWayPoint()
    {
        //만약 agent의 경로가 최신 상태가 아니라면, 즉 경로가 갱신되지 않았거나 무효화되었다면 메서드를 종료합니다.
        if (agent.isPathStale) return;
        //agent의 목적지를 다음 포지션으로 이동
        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;
        // NavMeshAgent가 활성화되지 않은 경우 활성화합니다.
        if (!agent.enabled) agent.enabled = true;
    }


	private void FixedUpdate()
	{
        MoveSkill();
        
    }

	void MoveSkill() {

        if (enemy.isstun&&enemy.enabled==true)
        {
            // 스턴 상태일 때, 적의 이동을 멈춥니다.
            agent.isStopped = true;
            patrolSpeed = 0;
            agent.velocity = Vector3.zero;
        }
        else
        {
            // 스턴 상태가 아닐 때, 적은 웨이포인트를 따라 이동합니다.
            agent.isStopped = false; // 이동을 다시 시작합니다.


            // 에이전트가 이동하고 있을 때, 일정한 이동 속도와 회전 속도를 유지하며 웨이포인트를 따라 이동합니다.
            if (!agent.isStopped)
            {
                agent.velocity = agent.desiredVelocity;
                //agent.velocity.sqrMagnitude 거리를 구할때 사용 
                if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f)
                {
                    //targetRotation에 새로운 회전값을 계산 그리고 그쪽을 바라보게 회전
                    Quaternion targetRotation = Quaternion.LookRotation(agent.desiredVelocity);
                    //그리고 회전 시킴 
                    enemyTr.rotation = Quaternion.RotateTowards(enemyTr.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
                //목적지가지 남은 거리를 구할때 사용 
                if (agent.remainingDistance <= 0.5f)
                {
                    //다음  포지션으로이동 수식
                    //wayPoints.Count가 5이고 현재 nextIdx가 3일 경우, (3 + 1) % 5는 4를 반환합니다.
                    nextIdx = (nextIdx + 1) % wayPoints.Count;
                    MoveToNextWayPoint();
                }
            }
        }
    }
}
