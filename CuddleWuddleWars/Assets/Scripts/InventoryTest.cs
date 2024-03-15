using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject CardManagerObject;
    public CardManager CardManager;
    // Start is called before the first frame update
    void Awake()
    {
        CardManager = CardManagerObject.GetComponent<CardManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
