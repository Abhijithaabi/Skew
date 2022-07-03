using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject ps;
    [SerializeField] CinemachineVirtualCamera VC;
    
    
    scoreKeeper score;
    
    Vector3 dir;
    bool isDead;
    bool isMoving;
    static Player Instance;
    private void Awake() {
        score = FindObjectOfType<scoreKeeper>();
    }

    
    
    void Start()
    {
        
        isDead = false;
        dir = Vector3.zero;
        
        isMoving = false;
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDead)
        {
            isMoving = true;
            score.startScoreCount();
           
            if(dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }
        }
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(dir * amountToMove);
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            SpawnParticles();
        }   
    }
    void SpawnParticles()
    {
        Instantiate(ps,transform.position,Quaternion.identity);
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tile")
        {
            RaycastHit Hit;
            Ray downray = new Ray(transform.position,Vector3.down);
            if(!Physics.Raycast(downray, out Hit))
            {
                //kill Player
                isDead = true;
                print("Dead");
                VC.Follow = null;
                score.stopScoreCount();
            }
        }   
    }
    public bool GetIsDead()
    {
        return isDead;
    }
    public bool GetIsMoving()
    {
        return isMoving;
    }
}
