using UnityEngine;
 
[CreateAssetMenu(menuName = "Stats/Create Normalized Stat")]

public class NormalizedStat : Stat
{ 
    protected override bool IsCorrect(float value)
    {
        return (value <= 1f && value >= 0f);
    }

}
