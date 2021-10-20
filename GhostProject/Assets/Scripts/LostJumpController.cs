using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostJumpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string goLostResult;
    public float lostjumpTimer = 4;

    void Start()
    {
        lostjumpTimer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        lostjumpTimer -= Time.deltaTime;
        if (lostjumpTimer <= 0){
            SceneManager.LoadScene(goLostResult);
        }
        
    }
}
