using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedChestController : MonoBehaviour
{
    // Start is called before the first frame update
    public float search_timer = 3;
    public int ald_open = 0;
    public GameObject clover_obj;
    public GameObject bible_obj;
    public bool sound_play_ald = true;
    void Start()
    {
        Debug.Log("opening");
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myPlayer = GameObject.Find("AR Session Origin");
        SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
        if (sound_play_ald == true){
            Debug.Log("play sound");
            pScript.grab_search =1;
            sound_play_ald = false;
            Debug.Log("play sound end");
        }
        search_timer -= Time.deltaTime;
        if (search_timer <= 0 && ald_open == 0){
            Debug.Log("create buff");
            ald_open = 1;
            
            int buff_rander = UnityEngine.Random.Range(1,3);
            if (buff_rander == 1){
                Instantiate(clover_obj, transform.position, transform.rotation);
            }else{
                Instantiate(bible_obj, transform.position, transform.rotation);
            }
            Debug.Log("create buff done");
            
        }
    }
}
