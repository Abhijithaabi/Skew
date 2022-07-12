using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
   public static Material EquippedSkin;
   public void EquipSkin(SSkinInfo skinInfo)
   {
    EquippedSkin = skinInfo.getskinMat();
    
   }
}
