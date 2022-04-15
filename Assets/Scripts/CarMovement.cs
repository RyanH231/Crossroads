using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);

        if(transform.position.x >= endPos.x && facingRight == true)
        {
            transform.position = startPos;
        }
        else if (transform.position.x <= endPos.x && facingRight == false)
        {
            transform.position = startPos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().GameOver();
        }
    }
}
