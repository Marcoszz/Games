using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Camera cam;
    public Transform playerTransform;
    public float speedCam;

    public Transform limiteCamEsq, limiteCamDir, limiteCamSup, limiteCamInf;

    void Start()
    {

        cam = Camera.main;
        
    }


    void Update()
    {
        
    }

    void LateUpdate(){

        float posCamX = playerTransform.position.x;
        float posCamY = playerTransform.position.y;

        if (cam.transform.position.x < limiteCamEsq.position.x && playerTransform.position.x < limiteCamEsq.position.x) {
            posCamX = limiteCamEsq.position.x;
        } else if (cam.transform.position.x > limiteCamDir.position.x && playerTransform.position.x > limiteCamDir.position.x) {
            posCamX = limiteCamDir.position.x;
        }

        if (cam.transform.position.y < limiteCamInf.position.y && playerTransform.position.y < limiteCamInf.position.y) {
            posCamY = limiteCamInf.position.y;
        } else if (cam.transform.position.y > limiteCamSup.position.y && playerTransform.position.y > limiteCamSup.position.y) {
            posCamY = limiteCamSup.position.y;
        }

        Vector3 posCam = new Vector3(posCamX, posCamY, cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position, posCam, speedCam * Time.deltaTime);
    }
}
