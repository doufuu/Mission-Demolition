/***
 * Created by:Kangjie Ouyang
 * Date Created:2/14/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/14/22
 * 
 * Description: generate multiple clouds
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour
{

    //Variables
    [Header("Set in Inspector")]
    public int numberOfClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 cloudPositionMin = new Vector3(-50, -5, 10);
    public Vector3 cloudPositionMax = new Vector3(150, 100, 10);
    public float cloudScaleMin = 1;
    public float cloudScaleMax = 3;
    public float cloudSpeedMultiplier = 0.5f;


    private GameObject[] cloudInstances;



    private void Awake()
    {
        cloudInstances = new GameObject[numberOfClouds];
        GameObject anchor = GameObject.Find("CloudAnchor");

        GameObject cloud;

        for (int i = 0; i < numberOfClouds; i++)
        {
            cloud = Instantiate<GameObject>(cloudPrefab);

            //position cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPositionMin.x, cloudPositionMax.x);
            cPos.y = Random.Range(cloudPositionMin.y, cloudPositionMax.y);


            //scale clouds
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);



            cPos.y = Mathf.Lerp(cloudPositionMin.y, cPos.y, scaleU); //smaller clouds with smaller scale closer to the ground
            cPos.z = 100 - 90 * scaleU; // Smaller clouds should be further away
            cloud.transform.position = cPos; // Apply these transforms to the cloud
            cloud.transform.localScale = Vector3.one * scaleVal;
            cloud.transform.SetParent(anchor.transform); // Make cloud a child of the anchor

            cloudInstances[i] = cloud; // Add the cloud to cloudInstances



        }


    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Iterate over each cloud that was created
            foreach (GameObject cloud in cloudInstances)
        {
            // Get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x; 
            Vector3 cPos = cloud.transform.position;
            // Move larger clouds faster
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMultiplier; // If a cloud has moved too far to the left...
            if (cPos.x <= cloudPositionMin.x)
            {
                // Move it to the far right
                cPos.x = cloudPositionMax.x;
            }
            // Apply the new position to cloud
             cloud.transform.position = cPos;
        } 
    }
    }
