/***
 * Created by:Kangjie Ouyang
 * Date Created:2/9/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/9/22
 * 
 * Description: Slingshot game object creations
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //Variables
    static private Slingshot S;


    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultipler = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile; //instance of projectile
    public bool aimingMode; //is player aiming
    public Rigidbody projectileRB; //rigidbody of the projectile


    static public Vector3 Launch_Pos
    {
        get
        {
            if (S == null)
                return Vector3.zero;

            return S.launchPos;

        }
    }


    private void Awake()
    {

        S = this;

        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false); //disable launchPoint
        launchPos = launchPointTrans.position; //position of launch point 
        
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!aimingMode) return; //if not aiming exit update

        //get mouse position from 2D coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit the mouseDelta to slingshot collider radius 
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if (mouseDelta.magnitude > maxMagnitude) 
        {
            mouseDelta.Normalize(); //sets the vector to the same direction but a length of 1
            mouseDelta *= maxMagnitude;
        }

        //Move projectile to new position 
        Vector3 projectilePos = launchPos + mouseDelta;
        projectile.transform.position = projectilePos;

        if (Input.GetMouseButtonUp(0)) 
        {
            //mouse button has been released
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultipler;
            FollowCam.POI = projectile;
            projectile = null; //emptys reference to instance projectile
            MissionDemolition.ShotFired(); // a
            ProjectileLine.S.poi = projectile; // b


        }

    }


    private void OnMouseEnter()
    {
        launchPoint.SetActive(true); //enable launchPoint
        print("Slingshot: OnMouseEnter");
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false); //disable launchPoint
        print("Slingshot: OnMouseExit");
    }

    private void OnMouseDown()
    {
        aimingMode = true; //player is aiming
        projectile = Instantiate(prefabProjectile) as GameObject; //instantiate projectile instance
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;


    }



}
