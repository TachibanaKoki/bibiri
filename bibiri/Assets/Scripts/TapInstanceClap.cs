using UnityEngine;
using System.Collections;

public class TapInstanceClap : MonoBehaviour
{

    float timer;
    [SerializeField]
    GameObject tapEffect;
    Camera mainCamera;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer += Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(timer<0.2f)
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition+new Vector3(0,50,0)),-Vector3.up, out hit))
                {
                    Instantiate(tapEffect,hit.point,tapEffect.transform.rotation);
                }
            }
            timer = 0;
        }
    }
}
