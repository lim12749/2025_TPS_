using UnityEngine;

public class Player : PlayerStates 
{
    public override void Start()
    {
        base.Start();
       
    }
    public override void LevelUp()
    {
        Debug.Log("자식클래스 현재 레벨: " + Level); 
        //base.LevelUp(); 1
        Debug.Log("자식클래스2 현재 레벨: " + Level); 

    }//레벨업 메소드, 추상 메소드로 선언
}
