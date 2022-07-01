using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    TileManager tilemanager;
    float fallDelay = 0.3f;
    
    void Start()
    {
        tilemanager = FindObjectOfType<TileManager>();
    }

    
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            tilemanager.SpawnTile();
            StartCoroutine(FallDown());
        }   
    }
    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3f);
        switch (gameObject.name)
        {
            case "LeftTile":
                tilemanager.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
            case "TopTile":
                tilemanager.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;    
            
        }
    }
}
