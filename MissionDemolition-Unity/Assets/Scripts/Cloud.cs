/***
 * Created by:Kangjie Ouyang
 * Date Created:2/14/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/14/22
 * 
 * Description: randomly generate a cloud
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    //Variables
    [Header("Set in Inspector")]

    public GameObject cloudSphere;
    public int numberOfSphereMin = 6;
    public int numberOfSphereMax = 10;
    public Vector2 sphereScaleRangeX = new Vector2(4,8);
    public Vector2 sphereScaleRangeY = new Vector2(3,4);
    public Vector2 sphereScaleRangeZ = new Vector2(2,4);
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public float scaleYmin = 2f;

    private List<GameObject> spheres;



    // Start is called before the first frame update
    void Start()
    {
        spheres = new List<GameObject>();

        int num = Random.Range(numberOfSphereMin, numberOfSphereMax);

        for (int i = 0; i < num; i++) 
        {
            GameObject sp = Instantiate<GameObject>(cloudSphere);
            spheres.Add(sp);

            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            //Randomly assign a position
            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTrans.localPosition = offset;

            //Randomly assign scale
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeY.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);


            //Adjust y scale by x distance from core
            scale.y *= 1 - (Mathf.Abs(offset.x)/sphereOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYmin);

            spTrans.localScale = scale;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        /*//keypress spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }*/





    }



    void Restart() 
    {
        foreach (GameObject sp in spheres) 
        {
            Destroy(sp);   
        }

        Start();


    }
}
