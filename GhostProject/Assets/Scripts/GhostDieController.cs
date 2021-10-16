using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostDieController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string goWinResult;
    public float ghostdieTimer = 4;
    void Start()
    {
        ghostdieTimer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        ghostdieTimer -= Time.deltaTime;
        if (ghostdieTimer <= 0){
            SceneManager.LoadScene(goWinResult);
        }
        
    }
}
