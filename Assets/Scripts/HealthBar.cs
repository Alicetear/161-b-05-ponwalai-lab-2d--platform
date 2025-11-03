using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Awake()
    {
        if (slider == null) 
        {
           slider = GetComponentInChildren<Slider>(true);
        } 

        if (slider != null)
        {
            slider.minValue = 0;
            slider.wholeNumbers = true; 
        }
    }

    public void SetMaxHealth(int max)
    {
        if (slider == null) return;
        slider.minValue = 0;
        slider.maxValue = max;
        slider.value = max;  
    }

    public void SetHealth(int health)
    {
        if (slider == null) return;
        slider.value = Mathf.Clamp(health, 0, (int)slider.maxValue);
    }
}
