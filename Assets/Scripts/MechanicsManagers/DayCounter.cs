using UnityEngine;

public class DayCounter : MonoBehaviour
{
   [SerializeField] public  int dayCount;

   void Start()
   {
      dayCount = 1;
   }

   public void NextDay()
   {
      dayCount++;
      Debug.Log("Next day initiated");
      
      if (dayCount == 8)
      {
         GameManager.Instance.ChangeState(GameState.GameWon);
      }
   }
}
