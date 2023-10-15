// See https://aka.ms/new-console-template for more information
using Oasis1;
using RelativityDemo;
using RelativityDemo.Locations;
using RelativityDemo.SaveData;

DateTime start = DateTime.UtcNow; //date and time the universe started
Space2D space = Setup.SpaceSetup(start);

IShipTerminal terminal = new ConsoleTerminal();
ISaveDataManager saveDataManager = new JsonSaveDataManager();

GameState data;
Ship ship;
data = saveDataManager.Load();
if (data is null)
    ship = Setup.ShipSetup(space, terminal);
else
{
    ILocation location = space.Locations.Single(x => x.Name == data.CurrentLocationName);
    location.Update(data.CurrentLocationTime);
    ship = data.Ship;
    ship.Wake(space, terminal, location);
}

ship.ShipMenu();