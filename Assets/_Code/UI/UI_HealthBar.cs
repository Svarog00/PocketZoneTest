using Assets._Code.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Scripts.UI
{
    public class UI_HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarSlider;
        [SerializeField] private GameObject _healthSource;

        // Start is called before the first frame update
        void Start()
        {
            _healthSource.GetComponent<IDamagable>().OnHealthChanged += HealthSource_OnHealthChangedEventHandler;
        }

        private void HealthSource_OnHealthChangedEventHandler(object sender, OnHealthChangedEventArgs e)
        {
            _healthBarSlider.fillAmount = e.CurrentHealth;
        }
    }
}