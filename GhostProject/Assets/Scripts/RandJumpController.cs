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
    void Start()
    {
        Debug.Log("js manager created");
        js_one = GameObject.Find("Jumpscare_one");
        js_two = GameObject.Find("Jumpscare_two");
        int rand_act = UnityEngine.Random.Range(1, 3);
        if(rand_act == 1){
            Debug.Log("rand act1");
            js_one.SetActive(true);
            Instantiate(js_sound);
        }else if(rand_act == 2){
            Debug.Log("rand act2");
            js_two.SetActive(true);
            Instantiate(js_sound);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        jump_timer -= Time.deltaTime;
        if(jump_timer < 0){
            GameObject myPlayer = GameObject.Find("AR Session Origin");
            SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
            pScript.ishunting = 0;
            pScript.dummy_ghosttimer = UnityEngine.Random.Range(20, 40);
            js_one.SetActive(false);
            js_two.SetActive(false);
            Destroy(gameObject);
        }
    }
}
