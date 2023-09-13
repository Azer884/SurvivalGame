using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Enemy PlayerHealth;
    public MeleeSystem Damage;
    private float HealthRatio;
    public Image FillBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {   
        float Ratio = 0.015f ;
        HealthRatio = PlayerHealth.currentHealth / PlayerHealth.maxHealth;
        float smoothHealth = Mathf.Lerp(FillBar.fillAmount, HealthRatio, Ratio);
        FillBar.fillAmount = smoothHealth;
    }

}
