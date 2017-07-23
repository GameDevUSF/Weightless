using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class C185_Attitude : MonoBehaviour {
    private RectTransform AttitudeRing = null;
    private RectTransform AttitudeHorizon = null;
    public GameObject cockpit;
    public float RingSpeed=1f;
    public float HorizonSpeed = 1f;

    void Start () {
        //AttitudeRing = GameObject.Find("attitude_outer_ring").GetComponent<RectTransform>();
        AttitudeHorizon = GameObject.Find("attitude_horizon").GetComponent<RectTransform>();
    }
	
	void Update () {

		float LeftRight_ = Mathf.Sin((cockpit.transform.rotation.eulerAngles.z * Mathf.PI) / 180) * 90;
		float UpDown_ = -Mathf.Sin((cockpit.transform.rotation.eulerAngles.x * Mathf.PI) / 180) * 45 ;
        Vector3 Result_ = new Vector3(0, UpDown_, 0);

        //AttitudeRing.rotation = Quaternion.Slerp(AttitudeRing.rotation, Quaternion.Euler(0, 0, LeftRight_), RingSpeed * Time.deltaTime);
		AttitudeHorizon.rotation = Quaternion.Slerp(AttitudeHorizon.rotation, Quaternion.Euler(0, 0, LeftRight_), HorizonSpeed * Time.deltaTime);
        //AttitudeHorizon.localPosition = Vector3.Lerp(AttitudeHorizon.localPosition, Result_, HorizonSpeed * Time.deltaTime );

    }

}
