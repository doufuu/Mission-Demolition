/***
 * Created by:Kangjie Ouyang
 * Date Created:2/9/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/9/22
 * 
 * Description: Camera to follow object
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //Variables
    static public GameObject POI; //static point of interest


    public float camZ; //the desired Z pos of the camera

    private void Awake()
    {
        camZ = this.transform.position.z;

    }


    private void FixedUpdate()
    {
        if (POI == null) return; //if no point of interest exit update

        Vector3 destination = POI.transform.position;
        destination.z = camZ;
        transform.position = destination;

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
