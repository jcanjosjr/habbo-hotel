using System.Collections.Generic;
using System.Windows.Forms;
using lib;

namespace Views
{

  public abstract class FormBase : Form
  {
    public List<GenericField> fields;

    public FormBase()
    {
      this.fields = new List<GenericField>();
    }
  }
}