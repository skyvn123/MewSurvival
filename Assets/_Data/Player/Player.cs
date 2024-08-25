using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public interface IHealth
{
    void TakeDamage(float damage);
}

public interface IGetPoint
{
    void GetPoint(int point);
}

public class Player : MonoBehaviour, IHealth,IGetPoint
{
    [SerializeField] protected float maxhp = 200f;
    private Animator _animator;
    private float hp;
    private int score;
    public Image hpBar;
    private void Start()
    {
        hp = maxhp;
        score= 0;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
      hp -= damage;
      hpBar.fillAmount = hp/maxhp;
      if(hp <= 0f) GameManager.Instance.GameOver();
    }
    public void GetPoint(int point)
    {
        score += point;
        GameManager.Instance.UpdateScore(score);
    }
}
