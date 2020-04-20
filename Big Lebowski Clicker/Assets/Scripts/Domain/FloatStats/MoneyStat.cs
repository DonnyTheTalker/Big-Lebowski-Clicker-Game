using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Stats/Create Money Stat")]

public class MoneyStat : WholeStat
{

    public void ChangeButtonValue(Button button)
    {

        button.GetComponentInChildren<Text>().text = string.Format("{0:f3}", Value);

    }

}
