using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class UnitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask ground;


    UnitController unit;
    Scanner scanner;

    
    void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        unit = GetComponent<UnitController>();
        scanner = GetComponent<Scanner>();
    }

    // Update is called once per frame
    void Update()
    {

        //이동
        Move();

        //도착시 움직이는 값 해제 
        if (unit.isMove && myAgent.remainingDistance <= 0.1f)
        {
            unit.isMove = false;
        }
        //공격 중인 상태란걸 표시
        if (Input.GetKey(KeyCode.Z))
        {
            unit.isAim = true;
            Debug.Log("z키 누름");
        }

        //공격이동
        AttackMove();

    }
    public bool onAim() {
       return unit.isAim = true;
    }
    void Move() {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {

                myAgent.SetDestination(hit.point);
                unit.isMove = true;
                unit.isAttack = false;

            }
        }

    }

    void AttackMove()
    {
        if (unit.isAim)
        {
            // 위치를 클릭하면 클릭한 곳까지 이동
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                        // 적이 보이지 않는 경우 이동 설정
                      unit.isMove = true;
                      myAgent.SetDestination(hit.point);
                      unit.isAttack = true;
                      unit.isAim = false;
                      Debug.Log(hit.transform.name);
                }
            }
           
        }
        if (scanner.nearestTarget != null && unit.isAttack)
        {
            unit.isMove = false;
            // unit.isAttack =true;
            myAgent.ResetPath(); // 이전에 찍어둔 SetDestination 경로를 초기화하여 이동 멈추기
        }


    }


}

