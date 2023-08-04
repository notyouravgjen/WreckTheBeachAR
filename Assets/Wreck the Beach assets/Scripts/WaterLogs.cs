using UnityEngine;

public class WaterLogs : MonoBehaviour
{
    public int size = 50;
    public float momentumLossPerUpdate;
    public Transform waveObject;
    public float waveSpacing;
    public int numOfFixedUpdatesPerWaveUpdate;
    private int currFixedUpdateCount;
    private Waveable waveNumbers;
    private Transform[] waves;
    public float[] singleWave;  // form of a single wave, as positive or negative offsets from the transform.position.y

    void Start ()
    {
        currFixedUpdateCount = 0;
        waveNumbers = new Waveable(size, momentumLossPerUpdate);
        waves = new Transform[size];
        for(int i=0; i < size; i++)
        {
            float xOffset = i * waveSpacing;
            waves[i] = Instantiate(waveObject, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z), Quaternion.Euler(90, -90, 0), transform);
        }
	}
	
	void FixedUpdate ()
    {
        currFixedUpdateCount++;
        if (currFixedUpdateCount >= numOfFixedUpdatesPerWaveUpdate)
        {
            EventManager.BroadcastDamageThings(waveNumbers.GetOffset(size-1));
            waveNumbers.Update();
            for (int i = 0; i < size; i++)
            {
                Vector3 wavePos = waves[i].transform.position;
                wavePos.y = transform.position.y + waveNumbers.GetOffset(i);
                waves[i].transform.position = wavePos;
            }
            currFixedUpdateCount = 0;
        }
	}

    public void ApplyInput()
    {
        if (!GameManager.instance.interactionDisabled)
        {
            waveNumbers.AddWave(singleWave);
        }
    }

	public void Reset()
	{
		waveNumbers = new Waveable(size, momentumLossPerUpdate);
	}
}
