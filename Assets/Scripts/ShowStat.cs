using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowStat : MonoBehaviour
{
    public Image Face;
    public Text Name;
    public Text currenthp;



	public void UpdateStat(Sprite face , string name , float hp) {
        Name.text = name;
        currenthp.text = hp.ToString();
        Face.sprite = face;

    }
}
