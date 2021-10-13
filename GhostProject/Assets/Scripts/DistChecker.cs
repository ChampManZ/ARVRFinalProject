using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistChecker : MonoBehaviour
{
    // Start is called before the first frame update
    //public TMPro.TextMeshProUGUI distCheck;
    public GameObject arCamera;
    //priva bool show_time = false;
    private bool timeer_show = false;
    //private float spawn_time = 5; 
    //public GameObject keyitem;
    //public GameObject me;
    //public float countDist = 0;
    void Start()
    {
        arCamera = GameObject.Find("AR Camera");
        transform.GetComponent<Renderer>().enabled = false;
        
        
        //distCheck.text = "Hello Distance...";
        // float Dist = Vector3.Distance(Camera.main.transform.position,transform.position);
        // Debug.Log("Dist is: "+ Dist);
        // distCheck.text = "Dist: "+ Dist;
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawn_time -= Time.deltaTime;
        // if (spawn_time <= 0 ){
        //     //spawn_time = 0;
        //     Instantiate(keyitem ,new Vector3( transform.position.x , transform.position.y,transform.position.z ), this.transform.rotation);
        //     spawn_time = 5;
        // }

        Debug.Log("brabrabrbarb*****");
        // float Dist = Vector3.Distance(Camera.main.transform.position,me.transform.position);
        
        float Dist = Vector3.Distance(arCamera.transform.position,transform.position);
        // if (Dist < 5){
        //     transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        // }
        // if(Dist >= 5){
        //     show_time = true;
        //     transform.GetComponent<Renderer>().enabled = true;
        // }
        //float Dist = (Camera.main.transform.position-transform.position).magnitude;
        //Debug.Log("Dist is: "+ Dist);
        //distCheck.text = "Dist: "+ Dist.ToString("F1");
        //distCheck.text = "Dist: "+ Dist;
        // if(show_time == true){
        //     if (Dist < 1){
        //     Debug.Log("destroy item");
        //     Destroy(gameObject);
        // }

        //}
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        if (Dist < 2 && timeer_show == false){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        }
        if (Dist >= 2){
            timeer_show = true;
            transform.GetComponent<Renderer>().enabled = true;

        }

        if (Dist < 1 && timeer_show == true){
            Debug.Log("destroy item");
            GameObject myPlayer = GameObject.Find("AR Session Origin");
            SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
            pScript.scorecal += 1;
            Destroy(gameObject);
        }
        

        
    }
}
