using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * movementSpeed;

        if (Input.GetMouseButtonDown(0)/*GetKeyDown("space")*/)
        {
            Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
        }
    }
}