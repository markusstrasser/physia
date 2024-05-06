using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SimpleShootTarget : MonoBehaviour
{
    public float startShowTime;
    public float endShowtime;
    public float timeElapsed = 0f;
    private bool hasBeenHit = false;
    public AudioSource hitSound;
    private Rigidbody rb;
    public Material material;
    private void Start()
    {
        ObjectManager.Instance.RegisterObject(gameObject, 100f, 15f);
        rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true; // Start off kinematic so it doesn't fall until hit
        material = gameObject.GetComponent<MeshRenderer>().material;
        //material.SetColor("_BaseColor", Color.red);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void ToggleShow(bool isShowing)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = isShowing;
        gameObject.GetComponent<CapsuleCollider>().enabled = isShowing;
    }

    private IEnumerator DisableAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        ToggleShow(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HITT target");
        hitSound.Play();
        hasBeenHit = true;
        rb.isKinematic = false;
        rb.AddForce(transform.up * 3f, ForceMode.Impulse); // Add a backward force
        StartCoroutine(DisableAfterTime(2f));
    }

    private void Update()
    {
        material.SetColor("_BaseColor",new Color(material.color.r,material.color.g, material.color.b, timeElapsed/endShowtime));
        if (!hasBeenHit)
        {
            timeElapsed += Time.unscaledDeltaTime;
            if (timeElapsed > startShowTime && !gameObject.GetComponent<MeshRenderer>().enabled)
            {
                ToggleShow(true);
            }
            else if (timeElapsed > endShowtime && gameObject.GetComponent<MeshRenderer>().enabled)
            {
                timeElapsed = 0f;
                //ToggleShow(false);
            }
        }
    }
}