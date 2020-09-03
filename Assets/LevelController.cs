using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIdx;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)
        {
            if(enemy != null)
            {
                return;
            }

            Debug.Log("You killed all enemies!");
            _nextLevelIdx++;
            string nextLevelName = "Level" + _nextLevelIdx;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
