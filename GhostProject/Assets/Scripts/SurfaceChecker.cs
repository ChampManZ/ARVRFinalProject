using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;



public class SurfaceChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public ARRaycastManager arRayCastMng;
    public TMPro.TextMeshProUGUI scoreCheck;
    public int scorecal = 0;
    public bool canPlace;
    private Pose placementPose;
    public GameObject placementIndicator;
    public GameObject planeMaster;
    public GameObject character;
    public bool placealt;
    public float timer_spawn = 5;
    //private float time_spawn;
    void Start()
    {
        //Instantiate(character, placementPose.position, placementPose.rotation);
        placementIndicator.transform.GetComponent<Renderer>().enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {   UpdatePlacementPose();
        UpdatePlacementIndicator();
        scoreCheck.text = "Collected: "+scorecal;
        //placementIndicator.transform.GetComponent<Renderer>().enabled =false;
        if (timer_spawn >= 0){
            timer_spawn -= Time.deltaTime;
        }
        
        Debug.Log("check check check");
        

        

        
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
                timer_spawn = 5;

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
    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }
}