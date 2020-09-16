using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float triggerDistance;
    public float stoppingDistance;
    [SerializeField]private bool chasing;
    public bool hurt = false;
    
    private Transform target;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing && !hurt)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
            chasing = false;
        }

        if(Vector2.Distance(transform.position, target.position) < triggerDistance && Vector2.Distance(transform.position, target.position) > stoppingDistance && !hurt)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            chasing = true;
        }else{
            chasing = false;
        }


    }
}
