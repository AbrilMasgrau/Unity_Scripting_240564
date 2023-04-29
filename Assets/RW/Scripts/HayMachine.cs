using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;


    
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void UpdateMovement()
    {
        float horizontallnput = Input.GetAxisRaw("Horizontal");

        if(horizontallnput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);

        }else if(horizontallnput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right* movementSpeed* Time.deltaTime);

        }
        Debug.Log(transform.position.x);

    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);

    }
    
    private void UpdateShooting() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) {
        shootTimer = shootInterval;
        ShootHay();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
}
