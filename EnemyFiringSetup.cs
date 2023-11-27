using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringSetup : MonoBehaviour
{
    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;
    private bool isShooting;

    void Update()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator shootRoutine()
    {
        if (isShooting) yield break;

        isShooting = true;

        Instantiate(projectilePrefab, launchOffset.position, transform.rotation);

        yield return new WaitForSeconds(2f);

        isShooting = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(shootRoutine());
    }
}
