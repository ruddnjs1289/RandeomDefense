using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelections : MonoBehaviour
{
	public List<GameObject> unitList = new List<GameObject>();
	public List<GameObject> unitsSelected = new List<GameObject>();

	private static UnitSelections _instance;
	ShowStat showStat;
	public GameObject targetenmey;

	public GameObject StatusUI;
	public static UnitSelections Instance { get { return _instance;} }

	
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else {
			_instance = this;
		}
		targetenmey = null;
	}

	private void Start()
	{
		showStat = GetComponent<ShowStat>();
	}

	public void ClickSelect(GameObject unitToAdd) 
	{
		
		if (unitToAdd.tag == "Enemy")
		{
			DeselectAll();
			Debug.Log("눌림");
			Debug.Log(unitToAdd.GetComponent<Enemy>().hp);
			
			targetenmey = unitToAdd;
		}

		if (unitToAdd.tag == "Player")
		{
			DeselectAll();
			unitsSelected.Add(unitToAdd);
			unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
			unitToAdd.GetComponent<UnitMovement>().enabled = true;
		}
	
	
	}

	public void ShiftClickSeleect(GameObject unitToAdd)
	{
		if (unitToAdd.tag == "Enemy")
		{
			return;
		}

		if (!unitsSelected.Contains(unitToAdd))
		{
			unitsSelected.Add(unitToAdd);
			//마커 활성화 
			unitToAdd.transform.GetChild(0).gameObject.SetActive(true);

			unitToAdd.GetComponent<UnitMovement>().enabled = true;
		}
		else 
		{
			unitsSelected.Remove(unitToAdd);
			unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
			unitToAdd.GetComponent<UnitMovement>().enabled = false;  
		}
	}

	public void DragSelect(GameObject unitToAdd)
	{
		if (!unitsSelected.Contains(unitToAdd)) 
		{
			unitsSelected.Add(unitToAdd);
			unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
			unitToAdd.GetComponent<UnitMovement>().enabled = true;
		}
	}

	public void DeselectAll() 
	{
		foreach (var unit in unitsSelected) 
		{
			unit.GetComponent<UnitMovement>().enabled = false;
			unit.transform.GetChild(0).gameObject.SetActive(false);
		}
		unitsSelected.Clear();
		targetenmey = null;
		StatusUI.SetActive(false);
	}

	public void Deselect(GameObject uniToDeselect) 
	{
		foreach (var unit in unitsSelected)
		{
			unit.transform.GetChild(0).gameObject.SetActive(false);
		}
		unitsSelected.Clear();
	}


	//클릭 할때 마다  클릭한 오브젝트 정보 보여주기
	public void textupdate() {

		// 0이라면 보여주지 말기 => 아군 캐릭터가 아닌 적을 눌렀을때   UI와 누른 적의 캐릭터 정보 업데이트 하기 
		 if (unitsSelected.Count > 1 || unitsSelected.Count < 1) // 여러명을 눌렀을때  => 하나만 보는 스테이터스 UI 끄기 
		{
			StatusUI.SetActive(false);
		}
		else {
				//하나만 눌렀을 때 0번지의 정보 보여주고 UI 키기 
				Status unitselected = unitsSelected[0].GetComponent<Status>();
				showStat.UpdateStat(unitselected.stat.face, unitselected.stat.name, unitselected.hp);
				StatusUI.SetActive(true);
		}
		if (targetenmey == null) {
			return;
		}
		if (targetenmey.CompareTag("Enemy"))
		{
			showStat.UpdateStat(targetenmey.GetComponent<Enemy>().stat.face, targetenmey.GetComponent<Enemy>().stat.name, targetenmey.GetComponent<Enemy>().hp);
			StatusUI.SetActive(true);
		}
		//리스트 0번지의 정보 보여주기 실행



	}
}
