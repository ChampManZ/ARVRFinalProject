using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandJumpController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jump_timer = 3;
    public GameObject js_one;
    public GameObject js_two;
    public GameObject js_sound;
    public int already_act = 0;
    public int canCountdown = 0;
    public int rand_act;
    public int ald_show = 0;
    public GameObject plate_master;
    void Start()
    {
        Debug.Log("js manager created");
        //js_one = GameObject.Find("Jumpscare_one");
        //js_two = GameObject.Find("Jumpscare_two");
        plate_master = GameObject.Find("JumpPlate");
        rand_act = UnityEngine.Random.Range(1, 3);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("js in update");
        if (already_act == 0){
        Debug.Log("js act choose");
        
        if(rand_act == 1 && ald_show ==0){

            Debug.Log("rand act1");
            ald_show = 1;
            //js_one.SetActive(true);
            Instantiate(js_one, plate_master.transform.position, plate_master.transform.rotation); 
            Instantiate(js_sound);
        }else if(rand_act == 2 && ald_show == 0){
            Debug.Log("rand act2");
            ald_show = 1;
            //js_two.SetActive(true);
            Instantiate(js_two, plate_master.transform.position, plate_master.transform.rotation); 
            Instantiate(js_sound);
        }
        already_act = 1;
        canCountdown = 1;
        Debug.Log("js act choose done");
        }
        if (canCountdown == 1){

        
        jump_timer -= Time.deltaTime;
        if(jump_timer < 0){
            GameObject myPlayer = GameObject.Find("AR Session Origin");
            SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
            pScript.ishunting = 0;
            pScript.dummy_ghosttimer = UnityEngine.Random.Range(20, 40-pScript.reduce_spawn);
            //js_one.SetActive(false);
            //js_two.SetActive(false);
            Destroy(gameObject);
        }
        }
    }
}
