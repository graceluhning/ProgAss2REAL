using UnityEngine;

public class DayCounter : MonoBehaviour
{
   public int dayCount;

   void Start()
   {
      dayCount = 1;
   }

   public void NextDay()
   {
      dayCount++;
      Debug.Log("Next day initiated");
   }
}
