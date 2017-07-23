using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class C185_Altimeter : MonoBehaviour {
	public GameObject cockpit;
    public float FixGround = 0f;
    public float FixPointerPos1=0f;
	private RectTransform point_100 = null;
	private RectTransform point_1000 = null;
    private RaycastHit hit = new RaycastHit();
    private float pointer_100 = 0f;
    private float pointer_1000 = 0f;
    private Text AltiText = null;
    private float curSpin = 0f;
    void Start () {
        point_100 = GameObject.Find("Altimeter_Needle").GetComponent<RectTransform>();
		point_1000 = GameObject.Find("Altimeter_Needle_1k").GetComponent<RectTransform>();
        //AltiText = GameObject.Find("Text").GetComponent<Text>();

        point_100.rotation = Quaternion.Slerp(point_100.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 100f * Time.deltaTime);
        point_1000.rotation = Quaternion.Slerp(point_1000.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 100f * Time.deltaTime);

    }
	
	
	void Update() {
        GetDistans();
    }

       void  GetDistans()   {
        if (Physics.Raycast(cockpit.transform.position, -Vector3.up, out hit)) {
            float cleanpos = Mathf.Abs(FixPointerPos1) * -1f;
            float hitDistance = hit.distance / 0.3048f;
            float Disfeet = Mathf.Abs(hitDistance) * -1f;

            if (Disfeet < FixGround) {
	            point_100.rotation = Quaternion.Slerp(point_100.rotation, Quaternion.Euler(0, 0, Disfeet * 3.53f - cleanpos), 10f * Time.deltaTime);
	            point_1000.rotation = Quaternion.Slerp(point_1000.rotation, Quaternion.Euler(0, 0, Disfeet / 2.789f - cleanpos), 2f * Time.deltaTime);
            } else{
	            point_1000.rotation = Quaternion.Slerp(point_1000.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 5f * Time.deltaTime);
                point_100.rotation = Quaternion.Slerp(point_100.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 5f * Time.deltaTime);
            }
 
        }
    }



    }
