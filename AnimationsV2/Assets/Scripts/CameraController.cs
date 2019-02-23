using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Watched Youtube Video: https://www.youtube.com/watch?v=nR5P7AH4aHE
public class CameraController : MonoBehaviour
{
    public GameObject tcam;
    public GameObject fcam;
    int CamMode;
    public Button Change;
    // Use this for initialization
    void Start()
    {
        fcam.SetActive(false);
        tcam.SetActive(true);
       
        Change.onClick.AddListener(ChangeView);
    }

    void ChangeView()
    {
        if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        
    }
    void Update()
    {
        Debug.Log(CamMode);
     
        /* if (Input.GetButtonDown("space"))
         {
             if (CamMode == 1)
             {
                 CamMode = 0;
             }
             else
             {
                 CamMode += 1;
             }
             StartCoroutine(CamChange());
         }
         */

    }
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CamMode == 0)
        {
            tcam.SetActive(true);
            fcam.SetActive(false);
        }if(CamMode == 1)
        {
            fcam.SetActive(true);
            tcam.SetActive(false);
        }
    }

    // Late update runs after all items have been processed in update
    void LateUpdate()
    {

    }

}