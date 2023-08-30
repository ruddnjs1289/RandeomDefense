using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitGroup : MonoBehaviour
{
    public List<GameObject> Groups = new List<GameObject>();
	public UnitSelections unitSelections;
	public List<GameObject> activeObjects = new List<GameObject>();
	public GameObject status;


	

	// Update is called once per frame
	void Update()
    {

		
		// ���� ������ �׷��� ã�Ƽ� Ȱ��ȭ ������Ʈ�� �� ���� ���� ��������  �׷�Ȱ��ȭ ��Ű�� �迭�� �߰� 
		for (int i = activeObjects.Count; i < unitSelections.unitsSelected.Count; i++)
		{
			GameObject group = Groups[i];
			group.SetActive(true);
			activeObjects.Add(group);

			// �ΰ� �̻� �׷쿡 ���� �̹����鸸 �����ִ±��
			Image imageComponent = group.GetComponent<Image>();
			imageComponent.sprite = unitSelections.unitsSelected[i].GetComponent<Status>().stat.face;


			//�ϳ��� Ŭ��������  Ȱ��ȭ �׷� ���� 
			if (unitSelections.unitsSelected.Count == 1)
			{
				activeObjects[0].SetActive(false);
			}
			else
			{
				activeObjects[0].SetActive(true);
			}
		}
		//�ݴ�� �׷쿡�� �ϳ��� ���� ������ ��Ȱ��ȭ�ϴ±��
		for (int i = activeObjects.Count - 1; i >= unitSelections.unitsSelected.Count; i--)
		{
			GameObject group = activeObjects[i];
			group.SetActive(false);
			activeObjects.RemoveAt(i);

			if (unitSelections.unitsSelected.Count == 1)
			{
				status.SetActive(true);
				activeObjects[0].SetActive(false);
			}
			else if (unitSelections.unitsSelected.Count > 1)
			{
				status.SetActive(false);
				activeObjects[0].SetActive(true);
			}
			else {
				return;
			}
		}

			



	}
}
