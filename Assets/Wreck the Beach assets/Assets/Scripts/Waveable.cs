using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveable {

    public int size;
    public float momentumLossPerUpdate;
    private Queue<float> currWave;
    private RandomAccessCircularArray<float> heightOffsetsTravelingRight; // Delta height from defaultHeight that should moving right
    private RandomAccessCircularArray<float> heightOffsetsTravelingLeft;  // Delta height from defaultHeight that is moving left

	//Constructor
	public Waveable (int size, float momentumLossPerUpdate) {
        this.size = size;
        this.momentumLossPerUpdate = momentumLossPerUpdate;
        heightOffsetsTravelingRight = new RandomAccessCircularArray<float>(size, 0);
        heightOffsetsTravelingLeft = new RandomAccessCircularArray<float>(size, 0);
        currWave = new Queue<float>();
    }

    private bool IsSameSign(float f1, float f2)
    {
        return (f1 > 0 && f2 > 0) || (f1 < 0 && f2 < 0);
    }
    // Brings f1 towards 0 by f2's value
    private float BringTowardsZero(float f1, float f2)
    {
        float res = System.Math.Abs(f1 - f2);
        // If f1 and res are the same sign, their product > 0
        if(IsSameSign(res, f1))
        {
            return res;
        }
        else
        {
            return 0;
        }
    }

    // Update should be called manually
    // Does not work for edge cases (sizes of 0, 1, maybe a few more where the two waving sides overlap)
    public void Update() {
        for (int i=0; i< size; i++)
        {
            float oldLeft = heightOffsetsTravelingLeft.Get(i);
            heightOffsetsTravelingLeft.Set(i, BringTowardsZero(oldLeft, momentumLossPerUpdate));
            float oldRight = heightOffsetsTravelingRight.Get(i);
            heightOffsetsTravelingRight.Set(i, BringTowardsZero(oldRight, momentumLossPerUpdate));
        }
        float bouncedRightWaveHeight = heightOffsetsTravelingRight.RotateRight();
        float bouncedLeftWaveHeight = heightOffsetsTravelingLeft.RotateLeft();
        heightOffsetsTravelingLeft.Set(size - 1, bouncedRightWaveHeight);
        float f = 0;
        if (currWave.Count > 0) {
          f = currWave.Dequeue();
        }
        heightOffsetsTravelingRight.Set(0, f + bouncedLeftWaveHeight);

    }

    public float GetOffset(int index)
    {
        return heightOffsetsTravelingLeft.Get(index) + heightOffsetsTravelingRight.Get(index);
    }

    public void AddWave(float[] wave)
    {
        if (currWave.Count > 0)
        {
            currWave.Clear();
        }
        // wave is queued from the right to left since waving goes to the right
        for (int i=wave.Length-1; i>=0; i--)
        {
            currWave.Enqueue(wave[i]);
        }
    }
}
