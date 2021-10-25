using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    // Start is called before the first frame update
    //public int stopstate = 1;
    public float top;
    public float bottom;
    public float rate;
    void Start()
    {
        top = 575;
        bottom = -1100;
        rate = 60;
        transform.position = new Vector3(transform.position.x, bottom, transform.position.z);
        
    }

    // Update is called once per frame
    // -6 -15
    void Update()
    {
        GameObject myPlayer = GameObject.Find("AR Session Origin");
        SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
        Debug.Log("enter current pos y of board "+transform.position.y);
        if (pScript.changingto == 1|| pScript.changingto == 2){
            Debug.Log("enter cover func");
            // start covdone = 1
            if (pScript.changingto == 2 && transform.position.y > bottom){
                Debug.Log("enter cover going down");
                pScript.cover_done =0;
                transform.position = new Vector3(transform.position.x, transform.position.y-rate, transform.position.z);
            }else if (pScript.changingto == 2 && transform.position.y <= bottom){
                Debug.Log("enter cover have down");
                
                pScript.changingto = 0;
                pScript.cover_done = 2;
                transform.position = new Vector3(transform.position.x, bottom, transform.position.z);
                Debug.Log("enter now its"+ transform.position.y + " with cover state "+ pScript.cover_done );

            }
            // start covdone = 2
            else if (pScript.changingto ==1 && transform.position.y < top){
                Debug.Log("enter cover going up");
                pScript.cover_done =0;
                transform.position = new Vector3(transform.position.x, transform.position.y+rate, transform.position.z);

            }
            else if (pScript.changingto ==1 && transform.position.y >= top){
                Debug.Log("enter cover have up");
                pScript.cover_done =1;
                pScript.changingto = 0;
                transform.position = new Vector3(transform.position.x, top, transform.position.z);
                Debug.Log("enter now its"+ transform.position.y + " with cover state "+ pScript.cover_done );

            }
        }
        
        // if (toggle_cover == 1 && mystate == 0){
        //     Debug.Log("to go up")
        // }
    }
}
