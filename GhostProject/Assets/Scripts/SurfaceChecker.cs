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
    public TMPro.TextMeshProUGUI buffStatus;
    public int scorecal = 0;
    public bool canPlace;
    private Pose placementPose;
    public GameObject placementIndicator;
    public GameObject planeMaster;
    public GameObject character;
    public GameObject crucifix;
    public GameObject chest;
    public GameObject searching_sound;
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
    public GameObject chestopenPref;
    public GameObject flashscreen;
    public bool flashingS = false;
    public bool haveLost = false;
    public bool haveWin = false;
    [SerializeField] private string gojumpLost;
    [SerializeField] private string goghostdie;
    public int cloverstate = 0;
    public float cloverrate = 1f;
    public int chestappear = 0;
    public int biblestate = 0;
    public float bible_timer = 60f;
    public float clover_timer = 60f;
    public GameObject GhostAppear;
    public GameObject MiniJumpS;
    public float life_timer;
    public int ext_hunt = 0;
    public int reduce_spawn = 0;
    public int chest_open = 0;
    public int grab_search = 0;
    public GameObject grab_clover;
    public GameObject grab_bible;
    public int grab_clover_state = 0;
    public int grab_bible_state = 0;
    public GameObject cover_obj;
    public int changingto = 0;
    public int cover_done = 1;
    public GameObject cover_sound;
    public int cover_using =0;
    //public int using_buff = 0;

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
            Debug.Log("win now");
            SceneManager.LoadScene(goghostdie);
            haveWin = false;
        }
        if(cloverstate == 0){
            cloverrate = 1f;
        }else{
            cloverrate = 2f;
        }

        if (cloverstate == 1 && clover_timer > 0){
            clover_timer -= Time.deltaTime;
        }else{
            cloverstate = 0;
            //clover_timer = 60f;
        }
        if(bible_timer >0 && biblestate == 1){
            bible_timer -= Time.deltaTime;
        }else{
            biblestate =0;
        }
        if(biblestate == 0 && cloverstate ==0){
            buffStatus.text = "Buff: No Buff";
        }else if(cloverstate == 1){
            buffStatus.text = "Buff: Lucky Time "+ System.Math.Round(clover_timer)+"s";
        }else if(biblestate == 1){
            buffStatus.text = "Buff: Safe Time "+System.Math.Round(bible_timer)+"s";
        }

    

        scoreCheck.text = "Collected: "+scorecal + " /10";


        if (scorecal >= 8){
            ext_hunt = 5;
            reduce_spawn = 20;
        }
        else if(scorecal >= 7){
            ext_hunt = 2;
            reduce_spawn = 15;
        }else if (scorecal >= 5){
            ext_hunt = 1;
            reduce_spawn = 10;
        }

        if(grabInst ==1){
            Instantiate(grabPref);
            //playerSource.PlayOneShot(grabsound);
            grabInst = 0;
        }
        if(chest_open == 1){
            Instantiate(chestopenPref);
            chest_open = 0;
        }
        if(grab_search == 1){
            Instantiate(searching_sound);
            grab_search = 0;
        }
        if(grab_bible_state == 1){
            Instantiate(grab_bible);
            grab_bible_state = 0;
        }
        if(grab_clover_state == 1){
            Instantiate(grab_clover);
            grab_clover_state =0;
        }
        if(cover_using == 1){
            Instantiate(cover_sound);
            cover_using = 0;
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
            timer_spawn -= Time.deltaTime*cloverrate;
        }
        if (ishaveflash == 0 && crucifix_timer >= 0){
            crucifix_timer -= Time.deltaTime*cloverrate;

        }
        if(crucifix_period >= 0){
            crucifix_period -= Time.deltaTime;
        }
        if(crucifix_period <= 0){
            using_crucifix = 0;
            crucifix_period = -1;
        }
        if (ishunting == 0 && dummy_ghosttimer >= 0){
            if (biblestate == 0){
            dummy_ghosttimer -= Time.deltaTime;
            }
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
    public void CoverToggle(){
        Debug.Log("enter toggle");
        if (cover_done == 1){
            Debug.Log("enter now its"+ cover_done +" changing to 2 from"+changingto );
            changingto = 2;
            cover_using = 1;
            cover_done = 0;
        }if (cover_done == 2){
            Debug.Log("enter now its"+ cover_done +" changing to 1 from"+changingto );
            changingto =1;
            cover_using = 1;
            cover_done = 0;
        }
    }
    // public void coverUp(){

    // }
    // public void coverDown(){
        
    // }
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
                
                int chest_rander = UnityEngine.Random.Range(1,2);
                if (chestappear == 0 && chest_rander == 1){
                    chestappear = 1;
                    Debug.Log("creating chest");
                    Instantiate(chest, placementPose.position, placementPose.rotation);
                    Debug.Log("create chest");

                }else{
                    Instantiate(character, placementPose.position, placementPose.rotation);
                }
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
                //if(biblestate ==0){
                    randomGhostAct();
                //}
                
                 

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
        int randAct = UnityEngine.Random.Range(1,4+ext_hunt);
        Debug.Log("random act of ghost event: "+ randAct);
        
        if (randAct == 1){
            

            Debug.Log("JumpScare Action");
            life_timer = 3f;
            Instantiate(MiniJumpS, placementPose.position, placementPose.rotation); 
        }else if (randAct == 2){
            Debug.Log("Appear Action");
            Instantiate(GhostAppear, placementPose.position, placementPose.rotation); 
        }else {
            Debug.Log("Hunt Action");
            
            Instantiate(GhostHunter, placementPose.position, placementPose.rotation); 
            //Instantiate(GhostAppear, placementPose.position, placementPose.rotation); 

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