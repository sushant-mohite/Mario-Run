using UnityEngine;

public class EnablePart : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] scriptsToEnable; // Scripts to enable when this trigger is activated

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player entered the trigger
        {
            foreach (MonoBehaviour script in scriptsToEnable)
            {
                script.enabled = true; // Enable each script
            }

            // Optionally deactivate this trigger after use
            gameObject.SetActive(false);
        }
    }
}

