using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public static int health = 5;
    public Image[] hearts;

    void OnEnable()
    {
        health = 5;
    }
    
    
    
    
    
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        // Loop through all hearts and deactivate ones beyond current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].gameObject.SetActive(true); // Show full heart
            }
            else
            {
                hearts[i].gameObject.SetActive(false); // Hide heart
            }
        }
    }
}

