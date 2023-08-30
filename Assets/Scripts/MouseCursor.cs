using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] Texture2D maincursorImg;
    [SerializeField] Texture2D attackcursorImg;




	private void Start()
	{
        
	}
	private void Update()
    {
        foreach (GameObject obj in UnitSelections.Instance.unitsSelected) {
            UnitController unitController = obj.GetComponent<UnitController>();

            if (unitController.isAim)
            {
                Cursor.SetCursor(attackcursorImg, Vector2.zero, CursorMode.ForceSoftware);
            }
            else 
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        
        }
    }
}
