using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Text fields
    public Text hitpointText;

    //Player HP Bar Declares
    public Image hitpointBar;
    public Image healthBarFade;
    public Color hpBarFadeColor;
    private float healthBarFadeTimer;
    private const float healthBarFadeTimerMAX = 1f;

    //References
    public Player player;

    //Singleton for HUD. Can access this anywhere.
    public static HUD instance;

    private void Awake()
    {
      if (HUD.instance != null)
        {
          return;
        }

      instance = this;

      healthBarFade = GameObject.Find("HealthFade").GetComponent<Image>();
      hpBarFadeColor = healthBarFade.color;
      hpBarFadeColor.a = 0f;
      healthBarFade.color = hpBarFadeColor;
        
    }

    void Update()
    {
      //  hitpointText.text = "HP: " + GameManager.instance.player.hitpoint.ToString() + " / "  + GameManager.instance.player.maxHitpoint.ToString();
      FadePlayerHP();
    }

    void FadePlayerHP()
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

    public void OnHitPointChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        
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
