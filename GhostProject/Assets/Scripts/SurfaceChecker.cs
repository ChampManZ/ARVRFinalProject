using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.SceneManagement;



public class SurfaceChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public ARRaycastManager arRayCastMng;
    public TMPro.TextMeshProUGUI scoreCheck;
    public TMPro.TextMeshProUGUI crucifixStatus;
    public int scorecal = 0;
    public bool canPlace;
    private Pose placementPose;
    public GameObject placementIndicator;
    public GameObject planeMaster;
    public GameObject character;
    public GameObject crucifix;
    public bool placealt;
    public float timer_spawn = 5;
    public int ishaveflash = 0;
    public float crucifix_timer = 15;
    public int using_crucifix = 0;
    public float crucifix_period = -1;
    public GameObject GhostHunter;
    public float dummy_ghosttimer = 10;
    public int ishunting = 0;
    public AudioSource playerSource;
    public AudioClip flashsound;
    public AudioClip grabsound;
    public int grabInst = 0;
    public AudioClip test1;
    public GameObject flashPRef;
    public GameObject grabPref;
    public GameObject flashscreen;
    public bool flashingS = false;
    public bool haveLost = false;
    public bool haveWin = false;
    [SerializeField] private string gojumpLost;
    [SerializeField] private string goghostdie;
    //private float time_spawn;
    void Start()
    {
        //Instantiate(character, placementPose.position, placementPose.rotation);
        placementIndicator.transform.GetComponent<Renderer>().enabled = false;
        dummy_ghosttimer = 15;
        //playerSource.PlayOneShot(test1);
        
        
    }

    // Update is called once per frame
    void Update()
    {   UpdatePlacementPose();
        UpdatePlacementIndicator();
        
        if (haveLost == true){
            SceneManager.LoadScene(gojumpLost);
            haveLost = false;
        }
        if (haveWin == true){
            SceneManager.LoadScene(goghostdie);
            haveWin = false;
        }


    

        scoreCheck.text = "Collected: "+scorecal + " /10";

        if(grabInst ==1){
            Instantiate(grabPref);
            //playerSource.PlayOneShot(grabsound);
            grabInst = 0;
        }

        if (using_crucifix == 0 && ishaveflash == 0){
            crucifixStatus.text = "Have No Crucifix";
        }else if(using_crucifix ==0 && ishaveflash == 1){
            crucifixStatus.text = "Have Unused Crucifix";
        }
        else if(using_crucifix ==1){
            crucifixStatus.text = "Using Crucifix";
        }
        //placementIndicator.transform.GetComponent<Renderer>().enabled =false;
        if (timer_spawn >= 0){
            timer_spawn -= Time.deltaTime;
        }
        if (ishaveflash == 0 && crucifix_timer >= 0){
            crucifix_timer -= Time.deltaTime;

        }
        if(crucifix_period >= 0){
            crucifix_period -= Time.deltaTime;
        }
        if(crucifix_period <= 0){
            using_crucifix = 0;
            crucifix_period = -1;
        }
        if (ishunting == 0 && dummy_ghosttimer >= 0){
            dummy_ghosttimer -= Time.deltaTime;
        }
        
        Debug.Log("check check check");
        if (scorecal >= 10){
            scorecal = 10;
            Debug.Log("win");
            haveWin = true;
            
        }
        
        if (flashingS == true){
            flashscreen.SetActive(true);
            flashingS = false;
        }
        if (flashingS == false){
            flashscreen.SetActive(false);
        }
        

        

        
    }

    public void SpawnCharacter(){
        //Debug.Log("Spawn Check");
        if(canPlace){
            //Debug.Log("Create Character");
            //DestroyWithTag("charac");
            Instantiate(character, placementPose.position, placementPose.rotation);
            
            // character.transform.position = new Vector3(placementPose.position.x, placementPose.position.y, placementPose.position.z);
            // character.transform.rotation = placementPose.rotation;

        }
    }
    public void useCrucifix(){
        //playerSource.PlayOneShot(test1);
        //playerSource.PlayOneShot(flashsound);
        if (ishaveflash == 1){
            Instantiate(flashPRef);
            //playerSource.PlayOneShot(flashsound);
            ishaveflash = 0;
            using_crucifix = 1;
            crucifix_period = 1;
        }

    }

    private void UpdatePlacementPose(){
        //Debug.Log("Update Pose Check");
        Vector3 ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0f));
        List<ARRaycastHit>hits = new List<ARRaycastHit>();
        arRayCastMng.Raycast(ScreenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        canPlace = hits.Count >0;
        Debug.Log(canPlace);
        if (canPlace){
            //Debug.Log("PlacePose Update");
            placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x,0f,cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
        
    }
    private void UpdatePlacementIndicator(){
        //Debug.Log("Update Placement Check");
        if(canPlace){
            Debug.Log("Place Ind");
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position,placementPose.rotation);
            //placementIndicator.transform.SetPositionAndRotation(new Vector3(placementPose.position.x, placementPose.position.y, placementPose.position.z+10),placementPose.rotation);
            //placementIndicator.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+10);
            //placementIndicator.transform.position = new Vector3(placementPose.position.x, placementPose.position.y, placementPose.position.z+10);
            if (timer_spawn <= 0){
                Instantiate(character, placementPose.position, placementPose.rotation);
                //Instantiate(character, placementIndicator.transform.position, placementIndicator.transform.rotation);
                //Instantiate(character, planeMaster.transform.position, planeMaster.transform.rotation);
                timer_spawn = UnityEngine.Random.Range(20,50);

            }
            if (crucifix_timer <= 0 && ishaveflash == 0){
                crucifix_timer = UnityEngine.Random.Range(4,6);
                Instantiate(crucifix, placementPose.position, placementPose.rotation);  
            }
            if (ishunting == 0 && dummy_ghosttimer < 0){
                //crucifix_timer = UnityEngine.Random.Range(15,40);
                ishunting = 1;
                Debug.Log("Create Ghost");
                randomGhostAct();
                 

            }
            
            if (placealt == false)
            {
                //Instantiate(character, placementPose.position, placementPose.rotation);
                placealt = true;
            }
            

        }else{
            //Debug.Log("Cant Place Ind");
            placementIndicator.SetActive(false);
        }

    }
    public void randomGhostAct(){
        int randAct = UnityEngine.Random.Range(1,4);
        
        if (randAct == 1){
            Debug.Log("Hunt Action");
            
            Instantiate(GhostHunter, placementPose.position, placementPose.rotation); 
        }else if (randAct == 2){
            Debug.Log("Appear Action");
            Instantiate(GhostHunter, placementPose.position, placementPose.rotation); 
        }else {
            Debug.Log("JumpScare Action");
            Instantiate(GhostHunter, placementPose.position, placementPose.rotation); 

        }

    }
    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }
}