// PlayerMover.cs
using UnityEngine;

/// <summary>
/// 마우스로 Y축 회전, 키보드로 이동 (TPS 전형 구조)
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    // 이동 속도 (Inspector에서 조절 가능)
    public float moveSpeed = 5f;
    // 중력 값 (Inspector에서 조절 가능)
    public float gravity = -9.81f;
    // 점프 힘 (Inspector에서 조절 가능)
    public float jumpForce = 5f;
    // 현재 수직 속도
    private float verticalVelocity;
    // 캐릭터 컨트롤러 컴포넌트 참조
    private CharacterController controller;
    // 입력 처리 컴포넌트 참조
    private PlayerInputReader input;
    // 카메라 Transform 참조
    public Transform cameraTransform;
    // 점프 중 여부
    private bool isJumping = false;
    // 애니메이션 컨트롤러 참조
    public PlayerAnimationController animationController;

    // 컴포넌트 초기화
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInputReader>();
    }

    // 매 프레임마다 호출
    void Update()
    {
        // 입력값 받아오기
        Vector2 move = input.MoveInput;
        // 카메라 기준 이동 방향 계산 (Y축 제외)
        Vector3 moveDir = cameraTransform.right * move.x + cameraTransform.forward * move.y;
        moveDir.y = 0f;

        // 땅에 닿아있는 경우
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;

            // 점프 입력이 들어오고 점프 중이 아닐 때
            if (input.JumpPressed && !isJumping)
            {
                verticalVelocity = jumpForce;
                isJumping = true;
            }
        }
        else
        {
            // 공중에 있을 때 중력 적용
            verticalVelocity += gravity * Time.deltaTime;
        }

        // 점프 후 착지 체크
        if (controller.isGrounded && isJumping)
        {
            isJumping = false;
        }

        // 최종 이동 벡터에 수직 속도 적용
        moveDir.y = verticalVelocity;
        // 실제 이동 처리
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        // 애니메이션에 이동 속도 전달
        float flatSpeed = new Vector3(moveDir.x, 0f, moveDir.z).magnitude;
        animationController.UpdateMoveAnimation(flatSpeed);
        // 애니메이션에 점프 상태 전달
        animationController.SetJumping(isJumping);
    }

    /*
    // 아래는 참고용 예전 코드 (비활성화)
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float rotateSpeed = 120f;  // 마우스 회전 속도
    public Transform cameraTransform;

    private CharacterController controller;
    private InputReader inputReader;
    private float verticalVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputReader = GetComponent<InputReader>();
    }

    void Update()
    {
        Vector2 moveInput = inputReader.MoveInput;

        // 1. 카메라 기준으로 이동 방향 설정 (Y축 제외)
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * moveInput.y + camRight * moveInput.x;

        // 2. 중력 적용
        if (controller.isGrounded)
            verticalVelocity = -1f;
        else
            verticalVelocity += gravity * Time.deltaTime;

        moveDir.y = verticalVelocity;
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        // 3. 마우스 좌우 회전만 적용 (Y축 회전)
        float mouseX = inputReader.MouseX;
        if (Mathf.Abs(mouseX) > 0.01f)
        {
            transform.Rotate(Vector3.up, mouseX * rotateSpeed * Time.deltaTime);
        }
    }
    */
}
