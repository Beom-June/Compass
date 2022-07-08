using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    public Transform LoadingSpinner;
    public Transform TextIndicator;
    public Transform TextLoading;
    public float currentAmount;
    [SerializeField] private float speed;

    void Update()
    {
        FillUI();
    }

    void FillUI()
    {
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;

            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            TextLoading.gameObject.SetActive(true);
        }
        else
        {
            TextLoading.gameObject.SetActive(false);
            TextIndicator.GetComponent<Text>().text = "\nDONE!";
        }
        LoadingSpinner.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
