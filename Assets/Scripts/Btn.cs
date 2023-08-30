using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{

    void Start()
    {
      
    }

    // Update is called once per frame


    public void Aim() {
        foreach (GameObject obj in UnitSelections.Instance.unitsSelected)
        {
            UnitMovement unit = obj.GetComponent<UnitMovement>();
            Debug.Log(obj);
            unit.onAim();


        }

        Debug.Log("½ÇÇà");

        
        
    }
}
