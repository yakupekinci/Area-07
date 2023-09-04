using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private GameUI _gameUI;
    public List<GameObject> levelParts;
    public GameObject[] levelPrefabs;
    public GameObject levels;
    public int maxLevelParts = 3;
    public int levelCounter = 0;
    private int SpawnPointCounter = 0;
    private bool triggered;

    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
        levelParts = new List<GameObject>();
        for (int i = 0; i < maxLevelParts; i++)
        {
            GameObject levelPart = levels.transform.GetChild(i).gameObject;
            levelParts.Add(levelPart);
        }
    }

    public void nextLevel()
    {
        levelCounter++;
        SpawnPointCounter++;
        _gameUI.UpdateScore(50);
        Vector3 pos = levelParts[levelParts.Count - 1].transform.position + new Vector3(0f, 0f, 93f);
        int randomLevelPrefabNum = Random.Range(0, levelPrefabs.Length);
        GameObject newLevelPart = Instantiate(levelPrefabs[randomLevelPrefabNum], pos, Quaternion.identity);
        newLevelPart.transform.SetParent(levels.transform);
        levelParts.Add(newLevelPart);


        if (levelCounter >= 3)
        {
            GameObject oldestLevelPart = levelParts[0];
            levelParts.Remove(oldestLevelPart);
            Destroy(oldestLevelPart);
            levelCounter = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerBox"))
        {
            other.gameObject.SetActive(false);
            nextLevel();
            _playerManager.spawnPoint = other.transform.parent.parent.GetChild(0).gameObject;
        }

    }
}
