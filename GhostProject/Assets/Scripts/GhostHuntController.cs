using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHuntController : MonoBehaviour
{
     public GameObject arCamera;
    private bool timeer_show = false;
    public int hunting = 0;

    void Start()
    {
        // ** make reference from object hierchy
        arCamera = GameObject.Find("AR Camera");
        // ** make obj invisable but still active
        transform.GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        
        // ** get distance between arcam and self
        float Dist = Vector3.Distance(arCamera.transform.position,transform.position);



        // ** push ghost away make ready to hunt
        if (Dist < 2 && timeer_show == false && hunting == 0){
            // ** fix this 
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        }

        // ** set can hunt when dist more than XX
        if (Dist >= 6 && hunting == 0){
            timeer_show = true;
            transform.GetComponent<Renderer>().enabled = true;
            hunting = 1;

        }

        // ** hunting part
        if (Dist <= 10 && hunting == 1){

        }
        
        // ** stop hunting
        if (Dist > 10 && hunting == 1){
            hunting = 3;
            Debug.Log("destroy item");
            Destroy(gameObject);

        }
        

        

        
    }
}
