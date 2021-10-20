using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLife : MonoBehaviour
{
    // Start is called before the first frame update
    //public float life_time = 3;
    void Start()
    {
        //life_time = 3;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject myPlayer = GameObject.Find("AR Session Origin");
        SurfaceChecker pScript = myPlayer.GetComponent<SurfaceChecker>();
        pScript.life_timer -= Time.deltaTime;
        if (pScript.life_timer < 0 ){
            pScript.life_timer = 3f;
            Destroy(gameObject);
        }
        
    }
}
