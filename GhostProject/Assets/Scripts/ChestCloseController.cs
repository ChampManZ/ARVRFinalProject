using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCloseController : MonoBehaviour
{
    public GameObject arCamera;
    //priva bool show_time = false;
    private bool timeer_show = false;
    [SerializeField] private float speed = 1;
    public GameObject openChest;
    //public AudioSource omasource;
    //public AudioClip omagrab;
    //private float spawn_time = 5; 
    //public GameObject keyitem;
    //public GameObject me;
    //public float countDist = 0;
    void Start()
    {
        // ** make reference from object hierchy
        arCamera = GameObject.Find("AR Camera");
        // ** make obj invisable but still active
        //transform.GetComponent<Renderer>().enabled = false;
        speed = 2;
        
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
        
        // ** get distance between arcam and self
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
            //transform.GetComponent<Renderer>().enabled = true;

        }
        

        if (Dist < 2 && timeer_show == true){
            //transform.position = Vector3.MoveTowards(transform.position, arCamera.transform.position, Time.deltaTime * speed);
            // ** get public variables
            Instantiate(openChest,transform.position, transform.rotation);
            GameObject myPlayer = GameObject.Find("AR Session Origin");
            SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
            pScript.chest_open =1;
            Destroy(gameObject);
            

        }
        // if (Dist <= 0.1 ){
        //     // Debug.Log("destroy item");
        //     // GameObject myPlayer = GameObject.Find("AR Session Origin");
        //     // SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
        //     // pScript.scorecal += 1;
        //     // pScript.grabInst =1;
        //     //omasource.PlayOneShot(omagrab);
            

        // }
        // GameObject myPlayer = GameObject.Find("AR Session Origin");
        // SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();

        // if(Dist <= 3 && pScript.using_crucifix == 1){

        // }
        

        
    }
}
