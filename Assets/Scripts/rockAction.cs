using UnityEngine;
using System.Collections;

public class rockAction : MonoBehaviour
{
    public GameObject platform;
    public float speed;
    public Transform cpoint;

    public Transform[] points;
    public int pointChoice;

	 void Start()
	{
        cpoint = points[pointChoice];
	}

	void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, cpoint.position, Time.deltaTime * speed);

        //choose position to be back
        if(platform.transform.position == cpoint.position){
            //go through each point
            pointChoice ++;
            //check whether it is the end point
            if(pointChoice == points.Length){
                pointChoice = 0;
            }
            //reset after every frame to move on
            cpoint = points[pointChoice];
        }
    }
}