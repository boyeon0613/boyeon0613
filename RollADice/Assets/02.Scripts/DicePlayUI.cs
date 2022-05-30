using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePlayUI : MonoBehaviour
{
    static public DicePlayUI instance;
    
    private void Awake()
    {
        if(instance == null)instance = this;
    }

    public GameObject normaldicePanel;
    public GameObject inversedicePanel;

    public void SwitchDicePanel()
    {
        Debug.Log("Di-e panel switched");
        if (normaldicePanel.activeSelf)
        {
            normaldicePanel.SetActive(false);
            inversedicePanel.SetActive(true);
        }
        else
        {
            normaldicePanel.SetActive(true);
            inversedicePanel.SetActive(false);
        }
    }
    public void RollBackDicePanel()
    {
        if (inversedicePanel.activeSelf)
        {
            normaldicePanel.SetActive(true);
            inversedicePanel.SetActive(false);
        }
    }
}
