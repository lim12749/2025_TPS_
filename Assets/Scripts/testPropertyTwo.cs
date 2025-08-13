using UnityEngine;

public class testPropertyTwo : MonoBehaviour
{
    //여기서 프 TestProperty HP MP를 수정하고

    //게임이 시작될때 viewHpmp를 호출
    //게임 실행중에 입력키를 통해 hp, mp를 값을 +1 만들고 viewHpmp를 호출하라 

    //만약 private의 값을 변경을 못한다면  테스트프로퍼티를 수정하라.
    TestProperty test = new TestProperty();
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            test._hp += 1;
            test.mp += 1;
            test.ViewHPMP();
        }
    }
}
