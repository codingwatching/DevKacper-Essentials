using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DevKacper.Utility
{
    public static class UtilityClass
    {
        public static float GetAngleFromVectorFloat(Vector3 direction)
        {
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if(angle < 0)
            {
                angle += 360f;
            }

            return angle;
        }

        public static Vector2 GetRandomDirection()
        {
            return UnityEngine.Random.insideUnitCircle.normalized;
        }

        public static Vector2 GetMousePosition()
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector2(worldPoint.x, worldPoint.y);
        }

        public static Vector2 GetMousePositionInRadius(Vector2 transformPosition, float radius)
        {
            var mousePosition = GetMousePosition();

            var direction = mousePosition - transformPosition;
            direction = Vector2.ClampMagnitude(direction, radius);

            return direction;
        }

        public static Vector2 GetAbsoluteVector2(Vector2 vector)
        {
            return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
        }
        
        public static Vector3 GetAbsoluteVector3(Vector3 vector)
        {
            return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        }

        public static string GetStringFromFile(string path)
        {
            return File.ReadAllText(Application.dataPath + path);
        }

        public static T StringToEnum<T>(string text) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), text);
        }

        public static int RandomRange(int minimum, int maximum)
        {
            UnityEngine.Random.InitState(UnityEngine.Random.Range(0, 256666));
            return UnityEngine.Random.Range(minimum, maximum);
        }

        public static void ToggleVisibility(GameObject toggleObject)
        {
            toggleObject.SetActive(!toggleObject.activeSelf);
        }

        public static List<T> GetShuffledList<T>(List<T> list)
        {
            var array = list;

            for (int i = 0; i < list.Count; i++)
            {
                int rand = UnityEngine.Random.Range(0, list.Count);
                T temp = array[rand];
                array[rand] = array[i];
                array[i] = temp;
            }

            return array;
        }
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
    
    public static class BetterColors
    {
        public static Color blue = new Color32(46, 75, 242, 255);
        public static Color orange = new Color32(218, 126, 36, 255);
        public static Color red = new Color32(209, 43, 40, 255);
    }
}

namespace DevKacper.Interface
{
    public interface IDamageable
    {
        void TakeDamage(int value);
    }
}