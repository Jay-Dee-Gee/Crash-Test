using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class UpgradeSystem : MonoBehaviour
{
    private List<string> Upgrades = new List<string> { "Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Upgrade 5", "Upgrade 6" };
    public  TMP_Text option1;
    public  TMP_Text option2;
    public  TMP_Text option3;
    public static GameObject Menu;

    
    
    void Start()
    {
        Menu = GameObject.Find("Menu");
        Menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        
        Menu.gameObject.SetActive(true);
        int upgrade1 = Random.Range(0, Upgrades.Count);
        option1.text = Upgrades[upgrade1];
        int upgrade2 = Random.Range(0, Upgrades.Count);
        option2.text = Upgrades[upgrade2];
        int upgrade3 = Random.Range(0, Upgrades.Count);
        option3.text = Upgrades[upgrade3];
        
        
    }
}
