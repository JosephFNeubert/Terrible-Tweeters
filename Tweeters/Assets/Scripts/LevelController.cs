using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    MonsterBehavior[] _monsters;
    [SerializeField] string _nextLevelName;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<MonsterBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AllMonstersDead())
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(_nextLevelName);
    }

    bool AllMonstersDead()
    {
        foreach (var monster in _monsters)
        {
            if(monster.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
