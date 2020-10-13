using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Rocket _rocket;

    public TMP_Text Text { get; private set; }

    private void Start()
    {
        Text = GetComponent<TMP_Text>();
        Text.text = _rocket.Health.ToString();
    }

    private void SubstractHealth(int value)
    {
        Text.text = value.ToString();
    }

    private void OnEnable()
    {
        _rocket.SubstractHealth += SubstractHealth;
    }

    private void OnDisable()
    {
        _rocket.SubstractHealth -= SubstractHealth;
    }
}
