using System.Collections;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    
    [SerializeField] AudioClip touchObstacleSFX;
    [SerializeField] AudioClip fallInOceanSFX;
    [SerializeField] AudioClip tookCheckpointSFX;
    [SerializeField] AudioClip gameWonSFX;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip gameOverMusic;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("GameBGMusic", 0.2f);
    }

    void GameBGMusic()
    {
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            HealthSystem.health--;
            audioSource.PlayOneShot(touchObstacleSFX);
            if (HealthSystem.health == 0)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(gameOverSFX);
                StartCoroutine(DisableMovement());
                gameOverUI.SetActive(true);
                Invoke("PlayGameOverMusic", 3f);
                
            }
        }
        if (other.gameObject.tag == "Ocean")
        {
            HealthSystem.health--;
            audioSource.PlayOneShot(fallInOceanSFX);
            if (HealthSystem.health == 0)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(gameOverSFX);
                StartCoroutine(DisableMovement());
            }
        }
        
        if (other.gameObject.tag == "Checkpoint1")
        {
            audioSource.PlayOneShot(tookCheckpointSFX);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            audioSource.PlayOneShot(tookCheckpointSFX);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.tag == "Finish")
        {
            gameWonUI.SetActive(true);
            audioSource.Stop();
            audioSource.PlayOneShot(gameWonSFX);
            StartCoroutine(DisableMovement());

        }
    }
    
    IEnumerator DisableMovement()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponentInChildren<Animator>().enabled = false;
        GetComponent<PlayerMove1>().enabled = false;
    }

    void PlayGameOverMusic()
    {
        audioSource.PlayOneShot(gameOverMusic);
    }
}
