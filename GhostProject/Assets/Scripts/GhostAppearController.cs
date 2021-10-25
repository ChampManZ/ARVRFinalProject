using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostAppearController : MonoBehaviour
{
    public GameObject arCamera;
    //priva bool show_time = false;
    private bool timeer_show = false;
    public float show_time = 0;
    public bool have_act = false;
    public Animator ghostApAnim;
    public int rand_action = 1;
    public GameObject appearSound_one;
    public GameObject appearSound_two;
    public int playSound;
    //public AudioSource omasource;
    //public AudioClip omagrab;
    //private float spawn_time = 5; 
    //public GameObject keyitem;
    //public GameObject me;
    //public float countDist = 0;
    void Start()
    {
        Debug.Log("appear created");
        // ** make reference from object hierchy
        arCamera = GameObject.Find("AR Camera");
        transform.Rotate(0,180,0);
        rand_action = UnityEngine.Random.Range(0, 2);
        playSound= 0;
        // ** make obj invisable but still active
        //transform.GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in appear update");
    
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
            Debug.Log("appearing now");
            have_act = false;
            if (playSound== 0){
                ghostApAnim.SetInteger("setAct", rand_action);
            }
            if(rand_action == 0 && playSound == 0){
                Debug.Log("create sound 1");
                Instantiate(appearSound_one);
                playSound = 1;
            }else if (rand_action == 1 && playSound == 0){
                Debug.Log("create sound 2");
                Instantiate(appearSound_two);
                playSound = 1;
            }

            
        }
        GameObject myPlayer = GameObject.Find("AR Session Origin");
        SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();

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
        if(show_time >= 7){
            

            pScript.ishunting = 0;
            pScript.dummy_ghosttimer = UnityEngine.Random.Range(20, 40-pScript.reduce_spawn);
            Destroy(gameObject);
            

        }else if (show_time >= 3){
            
            if (pScript.cover_done != 1){
                pScript.haveLost = true;
            }
        }

        
    }
}
