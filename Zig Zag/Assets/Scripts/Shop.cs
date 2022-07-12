using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public SSkinInfo skinInfo;
    [SerializeField] Image skinImage;
    [SerializeField] bool isSkinUnlocked;
    [SerializeField] TextMeshProUGUI buttonTxt;
    [SerializeField] TextMeshProUGUI Gems;
    [SerializeField] TextMeshProUGUI priceTxt;

    scoreKeeper scoreKeeper;

    private void Awake() {
        skinImage.material = skinInfo.getskinMat();
        priceTxt.text = skinInfo.getPrice().ToString();
        scoreKeeper = FindObjectOfType<scoreKeeper>();
        IsSkinUnloacked();
    }
    private void Start() {
        Gems.text = scoreKeeper.getnoOfGems().ToString();
    }
    void IsSkinUnloacked()
    {
        if(PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonTxt.text = "Equip";
        }
    }

    public void OnButtonPress()
    {
        if(isSkinUnlocked)
        {
            //Equip
            FindObjectOfType<SkinManager>().EquipSkin(skinInfo);
        }
        else
        {
            //Buy
            if(scoreKeeper.TryRemoveGems(skinInfo.getPrice()))
            {
                PlayerPrefs.SetInt(skinInfo.skinID.ToString(),1);
                Gems.text = scoreKeeper.getnoOfGems().ToString();
                IsSkinUnloacked();
            }
        }
    }
    
    
}
