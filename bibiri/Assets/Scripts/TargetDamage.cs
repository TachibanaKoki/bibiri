using UnityEngine;
using System.Collections;

public class TargetDamage : MonoBehaviour
{
    [SerializeField]
    private int MaxHp=100;

    int Hp;

    [SerializeField]
    GameObject HpUIPrefab;

    RectTransform HpImage;
    RectTransform HpSplite;

    Camera cam;

    // Use this for initialization
    void Start()
    {
        Hp = MaxHp;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GameObject UIobj;
        UIobj = GameObject.Instantiate(HpUIPrefab);
        UIobj.transform.parent = GameObject.FindGameObjectWithTag("MainCanvas").transform;
        HpImage = UIobj.GetComponent<RectTransform>();
        HpSplite = UIobj.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        HpImage.position = cam.WorldToScreenPoint(gameObject.transform.position);
        HpSplite.localScale = new Vector3(Hp*0.01f,1,1);
    }

    void OnCollisionStay(Collision col)
    {
        if (Hp <= 0) return;
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("TargetDamage");
            Hp--;
            if (Hp <= 0)
            {
                GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
