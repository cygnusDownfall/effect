using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DmgType:ushort{
    Physic=1,
    Magic=0
}

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "effect/Damage")]
public class damage : Effect
{
    public int dmg;
    public DmgType dmgType;

    public override void endEffect(GameObject[] gameObjects)
    {
        foreach (GameObject target in gameObjects)
        {
            playerInfo playerInfo;
            if (target.TryGetComponent<playerInfo>(out playerInfo))
            {
                playerImpacteds.Add(playerInfo);

                playerInfo.takeDamage(dmg, dmgType);

            }
        }

    }
}
