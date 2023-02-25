using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell: MonoBehaviour {

  public Sprite[] sprites = new Sprite[27];
  public char value;
  public int pos;
  private SpriteRenderer spriteRenderer;
  // Start is called before the first frame update
  void Start() {
    value = ' ';
    spriteRenderer = GetComponent < SpriteRenderer > ();
    setSprite();
  }

  // Update is called once per frame
  void Update() {
    setSprite();
  }

  void setValueCell(char val) {
    this.value = val;
  }

  void setSprite() {
    if (this.value == ' ') {
      spriteRenderer.sprite = sprites[0];
    } else {
      spriteRenderer.sprite = sprites[(int) this.value - 96];
    }
  }

  void setCorrectCell(bool cor) {
    transform.GetChild(0).gameObject.SetActive(cor);
  }

  void setMidCell(bool cor) {
    transform.GetChild(1).gameObject.SetActive(cor);
  }

}