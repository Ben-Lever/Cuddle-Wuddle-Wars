using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDeckManager : MonoBehaviour
{
    public List<GameObject> Deck = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (GameObject obj in Deck)
        {
            obj.GetComponent<BattleCardObjectScript>().cardInfo = CardManager.Instance.currentDeck[i];
            obj.GetComponent<BattleCardObjectScript>().UpdateCardInfo();
            i++;
        }
    }


}
