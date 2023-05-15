using FluentBuilderPattern;

var unit = MarineUnitBuilder
    .Initialize()
    .WithUnitName("Maria")
    .WithIntendedUse(new UnitIntendedUse(TypeOfUse.MarineLeisure, "Fishing", "Hunting sharks"))
    .WithDimensions(new Dimensions(100, 100, 100))
    .WithMechanicalInstallation(new MechanicalInstallation())
    .WithVersatileInstallation(new VersatileInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithElectricalInstallation(new ElectricalInstallation())
    .WithNoMoreElectricalInstallation()
    .WithBrandAndModel("Volvo", "Penta")
    .Build();

Console.WriteLine(unit.UnitIntendedUse.TypeOfUse);