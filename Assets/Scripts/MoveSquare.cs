using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] private Text countText;
    [SerializeField] private GameObject restartButton;
    private bool mouseDown = false;
    private int count = 0;
    private void OnMouseDown() {
        mouseDown = true;    
    }
    private void OnMouseUp() {
        mouseDown = false;
    }
    private void Start() {
        countText.text = $"Count: {count}";
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Circle")) {
            count++;
            Destroy(other.gameObject);
        }
    }
    private void FixedUpdate()
    {
        Move();
        ChangeTextCount();
        SetActiveButton();
    }
    private void Move() {
        Vector2 cursor = Input.mousePosition;
        cursor = Camera.main.ScreenToWorldPoint(cursor);

        if(mouseDown) {
            this.transform.position = cursor;
        }
    }
    private void ChangeTextCount() {
        countText.text = $"Count: {count}";
    }
    private void SetActiveButton() {
        if (count == 5) {
            restartButton.SetActive(true);
        }
    }
}
