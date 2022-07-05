using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;

namespace lib
{
  public class GenericField
  {
    public string id;
    public TextBox textBox;
    public Label label;

    public GenericField(
        string id,
        int pointX,
        int pointY,
        string label,
        int sizeZ = 240,
        int sizeW = 15,
        char characterPass = ' ',
        string valueDefault = ""

    )
    {
      this.id = id;

      this.textBox = new TextBox();
      this.textBox.Location = new Point(pointX, pointY + 25);
      this.textBox.Size = new Size(sizeZ, sizeW);
      this.textBox.Text = valueDefault;

      this.label = new Label();
      this.label.Text = label;
      this.label.Location = new Point(pointX, pointY);

      if (!Char.IsWhiteSpace(characterPass))
      {
        this.textBox.PasswordChar = characterPass;
      }
    }
  }
}