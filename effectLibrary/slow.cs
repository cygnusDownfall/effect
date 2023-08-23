using UnityEngine;

class slowEffect : Effect
{
    public float slowScale = 0.3f;
    public override void triggerEffect(GameObject target)
    {
        playerInfo playerInfo;
        if (target.TryGetComponent<playerInfo>(out playerInfo))
        {
            playerInfo.speed -= playerInfo.speed * slowScale;
        }

    }
}