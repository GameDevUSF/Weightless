using UnityEngine;
using System.Collections;

public class C185_Gyro: MonoBehaviour {
 public Transform cockpit = null;
 private RectTransform Gyro_ = null;
 private RectTransform GyroHead_ = null;
 private float curSpin = 0f;
 
 
	// Use this for initialization
	void Start () {
		Gyro_ = GameObject.Find("Directional_Gyro_Card").GetComponent<RectTransform>();
		GyroHead_ = GameObject.Find("Gyro_Head").GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		float _routa = cockpit.root.rotation.eulerAngles.y -360f;
		curSpin += 100f * Input.GetAxis("Mouse ScrollWheel") * 10f * Time.deltaTime;
		
		Gyro_.localRotation = Quaternion.Slerp(Gyro_.localRotation, Quaternion.Euler(0, 0,_routa), 2f * Time.deltaTime);

		
	}
	
	public void HDG(){
		
		if (curSpin > -180f && curSpin < 180f ){			
			
			GyroHead_.rotation = Quaternion.Slerp(GyroHead_.rotation, Quaternion.Euler(0, 0, curSpin),90f * Time.deltaTime);
			
		}else if(curSpin > -180f){
			curSpin=-180f;
		}else if(curSpin < 180f){
			curSpin=180f;
		}

		
	}
}
