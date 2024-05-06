using System.Collections;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private bool isWeaponLoaded;
    [SerializeField] private float stoppingDistance = 0.1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform targetObject;
    [SerializeField] private float reloadTimer = 0f;
    private float reloadDelay = 5f;
    private float weaponLoadTime = 3f;

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(LoadWeapon());
    }

    private IEnumerator LoadWeapon()
    {
        yield return new WaitForSeconds(weaponLoadTime);
        isWeaponLoaded = true;
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        float distance = Vector3.Distance(transform.position, targetObject.position);

        if (isWeaponLoaded)
        {
            MoveTowardsTarget(distance);
        }
        else
        {
            ReturnToStart(distance);
        }
    }

    private void MoveTowardsTarget(float distance)
    {
        if (distance > stoppingDistance)
        {
            transform.position = Vector3.Lerp(transform.position, targetObject.position, speed * Time.deltaTime);
        }
        else
        {
            isWeaponLoaded = false;
            reloadTimer = 0;
        }
    }

    private void ReturnToStart(float distance)
    {
        if (reloadTimer < reloadDelay)
        {
            reloadTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, initialPosition, speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(LoadWeapon());
            reloadTimer = 0;
        }
    }
}