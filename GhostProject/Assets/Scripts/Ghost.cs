using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.Experimental.XR;

public class Ghost : MonoBehaviour
{

    public GameObject ghost;
    [SerializeField] private float runTime;
    [SerializeField] private int gameTime;
    public float[] randomTimeSpawn;
    public int test = 0;
    [SerializeField] AudioSource ghostAppear;
    private bool playAppearOnce;

    // Start is called before the first frame update
    void Start()
    {
        randomTimeSpawn = new float[5];
        randomTimeSpawn[0] = Random.Range(10, 30);
        randomTimeSpawn[1] = Random.Range(50, 70);
        randomTimeSpawn[2] = Random.Range(100, 130);
        randomTimeSpawn[3] = Random.Range(150, 180);
        randomTimeSpawn[4] = Random.Range(180, 200);
    }

    // Update is called once per frame
    void Update()
    {
        runTime += 1 * Time.deltaTime;
        gameTime = Mathf.RoundToInt(runTime);

        if (randomTimeSpawn[0] == gameTime)
        {
            if (playAppearOnce)
            {
                ghostAppear.Play();
                playAppearOnce = false;
            }
            ghost.SetActive(true);
        }

        else if (randomTimeSpawn[1] == gameTime)
        {
            if (playAppearOnce)
            {
                ghostAppear.Play();
                playAppearOnce = false;
            }
            ghost.SetActive(true);
        }

        else if (randomTimeSpawn[2] == gameTime)
        {
            if (playAppearOnce)
            {
                ghostAppear.Play();
                playAppearOnce = false;
            }
            ghost.SetActive(true);
        }

        else if (randomTimeSpawn[3] == gameTime)
        {
            if (playAppearOnce)
            {
                ghostAppear.Play();
                playAppearOnce = false;
            }
            ghost.SetActive(true);
        }

        else if (randomTimeSpawn[4] == gameTime)
        {
            if (playAppearOnce)
            {
                ghostAppear.Play();
                playAppearOnce = false;
            }
            ghost.SetActive(true);
        } else
        {
            ghost.SetActive(false);
            playAppearOnce = true;
        }
    }
}