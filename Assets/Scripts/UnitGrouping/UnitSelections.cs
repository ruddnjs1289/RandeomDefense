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
			Debug.Log("����");
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
			//��Ŀ Ȱ��ȭ 
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


	//Ŭ�� �Ҷ� ����  Ŭ���� ������Ʈ ���� �����ֱ�
	public void textupdate() {

		// 0�̶�� �������� ���� => �Ʊ� ĳ���Ͱ� �ƴ� ���� ��������   UI�� ���� ���� ĳ���� ���� ������Ʈ �ϱ� 
		 if (unitsSelected.Count > 1 || unitsSelected.Count < 1) // �������� ��������  => �ϳ��� ���� �������ͽ� UI ���� 
		{
			StatusUI.SetActive(false);
		}
		else {
				//�ϳ��� ������ �� 0������ ���� �����ְ� UI Ű�� 
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
		//����Ʈ 0������ ���� �����ֱ� ����



	}
}
