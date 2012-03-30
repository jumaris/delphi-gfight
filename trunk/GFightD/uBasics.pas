unit uBasics;

interface

uses
  FMX.Types;

type
  TFixnVar = class;

  TBuildingType = (btGenerator);

  TCrsl = Integer;
  TDtro = Integer;
  TEnrg = Integer;

  TMaxCrsl = class of TFixnVar;
  TMaxDtro = class of TFixnVar;
  TMaxEnrg = class of TFixnVar;

  TNotifyLevel  = procedure(NewLevel: Integer) of object;
  TNotifyYield  = procedure(Amount:   Integer) of object;
  TNotifyUpdate = procedure of object;

  TFixnVar = class
  private
    FMaxValue: Integer;
    FVarValue: Integer;
    procedure SetVarValue(const Value: Integer);
  public
    constructor Create(NewFixValue: Integer);
  public
    property MaxValue: Integer read FMaxValue;
    property VarValue: Integer read FVarValue write SetVarValue;
  end;

  ICallUpdate = interface
    ['{DC23E176-FEC3-4203-85B6-C72C91415189}']
    function GetOnUpdate: TNotifyUpdate;
    procedure SetOnUpdate(const Value: TNotifyUpdate);
    function GetDelay: TTimer;
    procedure SetDelay(const Value: TTimer);
    procedure Update;
    property OnUpdate: TNotifyUpdate read GetOnUpdate write SetOnUpdate;
    property Delay: TTimer read GetDelay write SetDelay;
  end;

  TBasicBuilding = class(TInterfacedObject, ICallUpdate)
  private
    function GetOnUpdate: TNotifyUpdate;
    procedure SetOnUpdate(const Value: TNotifyUpdate);
    function GetDelay: TTimer;
    procedure SetDelay(const Value: TTimer);
  private
    FName:     String;
    FLevel:    Integer;
    FOnLevel:  TNotifyLevel;
    FOnUpdate: TNotifyUpdate;
    FType:     TBuildingType;
    FTimer:    TTimer;
  public
    constructor create;

    procedure UpLevel;
    procedure Update(Sender: TObject);
  public
    property Name:  String        read FName  write FName;
    property Level: Integer       read FLevel write FLevel;
    property _Type: TBuildingType read FType  write FType;

    property OnLevel:  TNotifyLevel  read FOnLevel    write FOnLevel;
    property OnUpdate: TNotifyUpdate read GetOnUpdate write SetOnUpdate;
    property Delay:    TTimer        read GetDelay    write SetDelay;
  end;

implementation

{ TFixnVar }

constructor TFixnVar.Create(NewFixValue: Integer);
begin

end;

procedure TFixnVar.SetVarValue(const Value: Integer);
begin
  if (Value < 0) then
    FVarValue := 0
  else
  if (Value > FMaxValue) then
    FVarValue := FMaxValue
  else
    FVarValue := Value;
end;

{ TBasicBuilding }

constructor TBasicBuilding.create;
begin
  FTimer := TTimer.Create(Self);
  FTimer.Interval := 1000;
  FTimer.OnTimer  := Update;
  FTimer.Enabled  := True;

  FLevel := 0;
  FName  := '';
end;

function TBasicBuilding.GetDelay: TTimer;
begin
  Result := FTimer;
end;

function TBasicBuilding.GetOnUpdate: TNotifyUpdate;
begin
  Result := FOnUpdate;
end;

procedure TBasicBuilding.SetDelay(const Value: TTimer);
begin
  FTimer := Value;
end;

procedure TBasicBuilding.SetOnUpdate(const Value: TNotifyUpdate);
begin
  FOnUpdate := Value;
end;

procedure TBasicBuilding.Update(Sender: TObject);
begin
  if Assigned(FOnUpdate) then
    OnUpdate;
end;

procedure TBasicBuilding.UpLevel;
begin
  Inc(FLevel);
  if Assigned(FOnLevel) then
    OnLevel(FLevel);
end;

end.
