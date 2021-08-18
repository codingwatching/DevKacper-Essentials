using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DevKacper.Mechanic
{
    public class StatisticSystem
    {
        [System.NonSerialized] public EventHandler OnValueChanged;

        private float value;
        private float maxValue;

        public StatisticSystem(float value)
        {
            OnValueChanged = null;
            maxValue = value;
            this.value = maxValue;
        }

        public void DecreaseValue(float amount)
        {
            if (amount > 0)
            {
                value -= amount;

                if (value <= 0)
                {
                    value = 0;
                }
                OnValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void IncreaseValue(float amount)
        {
            if (amount > 0)
            {
                value += amount;
                if (value > maxValue)
                {
                    value = maxValue;
                }

                OnValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ChangeMaxValue(float newMaxValue)
        {
            maxValue = newMaxValue;
            if (value > maxValue)
            {
                value = maxValue;
            }
            OnValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SetValue(float newValue)
        {
            if (newValue <= maxValue)
            {
                value = newValue;
                OnValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public float GetRatio()
        {
            return (value / maxValue);
        }

        public float GetValue()
        {
            return value;
        }

        public float GetMaxValue()
        {
            return maxValue;
        }

        public bool IsEmpty()
        {
            return value <= 0;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", value.ToString(), maxValue.ToString());
        }
    }
}

