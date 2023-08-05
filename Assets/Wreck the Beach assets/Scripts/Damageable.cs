using UnityEngine;

public class Damageable : MonoBehaviour
{
    private float damageThreshold = 1.0f;
    private bool wasRecentlyHit = false;
    private TieredAnimation myTieredAnimation;

	void Start ()
    {
        EventManager.DamageThingsEvent += TakeDamage;
        myTieredAnimation = gameObject.GetComponentInChildren<TieredAnimation>();
    }

    void TakeDamage(float damage)
    {
        if(damage > damageThreshold)
        {
            if (!wasRecentlyHit)
            {
                bool destroyed = myTieredAnimation.AdvanceStage();
                EventManager.BroadcastTookDamage(destroyed);
                if (destroyed)
                {
                    TriggerDestruction();
                }
                wasRecentlyHit = true;
                Debug.Log("damage: " + damage + " exceeded threshold, Health was hit");
            }
        }
        else
        {
            wasRecentlyHit = false;
        }
    }

    void TriggerDestruction()
    {
        Debug.Log("Target Destroyed");
    }

    void OnDestroy()
    {
        EventManager.DamageThingsEvent -= TakeDamage;
        Debug.Log("Cleaned up my DamageEvent");
    }
}
