/***
 * Created by:Kangjie Ouyang
 * Date Created:2/16/22
 * 
 * Last Edited by: NA
 * Last Edited:  2/16/22
 * 
 * Description: Put rigidbody to sleep (1 frame)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodtSleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
