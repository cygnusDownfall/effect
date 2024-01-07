using TMPro;
using Unity.Netcode;
using UnityEngine;

public class damage : Effect
{
    public int dmg = 0;
    public DmgType dmgType;

    public void Dmg(GameObject targets)
    {
        if (targets == null) return;
        if (targets.TryGetComponent(out enemyInfo info))
        {
            info.takeDamage(dmg, dmgType);
        }
    }

    public override void NetworkSerialize<T>(BufferSerializer<T> serializer)
    {
        base.NetworkSerialize(serializer);
        serializer.SerializeValue(ref dmg);
        serializer.SerializeValue(ref dmgType);
    }
}

