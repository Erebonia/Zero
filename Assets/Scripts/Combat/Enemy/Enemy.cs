using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public Animator anim;

    private int maxHitpoints = 10;
    private int hitpoints = 10;

    //Enemy HP Bar Fading
    private Image hitpointBar;
    private Image healthBarFade;
    public Color hpBarFadeColor;
    private float healthBarFadeTimer;
    private const float healthBarFadeTimerMAX = 0.5f;

    //UI
    public Text enemyHP;
    private GameObject enemyHPBar;
    private float despawnEnemyBar = 15f;
    private float despawnDuration;
    public Animator enemyHPBarAnim;

    private void Awake()
    {
        enemyHP = GameObject.Find("EnemyHPText").GetComponent<Text>();
        hitpointBar = GameObject.Find("EnemyHealth").GetComponent<Image>();
        healthBarFade = GameObject.Find("EnemyHealthFade").GetComponent<Image>();
        enemyHPBarAnim = GameObject.Find("EnemyHealthBar").GetComponent<Animator>();
        hpBarFadeColor = healthBarFade.color;
        hpBarFadeColor.a = 0f;
        healthBarFade.color = hpBarFadeColor;
    }

    private void Update()
    {
        FadeEnemyHP();
        HideEnemyHPBar();
    }

    void Start()
    {
        hitpoints = maxHitpoints;
    }

    public void TakeDamage(int damage)
    {
        //Show enemy HP Bar
        enemyHPBarAnim.SetBool("ShowEnemyHP", true);

        //Decrease their HP when hit.
        hitpoints -= damage;

        //Update HP Bar
        EnemyHitPointChange();

        Debug.Log("Enemy HP: " + hitpoints);

        //Play hurt animation
        // anim.SetTrigger("Hurt");

        if (hitpoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        HideEnemyHPBar();
        gameObject.SetActive(false);
        
        // anim.SetBool("Dead", true);
    }

    private void FadeEnemyHP()
    {
        if (hpBarFadeColor.a > 0)
        {
            healthBarFadeTimer -= Time.deltaTime;
            if (healthBarFadeTimer < 0)
            {
                float FadeAmount = 5f;
                hpBarFadeColor.a -= FadeAmount * Time.deltaTime;
                healthBarFade.color = hpBarFadeColor;
            }
        }
    }
    
    private void HideEnemyHPBar()
    {
        //Hide enemy HP Bar
        if (Time.time - despawnDuration > despawnEnemyBar || hitpoints <= 0)
        {
            despawnDuration = Time.time;
            enemyHPBarAnim.SetBool("ShowEnemyHP", false);
        }
    }

    public void EnemyHitPointChange()
    {
        float ratio = (float)hitpoints / (float)maxHitpoints;

        if (hpBarFadeColor.a <= 0)
        {
            healthBarFade.fillAmount = hitpointBar.fillAmount;
        }
        hpBarFadeColor.a = 1;
        healthBarFade.color = hpBarFadeColor;
        healthBarFadeTimer = healthBarFadeTimerMAX;

        hitpointBar.fillAmount = ratio;
    }
}
