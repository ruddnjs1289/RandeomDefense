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

        //�̵�
        Move();

        //������ �����̴� �� ���� 
        if (unit.isMove && myAgent.remainingDistance <= 0.1f)
        {
            unit.isMove = false;
        }
        //���� ���� ���¶��� ǥ��
        if (Input.GetKey(KeyCode.Z))
        {
            unit.isAim = true;
            Debug.Log("zŰ ����");
        }

        //�����̵�
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
            // ��ġ�� Ŭ���ϸ� Ŭ���� ������ �̵�
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                        // ���� ������ �ʴ� ��� �̵� ����
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
            myAgent.ResetPath(); // ������ ���� SetDestination ��θ� �ʱ�ȭ�Ͽ� �̵� ���߱�
        }


    }


}

