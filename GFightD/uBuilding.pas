unit uBuilding;

interface

uses
  uBasics;

type
  TGerador = class(TBasicBuilding)
  private
    FYield: Integer;
    FOnYield: TNotifyYield;
    procedure SetYield(const Value: Integer);
  public
    constructor create;
  public
    property Yield:   Integer      read FYield   write SetYield;
    property OnYield: TNotifyYield read FOnYield write FOnYield;
  end;

implementation

{ TGerador }

constructor TGerador.create;
begin
  _Type := TBuildingType.btGenerator;
end;

procedure TGerador.SetYield(const Value: Integer);
begin
  FYield := Value;
  if Assigned(FOnYield) then
    OnYield(Yield);
end;

end.
