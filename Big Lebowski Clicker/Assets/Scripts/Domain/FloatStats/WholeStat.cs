using UnityEngine;
 
[CreateAssetMenu(menuName = "Stats/Create Whole Stat")]

public class WholeStat : Stat
{ 

    private float statMax = 999999999f;

    protected override bool IsCorrect(float value)
    {
        return true;
    }

    public void CheckOverflow()
    {
        if (Value > statMax)
            SetValue(statMax);
    }

}
