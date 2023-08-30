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
        yield return new WaitForSeconds(1f); // 0.1초 대기
        groundMarker.SetActive(false);
    } 


    void Update()
    {
        if (UnitSelections.Instance.unitsSelected.Count != 0)
        {
            aim = UnitSelections.Instance.unitsSelected[0].GetComponent<UnitController>().isAim;
        }
        //유닛클릭,아군 유닛들이 공격중일때 사용
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


        //유닛 이동
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
