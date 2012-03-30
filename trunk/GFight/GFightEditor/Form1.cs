using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GFightEditor {
  public partial class frmGFightEditor: Form {
    // variables
    // methods
    public frmGFightEditor() {
      InitializeComponent();
    }

    private void lsbAvailableItems_CursorChanged( object sender, EventArgs e ) {

    }
    //properties
  }

  [Serializable]
  public class ItemEdit {
    // variables
    private BscItem[] ItemList;
    private Int32 index;
    private ListBox.ObjectCollection AvailableItems;
    // methods
    public void SelectItem( String Item_Name ) { 
      
    }
    public ItemEdit() {
      AvailableItems = new ListBox.ObjectCollection( null );

      Array.Resize( ref ItemList, 0 );
      index = -1;
    }
    // properties
    public Int32 Index {
      get { return index; }
      set {
        index = value;
      }
    }
    public BscItem Item {
      get { return ItemList[index]; }
      set { ItemList[index] = value; }
    }
    public Int32 Quantity {
      get { return ItemList.Count(); }
    }
  }
}
