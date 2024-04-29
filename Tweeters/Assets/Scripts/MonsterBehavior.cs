using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class MonsterBehavior : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    public SpriteRenderer _sr;
    bool _hasDied;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (CollisionDeath(collisionInfo))
        {
            StartCoroutine(die());
        }
    }

    private bool CollisionDeath(Collision2D collisionInfo)
    {
        if(_hasDied)
        {
            return false;
        }

        if (collisionInfo.gameObject.GetComponent<BirdBehavior>())
        {
            return true;
        }
        if(collisionInfo.contacts[0].normal.y < -0.5)
        {
            return true;
        }
        return false;
    }

    private IEnumerator die()
    {
        _hasDied = true;
        _sr.sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}