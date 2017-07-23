using UnityEngine;
using System.Collections;

public class Altimeter : MonoBehaviour
{
    public GameObject cockpit;
    public float FixGround = 0f;
    public float FixPointerPos1 = 0f;

    private RectTransform point_100 = null;
    private RectTransform point_1000 = null;

    private RaycastHit hit = new RaycastHit();

    // Use this for initialization
    void Start ()
    {
        point_100 = GameObject.Find("Altimeter_Needle").GetComponent<RectTransform>();
        point_1000 = GameObject.Find("Altimeter_Needle_1k").GetComponent<RectTransform>();

        //point_100.rotation = Quaternion.Slerp(point_100.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 100f * Time.deltaTime);
        //point_1000.rotation = Quaternion.Slerp(point_1000.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 100f * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Physics.Raycast(cockpit.transform.position, -Vector3.up, out hit))
        {
            float cleanpos = 0;
            float hitDistance = hit.distance / 0.3048f;
            float Disfeet = Mathf.Abs(hitDistance) * -1f;

            if (Disfeet < FixGround)
            {
                point_100.transform.rotation = Quaternion.Slerp(point_100.transform.rotation, Quaternion.Euler(0, 0, Disfeet * 3.53f - cleanpos), 10f * Time.deltaTime);
                point_1000.transform.rotation = Quaternion.Slerp(point_1000.transform.rotation, Quaternion.Euler(0, 0, Disfeet / 2.789f - cleanpos), 2f * Time.deltaTime);

            }
            else
            {
                point_1000.rotation = Quaternion.Slerp(point_1000.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 5f * Time.deltaTime);
                point_100.rotation = Quaternion.Slerp(point_100.rotation, Quaternion.Euler(0, 0, FixPointerPos1), 5f * Time.deltaTime);
            }
        }

    }
}
