using UnityEngine;
using UnityEngine.UI;

public class EnemyStatsDisplay : MonoBehaviour
{
    public Text statsText; // Assign this in the inspector
    public GameObject enemy; // Assign the enemy object

    private void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject == enemy)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                statsText.text = $"Health: 23\nDamage: 2";
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
