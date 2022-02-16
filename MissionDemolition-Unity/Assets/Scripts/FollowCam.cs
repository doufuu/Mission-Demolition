/***
 * Created by:Kangjie Ouyang
 * Date Created:2/9/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/14/22
 * 
 * Description: Camera follow controlls
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //Variables
    static public GameObject POI; //static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f; //amount of ease
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; //the desired Z pos of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;

    }


    private void FixedUpdate()
    {
        /*        if (POI == null) return; //if no point of interest exit update

                Vector3 destination = POI.transform.position; //get position of the POI 
        */

        Vector3 destination; //destination of POI
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else 
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile") 
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping()) 
                {
                    POI = null;
                }
            }
        }



        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);


        destination = Vector3.Lerp(transform.position, destination, easing); //interpolat from current camera position towards destination
        
        destination.z = camZ;  //reset the z of the destination to the camera z
        transform.position = destination; // set position of the camera to the destination


        Camera.main.orthographicSize = destination.y + 10; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
