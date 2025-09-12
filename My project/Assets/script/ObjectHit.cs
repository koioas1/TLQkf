using UnityEngine;
using UnityEngine.UI;   // UnityEngine.UI.Text 사용 시 필요
using TMPro;            // TextMeshPro를 쓴다면 필요

public class ObjectHit : MonoBehaviour
{
    [SerializeField] GameObject victoryPanel;   // "승리!" 메시지를 담은 패널 (Canvas 안)
    [SerializeField] float delayBeforeQuit = 3f; // 종료까지 대기 시간(초)

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // 블럭 색상 변경
            GetComponent<MeshRenderer>().material.color = Color.yellow;

            // 승리 메시지 띄우기
            if (victoryPanel != null)
                victoryPanel.SetActive(true);

            // 일정 시간 뒤 게임 종료
            Invoke(nameof(QuitGame), delayBeforeQuit);
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        // 유니티 에디터에서는 플레이 모드 종료
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서는 애플리케이션 종료
        Application.Quit();
#endif
    }
}
