using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera thirdpersonCam;
    [SerializeField] private CinemachineVirtualCamera sideviewCam;
    [SerializeField] private CinemachineVirtualCamera firstpersonCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            thirdpersonCam.gameObject.SetActive(false);
            firstpersonCam.gameObject.SetActive(false);
        }
    }
}
