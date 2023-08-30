using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbar : MonoBehaviour
{
    [SerializeField] 
    GameObject hpbarprefabs = null;

    [SerializeField]
    List<Transform> m_obj = new List<Transform>();

    [SerializeField]
    List<GameObject> m_hpbar = new List<GameObject>();

    Camera m_cam = null;

    GameObject obj;
    void Start()
    {
        /*
        m_cam = Camera.main;
        
        GameObject[] t_obj = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < t_obj.Length; i++)
        {
            m_obj.Add(t_obj[i].transform);
            GameObject t_hpbar = Instantiate(hpbarprefabs, t_obj[i].transform.position, Quaternion.identity, transform);
          
            m_hpbar.Add(t_hpbar);

        }*/

        //enemy게임 오브젝트 가져오기 
       obj = transform.parent.parent.gameObject;
       m_cam = Camera.main;

   
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < m_obj.Count; i++)
        {
            m_hpbar[i].transform.position = m_cam.WorldToScreenPoint(m_obj[i].position + new Vector3(0, 1.15f, 0));
            m_hpbar[i].GetComponent<Slider>().value = m_obj[i].GetComponent<Enemy>().hp / m_obj[0].GetComponent<Enemy>().stat.hp;
        }*/
    
        //hpbar의 위치를 메인카메라 기준 월드 스크린 좌표로 찍어 적 오브젝트 위에 오도록 지정
        transform.position = m_cam.WorldToScreenPoint(obj.transform.position + new Vector3(0, 1.15f, 0));
        //피깍이는걸 시각화
        transform.GetComponent<Slider>().value = obj.GetComponent<Enemy>().hp / obj.GetComponent<Enemy>().stat.hp;
    }
}
