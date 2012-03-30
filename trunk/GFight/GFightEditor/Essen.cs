using System;

public enum ItemType { 
  itNormal, itWeapon, itShield, itHelm, 
  itChest,  itPants,  itBoots,  itGloves 
}; // the type of the item
public enum ItemAtribute { iaStrenght, iaAgility, iaLife, iaDefense }; // waht kind of tribute
public enum MobType { mtMonster, mtPlayer }; // what is? player, monster...
public enum SocketStatus { sfEmpty, sfNotEmpty }; // the socket status

/* STRUCTS */
// atribute and value
public struct AtribValue {
  ItemAtribute Atributte;
  Int32        Value;
}

/* CLASSES */
// single socket
public class SocketValue {
  // variables
  private BscItem socket;
  private SocketStatus status;
  private Int32 quantity;
  // methods
  public SocketValue() {
    socket = new BscItem();
    quantity = 0;
    status = SocketStatus.sfEmpty;
  }
  public void SetItem( BscItem NewItem, Int32 Qtde ) {
    socket.CopyFrom( NewItem );
    quantity = Qtde;
    status = SocketStatus.sfNotEmpty;
  }
  public BscItem GetItem() {
    status = SocketStatus.sfEmpty;
    quantity = 0;
    return socket;
  }
  // properties
  public BscItem Socket {
    get { return socket; }
  }
  public SocketStatus Status {
    get { return status; }
  }
  public Int32 Quantity {
    get { return quantity; }
  }
}
// Fix and variant value
public class FixnVar {
  // variables
  private Int32 max_Value;
  private Int32 var_Value;
  // methods
  public void SetMax_Value(Int32 NewValue) {
    var_Value = max_Value = NewValue < 0 ? 0 : NewValue;
  }
  public FixnVar(Int32 Fixed_Value) {
    max_Value = var_Value = Fixed_Value < 0 ? 0 : Fixed_Value;
  }
  // properties
  public Int32 Max_Value {
    get { return max_Value; }
  }
  public Int32 Var_Value {
    get { return var_Value; }
    set {
      if (value < 0) {
        var_Value = 0;
      } else if (value > max_Value) {
        var_Value = max_Value;
      } else
        var_Value = value;
    }
  }
}
// the basic class
public class BscObj {
  // variables
  private String name; // name
  private Int32 tag;   // tag
  //methods
  public BscObj() {
    name = "";
    tag  = 0;
  }
  //properties
  public String Name {
    get { return name; }
    set { name = value; }
  }
  public Int32 Tag {
    get { return tag; }
    set { tag = value; }
  }
}
// inventory class
public class BscInventory {
  // variables
  private SocketValue[] sockets;
  private Int32 quantityOfItems;
  // methods
  private void CalcQtdeItems() {
    quantityOfItems = 0;
    for (int i = 0; i < sockets.Length - 1; i++) {
      if (sockets[i].Status == SocketStatus.sfNotEmpty)
        quantityOfItems++;
    }
  }
  public BscInventory(Int32 Socket_Length) {
    Array.Resize(ref sockets, Socket_Length);
    for (int i = 0; i < sockets.Length - 1; i++) {
      sockets[0] = new SocketValue();
    }
  }
  public Boolean IsEmpty() {
    for (int i = 0; i < sockets.Length - 1; i++) {
      if (sockets[i].Status == SocketStatus.sfNotEmpty) 
        return false;
    }
    return true;
  }
  // properties
  public SocketValue[] Sockets {
    get { return sockets; }
    set { 
      sockets = value;
      CalcQtdeItems();
    }
  }
  public Int32 QuantityOfItems {
    get { return quantityOfItems; }
  }
}
// equip class
public class BscEquip { 
  // variables
  private SocketValue socket_Head;
  private SocketValue socket_Chest;
  private SocketValue socket_Pants;
  private SocketValue socket_Boots;
  private SocketValue socket_Gloves;
  private SocketValue socket_Weapon;
  private SocketValue socket_Shield;
  // methods
  public BscEquip() {
    socket_Head   = new SocketValue();
    socket_Chest  = new SocketValue();
    socket_Pants  = new SocketValue();
    socket_Boots  = new SocketValue();
    socket_Gloves = new SocketValue();
    socket_Weapon = new SocketValue();
    socket_Shield = new SocketValue();
  }
  // properties
  public SocketValue Socket_Head {
    get { return socket_Head; }
    set { socket_Head = value; }
  }
  public SocketValue Socket_Chest {
    get { return socket_Chest; }
    set { socket_Chest = value; }
  }
  public SocketValue Socket_Pants {
    get { return socket_Pants; }
    set { socket_Pants = value; }
  }
  public SocketValue Socket_Boots {
    get { return socket_Boots; }
    set { socket_Boots = value; }
  }
  public SocketValue Socket_Gloves {
    get { return socket_Gloves; }
    set { socket_Gloves = value; }
  }
  public SocketValue Socket_Weapon {
    get { return socket_Weapon; }
    set { socket_Weapon = value; }
  }
  public SocketValue Socket_Shield {
    get { return socket_Shield; }
    set { socket_Shield = value; }
  }
}
// the basic item class
[Serializable]
public class BscItem: BscObj {
  // variables
  private ItemType item_Type;
  private AtribValue[] atributes;
  private FixnVar durability;
  // methods
  public BscItem() {
    durability = new FixnVar(0);
    item_Type = ItemType.itNormal;

    Array.Resize(ref atributes, 1);
  }
  public void CopyFrom(BscItem NewItem) {
    Name       = NewItem.Name;
    item_Type  = NewItem.Item_Type;
    durability = NewItem.Durability;

    Array.Resize(ref atributes, NewItem.Atributes_Length);
    for (int i = 0; i < atributes.Length - 1; i++) {
      atributes[i] = NewItem.Atributes[i];
    }
  }
  // properties
  public ItemType Item_Type {
    get { return item_Type; }
    set { item_Type = value; }
  }
  public AtribValue[] Atributes {
    get { return atributes; }
    set { atributes = value; }
  }
  public Int32 Atributes_Length {
    get { return atributes.Length; }
    set { Array.Resize(ref atributes, value); }
  }
  public FixnVar Durability {
    get { return durability; }
    set { durability = value; }
  }
}
// the mob class
[Serializable]
public class BscMob: BscObj {
  //variables
  private Int32        Str;
  private Int32        Agi;
  private FixnVar      life;
  private MobType      mob_Type;
  private BscInventory inventory;
  private BscEquip     equip;
  private Int32        gold;
  //methods
  public BscMob(MobType mType) {
    mob_Type = mType;

    Str  = 0;
    Agi  = 0;
    gold = 0;
    inventory = new BscInventory(0);
    equip = new BscEquip();
  }
  //properties
  public Int32 Strenght {
    get { return Str; }
    set { 
      Str = value < 0 ? 0 : value;
      life.SetMax_Value((Int32) (Str * 0.8f));
    }
  }
  public Int32 Agility {
    get { return Agi; }
    set { Agi = value < 0 ? 0 : value; }
  }
  public Int32 Attack {
    get { return (Int32) (Str * 1.3f); }
  }
  public Int32 Defense {
    get { return (Int32) ((Str * 0.3f) + (Agi * 0.85f)); }
  }
  public FixnVar Life {
    get { return life; }
    set { life = value; }
  }
  public BscInventory Inventory {
    get { return inventory; }
    set { inventory = value; }
  }
  public BscEquip Equip {
    get { return equip; }
    set { equip = value; }
  }
  public Int32 Gold {
    get { return gold; }
    set { gold = value; }
  }
}
// the Player class
[Serializable]
public class FPlyr: BscMob {
  // variables
  // methods
  public FPlyr(MobType mType): base(mType) { 
  }
  // properties
}