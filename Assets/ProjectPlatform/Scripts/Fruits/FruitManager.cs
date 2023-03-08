using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FruitManager : MonoBehaviour
{
    public TextMeshProUGUI levelCleared;
    public TextMeshProUGUI totalFruits;
    public TextMeshProUGUI fruitsCollected;

    private int totalFruitsInLevel;

    public GameObject sceneTransition;

    private void Start()
    { 
        totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
    }

    public void AllFruitsCollected()    
    {
        if (transform.childCount == 0)
        {
            Debug.Log("AllFruitsCollected");
            levelCleared.gameObject.SetActive(true);
            sceneTransition.SetActive(true);
            Invoke(nameof(ChangeScene), 1); 
        }
    }
        
    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
