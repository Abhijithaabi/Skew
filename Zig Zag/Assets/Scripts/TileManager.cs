using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    Player player;
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] GameObject currentTile;
    Stack<GameObject> leftTiles = new Stack<GameObject>();
    Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftTiles { get => leftTiles; set => leftTiles = value; }
    public Stack<GameObject> TopTiles { get => topTiles; set => topTiles = value; }
    private void Awake() {
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        CreateTiles(10);
        for (int i = 0; i < 50; i++)
        {
            SpawnTile(i+1);
        }
    }
   

    
    void Update()
    {
        
    }
     public void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            LeftTiles.Push(Instantiate(tilePrefabs[0]));
            TopTiles.Push(Instantiate(tilePrefabs[1]));
            TopTiles.Peek().name = "TopTile";
            LeftTiles.Peek().name = "LeftTile";
            TopTiles.Peek().SetActive(false);
            LeftTiles.Peek().SetActive(false);  
        }
    }
    public void SpawnTile(int id)
    {
        if(LeftTiles.Count == 0 || TopTiles.Count == 0)
        {
            CreateTiles(10);
        }
        int randomIndex = Random.Range(0,2);
        if(randomIndex == 0)
        {
            GameObject tmp = LeftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            tmp.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            currentTile = tmp;
            currentTile.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            if(id > 0)
            {
                currentTile.GetComponent<Tile>().setId(id);
            }
            
        }
        else if(randomIndex == 1)
        {
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            tmp.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            currentTile = tmp;
            currentTile.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            if(id > 0)
             {
                currentTile.GetComponent<Tile>().setId(id);
             }   
            
        }
        int SpawnItemProb = Random.Range(0,10);
        if(SpawnItemProb == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void spawnLastTile()
    {
        string Tiletype = player.getLastTileType();
        Vector3 lasttilepos = player.getLastTilePos();
        if(Tiletype != null && Tiletype == "TopTile")
        {
            GameObject tmp = TopTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = lasttilepos;
            tmp.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        else if(Tiletype != null && Tiletype == "LeftTile")
        {
            GameObject tmp = LeftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = lasttilepos;
            tmp.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ; 
        }
    }
}
