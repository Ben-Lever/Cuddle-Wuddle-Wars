using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FluffCollector : MonoBehaviour
{
    public TextMeshProUGUI fluffText;
    private int fluffCount = 0;


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

    private void CollectFluff(GameObject fluff)
    {
        fluffCount++;
        UpdateFluffText();
        Destroy(fluff); 
    }

    private void UpdateFluffText()
    {
      fluffText.text = fluffCount.ToString();
    }
}

