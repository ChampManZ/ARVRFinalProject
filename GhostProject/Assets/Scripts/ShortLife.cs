using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLife : MonoBehaviour
{
    // Start is called before the first frame update
    public float life_time = 3;
    void Start()
    {
        life_time = 3;
    }

    // Update is called once per frame
    void Update()
    {
        life_time -= Time.deltaTime;
        if (life_time < 0 ){
            life_time = 3;
            Destroy(gameObject);
        }
        
    }
}
