using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHuntController : MonoBehaviour
{
    public GameObject arCamera;
    private bool timeer_show = false;
    public int hunting = 0;
    [SerializeField] private float speed = 1;
    public float stunt_time = 7;
    public int scream_before_hunt = 0;
    //public TMPro.TextMeshProUGUI dist_text;
    //public GameObject textcall;
    public Animator ghostAnim;
    public AudioSource[] ghostSFX;
    private bool playHuntSFXOnce;
    private bool playScreamSFXOnce;
    private bool playLostSFXOnce;
    private bool initialScream = false;
    private float scream_timer = 4;
    public AudioSource HuntSound;
    public AudioClip init_Scream_s;
    public AudioClip stunt_Scream_s;
    


    void Start()
    {
        // ** make reference from object hierchy
        arCamera = GameObject.Find("AR Camera");
        transform.Rotate(0,180,0);
        
        // ** make obj invisable but still active
        transform.GetComponent<Renderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myPlayer = GameObject.Find("AR Session Origin");
        SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
        Debug.Log("hunter begin");
        if (hunting == 4 && stunt_time >= 0){
            stunt_time -= Time.deltaTime;
        }
        if (hunting == 4 && stunt_time <= 4){
            stunt_time -= Time.deltaTime;
            ghostAnim.SetInteger("HuntAct", 3);
        }
        if (hunting == 4 && stunt_time < 0){
            hunting = 1;
            stunt_time = 7;
            ghostAnim.SetInteger("HuntAct", 0);

        }

        
        // ** get distance between arcam and self
        //dis_text = GameObject.Find("textcaller");
        float Dist = Vector3.Distance(arCamera.transform.position,transform.position);
        Debug.Log(Dist);
        //dist_text.text = "Dist Ghost: "+Dist;



        // ** push ghost away make ready to hunt
        if (Dist < 5 && timeer_show == false ){
            if (hunting == 0){
            // ** fix this 
            Debug.Log("moving away");
            Debug.Log(Dist);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
            }
        }

        // ** set can hunt when dist more than XX
        if (Dist >= 5 && hunting == 0){
            Debug.Log("can hunt now");
            Debug.Log(Dist);
            Debug.Log("can hunt now 2");
            timeer_show = true;
            Debug.Log("can hunt now 3");
            //transform.GetComponent<Renderer>().enabled = true;
            ghostAnim.SetInteger("HuntAct", 1);
            Debug.Log("can hunt now 4");
            initialScream = true;
            HuntSound.PlayOneShot(init_Scream_s);
            //hunting = 1;
            Debug.Log("can hunt now 5");
        }
        if (scream_timer > 0 && initialScream == true){
            scream_timer -= Time.deltaTime;
        }
        if (scream_timer < 0 && initialScream == true){
            hunting = 1;
            initialScream = false;
        }

        // ** hunting part
        if (Dist <= 8 && hunting == 1)
        {
            ghostAnim.SetInteger("HuntAct", 0);
            //if (playHuntSFXOnce)
            //{
                Debug.Log("hunting to you");
                Debug.Log(Dist);

                if (Dist <= 1 && hunting == 1)
                {
                    //game_status.text = "Game Over";
                    hunting = 3;
                    speed = 0;
                    Destroy(gameObject);
                    // if (playLostSFXOnce)
                    // {
                    //     ghostSFX[3].Play();
                    //     playLostSFXOnce = false;
                    // }
                    //Debug.Log(Dist);
                }
                else if (Dist <= 3 && hunting == 1 && pScript.using_crucifix == 1)
                {
                    Debug.Log(Dist);
                    hunting = 4;
                    ghostAnim.SetInteger("HuntAct", 2);
                    HuntSound.PlayOneShot(stunt_Scream_s);

                    // if (playScreamSFXOnce)
                    // {
                    //     ghostSFX[2].Play();
                    //     //playScreamSFXOnce = false;
                    // }
                }
                else
                {
                    Debug.Log(Dist);
                    Debug.Log("still moving to you");
                    transform.position = Vector3.MoveTowards(transform.position, arCamera.transform.position, Time.deltaTime * speed);

                    transform.LookAt(arCamera.transform.position, -Vector3.up);
                    // then lock rotation to Y axis only...
                    transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y,0);

                    //var yRotation = transform.eulerAngles.y;
                    //transform.Rotate(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);


                    //ghostSFX[1].Play();
                }
                //playHuntSFXOnce = false;
           // }
        }

        // ** stop hunting
        if (hunting == 4 || hunting == 1){
            if (Dist >= 8){
                Debug.Log(Dist);
                hunting = 3;
                Debug.Log("destroy item");
                pScript.ishunting = 0;
                pScript.dummy_ghosttimer = UnityEngine.Random.Range(20, 40);
                Destroy(gameObject);

                //playHuntSFXOnce = true;
                //playScreamSFXOnce = true;
                //playLostSFXOnce = true;
            }  

        }
        

        Debug.Log(Dist);
        

        
    }
}
