using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health PlayerHealth;
    public Image totalHealthBar;
    public Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = PlayerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = PlayerHealth.currentHealth/10;
    }

}
