using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string scenceToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public GameObject healthBar;
    public float fadeWait;

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            //SceneManager.LoadScene(scenceToLoad);
            StartCoroutine(FadeCo());
            healthBar.SetActive(true);
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            //turn off health
            healthBar.SetActive(false);
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scenceToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }

}
