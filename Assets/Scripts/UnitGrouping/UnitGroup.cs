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

		
		// 내가 선택한 그룹을 찾아서 활성화 오브젝트와 비교 둘이 같아 질때까지  그룹활성화 시키고 배열에 추가 
		for (int i = activeObjects.Count; i < unitSelections.unitsSelected.Count; i++)
		{
			GameObject group = Groups[i];
			group.SetActive(true);
			activeObjects.Add(group);

			// 두개 이상 그룹에 들어갈시 이미지들만 보여주는기능
			Image imageComponent = group.GetComponent<Image>();
			imageComponent.sprite = unitSelections.unitsSelected[i].GetComponent<Status>().stat.face;


			//하나만 클릭했을때  활성화 그룹 끄기 
			if (unitSelections.unitsSelected.Count == 1)
			{
				activeObjects[0].SetActive(false);
			}
			else
			{
				activeObjects[0].SetActive(true);
			}
		}
		//반대로 그룹에서 하나씩 제거 했을때 비활성화하는기능
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
