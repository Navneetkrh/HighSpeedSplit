using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarAssistant : MonoBehaviour
{
    public bool isPlayerOne;
    public Camera camera_tpp, camera_fpp;
    private bool isFPP = false;
    void Start()
    {
        if (GameManager.isTwoPlayers)
        {
            if (isPlayerOne)
            {
                camera_tpp.rect = new Rect(0, 0, 0.495f, 1);
                camera_fpp.rect = new Rect(0, 0, 0.495f, 1);
            }
            else
            {
                camera_tpp.rect = new Rect(0.505f, 0, 0.495f, 1);
                camera_fpp.rect = new Rect(0.505f, 0, 0.495f, 1);
                
            }
            GetComponent<CarUserControl>().isPlayerOne = isPlayerOne;
        }
        camera_fpp.enabled = false;
        camera_tpp.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPlayerOne)
            {
                ChangeCamera();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Backslash))
        {
            if (!isPlayerOne)
            {
                ChangeCamera();
            }
        }
    }

    void ChangeCamera()
    {
     if (isFPP)
    {
       // camera_fpp.gameObject.GetComponentInParent<BoxCollider>().gameObject.SetActive(false);
        camera_fpp.enabled = false;
        camera_tpp.enabled = true;
       // camera_tpp.gameObject.GetComponentInParent<BoxCollider>().gameObject.SetActive(true);
        isFPP = false;
    }
    else
    {
      //  camera_fpp.gameObject.GetComponentInParent<BoxCollider>().gameObject.SetActive(true);
      // camera_tpp.gameObject.GetComponentInParent<BoxCollider>().gameObject.SetActive(false);
      camera_fpp.enabled = true;
      camera_tpp.enabled = false;
        isFPP = true;
    }
    }
}
