using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardSaveLoad : MonoBehaviour
{
    string path;
    public static void SaveCardData(Card card, string path)
    {
        path = Path.Combine(Application.persistentDataPath, "card.json");
        string data = JsonUtility.ToJson(card, true);
        File.WriteAllText(path, data);
    }

    public static Card LoadCardData(string path)
    {
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            Card card = ScriptableObject.CreateInstance<Card>();
            JsonUtility.FromJsonOverwrite(data, card);
            return card;
        }
        return null;
    }
}
