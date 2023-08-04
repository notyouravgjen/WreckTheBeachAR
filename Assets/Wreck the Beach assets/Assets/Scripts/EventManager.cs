public class EventManager {
    public delegate void DamageThings(float damage);
    public static event DamageThings DamageThingsEvent;
    public delegate void TookDamage(bool wasDestroyed);
    public static event TookDamage TookDamageEvent;

    public static void BroadcastDamageThings(float damage)
    {
        DamageThingsEvent?.Invoke(damage);
    }

    public static void BroadcastTookDamage(bool wasDestroyed)
    {
        TookDamageEvent?.Invoke(wasDestroyed);
    }
}
