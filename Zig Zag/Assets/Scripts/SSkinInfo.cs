using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable,CreateAssetMenu(fileName ="New Skin",menuName ="Create New Skin")]
public class SSkinInfo : ScriptableObject
{
    public enum SkinIDs {blue,yellow,green}
    public SkinIDs skinID;
    [SerializeField] Material skinMat;
    [SerializeField] int price;

    public Material getskinMat()
    {
        return skinMat;
    }
    public int getPrice()
    {
        return price;
    }
}
