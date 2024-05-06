using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SlowTime : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform PlayerTransform;
    public ParticleSystem RedFlash;
    void Start()
    {
        //search Scene for Player
        PlayerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerTransform)
        {
            return;
        }

        var diffV= Vector3.Distance(PlayerTransform.position, this.transform.position);
        if (diffV < 4.5)
        {
            if (!RedFlash.isPlaying)
            {
                RedFlash.Play();
            }
        }
        //bool isGoingToHitPlayer

    }
}
