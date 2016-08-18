using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    Vector2 startPosition;

    bool isStart = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


#if UNITY_EDITOR
        MouseEvent();
#elif UNITY_ANDROID
        TouchEvent();
#endif

    }

    void MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {

            startPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            isStart = true;
            Debug.Log("touchstart");
        }
        else if (Input.GetMouseButton(0))
        {
            
            Vector2 vec = startPosition - new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (vec == Vector2.zero) return;
            vec*=0.1f;
            Debug.Log("Moveto" + vec);
            gameObject.transform.localPosition += new Vector3(vec.x, 0, vec.y);
            startPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            isStart = false;
        }
    }

    void TouchEvent()
    {
        if (Input.touchCount > 0)
        {

            if (!isStart)
            {
                startPosition = Input.GetTouch(0).position;
                isStart = true;
                Debug.Log("touchstart");
            }
            else
            {

                Vector2 vec = startPosition - Input.GetTouch(0).position;
                vec.Normalize();
                Debug.Log("Moveto" + vec);
                gameObject.transform.localPosition += new Vector3(vec.x, 0, vec.y);

            }

        }
        else
        {
            isStart = false;
        }
    }
}
