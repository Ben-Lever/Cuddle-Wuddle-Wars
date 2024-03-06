using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FluffCollector : MonoBehaviour
{
    public TextMeshProUGUI fluffText;
    public int fluffCount = 0;

    public int GetFluffCount()
    {
        return fluffCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("Fluff"))
            {
                CollectFluff(hit.collider.gameObject);
            }
        }
    }



    public void CollectFluff(GameObject fluff)
    {
        fluffCount++;
        UpdateFluffText();
        Destroy(fluff); 
    }

    public void UpdateFluffText()
    {
      fluffText.text = fluffCount.ToString();
    }
}

