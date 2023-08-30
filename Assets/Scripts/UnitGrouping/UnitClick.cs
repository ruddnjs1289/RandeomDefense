using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;
    public GameObject groundMarker;

    public LayerMask clickable;
    public LayerMask ground;
    private bool aim;
    

    void Start()
    {
        myCam = Camera.main;
    
    }

    private IEnumerator ReactivateMarker()
    {
        yield return new WaitForSeconds(1f); // 0.1�� ���
        groundMarker.SetActive(false);
    } 


    void Update()
    {
        if (UnitSelections.Instance.unitsSelected.Count != 0)
        {
            aim = UnitSelections.Instance.unitsSelected[0].GetComponent<UnitController>().isAim;
        }
        //����Ŭ��,�Ʊ� ���ֵ��� �������϶� ���
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if (!aim)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        UnitSelections.Instance.ShiftClickSeleect(hit.collider.gameObject);
                        UnitSelections.Instance.textupdate();
                    }
                    else
                    {

                        UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                        UnitSelections.Instance.textupdate();
                    }
                }
                else
                {

                    if (!Input.GetKey(KeyCode.LeftShift))
                        UnitSelections.Instance.DeselectAll();
                }

            }
        }


        //���� �̵�
        if (Input.GetMouseButtonDown(1)) {

            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(true);
                StartCoroutine(ReactivateMarker());
            }
         }
    }



	
}
