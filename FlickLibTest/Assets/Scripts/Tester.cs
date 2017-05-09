using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {
    [SerializeField, Range(-1, 1)]
    private float x;
    [SerializeField, Range(-1, 1)]
    private float y;

    Vector2 startPos;
    Vector2 endPos;

    float angle;

    [SerializeField]
    InputUtil.FlickUtil flick;
    
    // Use this for initialization
    void Start () {
        //print(Mathf.Rad2Deg * (Mathf.Atan2(y, x)));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            flick.OnButtonDown();
        }
        if (Input.GetMouseButton(0))
        {
            flick.OnFlicking();
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("quadrant : " + flick.OnFlicked());
        }
	}
}
