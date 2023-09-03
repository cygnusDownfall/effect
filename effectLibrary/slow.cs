using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "effect/Slow")]
class slowEffect : Effect
{
    public int slowScale = 30;
    List<float> slowValue = new List<float>();
    public override void triggerEffect(GameObject[] targets)
    {
        foreach (GameObject target in targets)
        {
            playerInfo playerInfo;
            if (target.TryGetComponent<playerInfo>(out playerInfo))
            {
                playerImpacteds.Add(playerInfo);
                float slow=playerInfo.speed * slowScale/100f;
                slowValue.Add(slow);
                playerInfo.speed -= slow;
            }
        }
    }
    public override void endEffect(GameObject[] gameObjects)
    {
        for(int i=0;i< playerImpacteds.Count;i++)
        {
            playerImpacteds[i].speed += slowValue[i];
        }
        
    }
}