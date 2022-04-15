using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float edgeDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject endGoal;
    private Vector3 targetPos;

    
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);   
    }

    public void Move(Vector3 moveDir)
    {
        if (Mathf.Abs(targetPos.x + moveDir.x) > edgeDistance)
        {
            return;
        }
        targetPos += moveDir;

        if(transform.position.y > endGoal.transform.position.y)
        {
            UI.instance.SetEndScreen(true);
            gameObject.SetActive(false);
        }
    }

    public void AddScore(int score)
    {
        playerScore += score;
        UI.instance.UpdateScoreText(playerScore);
    }

    public void GameOver()
    {
        UI.instance.SetEndScreen(false);
        gameObject.SetActive(false);
    }

    public void Win()
    {
        UI.instance.SetEndScreen(true);
        gameObject.SetActive(false);
    }
}
