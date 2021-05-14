using System;
namespace MemberToolLibrary
{
    public class Enum
    {
        enum categories
        {
            gardening = 1,
            flooring = 2,
            fencing = 3,
            measuring = 4,
            cleaning = 5,
            painting = 6,
            electronic = 7,
            electricity = 8,
            automotive = 9
        }

        public enum gardening
        {
            LineTrimmers = 1,
            LawnMowers = 2,
            HandTools = 3,
            Wheelbarrows = 4,
            GardenPowerTools = 5
        }

        enum flooring
        {
            Scrapers = 1,
            FloorLasers = 2,
            FloorLevellingTools = 3,
            FloorLevellingMaterials = 4,
            FloorHandTools = 5,
            TilingTools = 6
        }

        enum fencing
        {
            HandTools = 1,
            ElectricFencing = 2,
            SteelFencingTools = 3,
            PowerTools = 4,
            FencingAccessories = 5
        }

        enum measuring
        {
            DistanceTools = 1,
            LaserMeasurer = 2,
            MeasuringJugs = 3,
            TemperatureHumidityTools = 4,
            LevellingTools = 5,
            Markers = 6
        }

        enum cleaning
        {
            Draining = 1,
            CarCleaning = 2,
            Vacuum = 3,
            PressureCleaners = 4,
            PoolCleaning = 5,
            FloorCleaning = 6
        }

        enum painting
        {
            SandingTools = 1,
            Brushes = 2,
            Rollers = 3,
            PaintRemovalTools = 4,
            PaintScrapers = 5,
            Sprayers = 6
        }

        enum electronic
        {
            VoltageTester = 1,
            Oscilloscopes = 2,
            ThermalImagine = 3,
            DataTestTool = 4,
            InsulationTesters = 5
        }

        enum electricity
        {
            TestEquipment = 1,
            SafetyEquipment = 2,
            BasicHandTools = 3,
            CircuitProtection = 4,
            CableTools = 5
        }

        enum automotive
        {
            Jacks = 1,
            AirCompressors = 2,
            BatteryChargers = 3,
            SocketTools = 4,
            Braking = 5,
            Drivetrain = 6
        }
    }
}
