using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppearController : MonoBehaviour
{
    public GameObject arCamera;
    //priva bool show_time = false;
    private bool timeer_show = false;
    public float show_time = 0;
    public bool have_act = false;
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
        
    }

    // Update is called once per frame
    void Update()
    {
    
        float Dist = Vector3.Distance(arCamera.transform.position,transform.position);

        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);



        if (Dist < 4 && timeer_show == false){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
        }
        if (Dist >= 4){
            timeer_show = true;
            have_act = true;
            //transform.GetComponent<Renderer>().enabled = true;

        }

        if(have_act == true){
            have_act = false;
            
        }
        

        // if (Dist < 1 && timeer_show == true){
        //     Debug.Log("destroy item");
        //     // ** get public variables
        //     GameObject myPlayer = GameObject.Find("AR Session Origin");
        //     SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
        //     pScript.scorecal += 1;
        //     pScript.grabInst =1;
        //     //omasource.PlayOneShot(omagrab);
            

        // }
        if (timeer_show == true){
            show_time += Time.deltaTime;
        }
        if(show_time >= 5){
            GameObject myPlayer = GameObject.Find("AR Session Origin");
            SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
            pScript.ishunting = 0;
            pScript.dummy_ghosttimer = UnityEngine.Random.Range(20, 40);
            Destroy(gameObject);
            

        }

        
    }
}
