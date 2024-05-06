using System;
using UnityEngine;
using UnityEngine.UI;


//TODO: mousehover event based
public class ObjectDetailsDisplay : MonoBehaviour
{
    public TMPro.TextMeshProUGUI statsText; // Assign this in the inspector

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            ObjectStats stats = ObjectManager.Instance.GetStats(hit.transform.gameObject);
           

            if (stats != null)
            {
                statsText.text = $"Health: {stats.Health}\nDamage: {stats.Damage}"; //\nDistance: {stats.Distance:F2} meters";
                statsText.gameObject.SetActive(true);
            }
            else
            {
                statsText.gameObject.SetActive(false);
            }
        }
        else
        {
            statsText.gameObject.SetActive(false);
        }
    }
}