using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandJumpController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jump_timer = 3;
    void Start()
    {
        int rand_act = UnityEngine.Random.Range(1, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        jump_timer -= Time.deltaTime;
        if(jump_timer < 0){
            Destroy(gameObject);
        }
    }
}
