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
    [SerializeField] GameObject DeathEffect;
    Vector3 lastTilePos;
    string TileType;
    
    
    
    scoreKeeper score;
    
    Vector3 dir;
    bool isDead;
    bool isMoving;
    int Gems;
    MeshRenderer PlayerMesh;
    
    static Player Instance;
    private void Awake() {
        
        score = FindObjectOfType<scoreKeeper>();
        PlayerMesh = GetComponent<MeshRenderer>();
        if(SkinManager.EquippedSkin != null)
        {
            PlayerMesh.material = SkinManager.EquippedSkin;
            PlayerMesh.material.shader = Shader.Find("Standard");
        }
        

        
    }

    
    
    void Start()
    {
        Gems = score.getnoOfGems();
        score.updateGemTxt(Gems);
        
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
            Gems++;
            score.setnoOfGems(Gems);
            score.updateGemTxt(Gems);
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
                Death();

            }
        }   
    }

    private void Death()
    {
        isDead = true;
        print("Dead");
        print("lasttilepos:" + lastTilePos);
        print("TileType:" + TileType);
        VC.Follow = null;
        score.stopScoreCount();
        dir = Vector3.zero;
        gameObject.SetActive(false);
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
    }

    public bool GetIsDead()
    {
        return isDead;
    }
    public bool GetIsMoving()
    {
        return isMoving;
    }
    public void setLastTileDtails(Vector3 pos,string name)
    {
        lastTilePos = pos;
        TileType = name;
    }
    public Vector3 getLastTilePos()
    {
        return lastTilePos;
    }
    public string getLastTileType()
    {
        return TileType;
    }
    public void RespawnPlayer()
    {
        isDead = false;
        transform.position = lastTilePos + new Vector3(-1.5f,3,1.5f);
        gameObject.SetActive(true);
        VC.Follow = transform;
        
        
    }
}
