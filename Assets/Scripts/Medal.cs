using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite metalMedal, BronzeMedal, SilverMedal, GoldMedal;
    Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
        int gameScore = GameManager.GameScore;
        if(gameScore>0 && gameScore <= 4)
        {
            img.sprite = metalMedal;
        }
      else  if (gameScore > 4 && gameScore <= 8)
        {
            img.sprite = BronzeMedal;
        }
      else  if (gameScore > 8 && gameScore <= 15)
        {
            img.sprite = SilverMedal;
        }
      else  if (gameScore > 15)
        {
            img.sprite = GoldMedal;
        }
    }
}
