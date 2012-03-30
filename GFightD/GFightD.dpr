program GFightD;

uses
  FMX.Forms,
  uMain in 'uMain.pas' {Form1},
  uBuilding in 'uBuilding.pas',
  uBasics in 'uBasics.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
