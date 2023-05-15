namespace FluentBuilderPattern;

public class MarineUnitBuilder : 
    INameSetter, 
    IUnitIntendedUseSetter, 
    IDimensionsSetter, 
    IMechanicalInstallationSetter, 
    IVersatileInstallationSetter, 
    IElectricalInstallationSetter,
    IBrandAndModelSetter,
    IMarineUnitBuilder
{
    private readonly MarineUnit _unit;

    private readonly List<ElectricalInstallation> _electricalInstallations = new ();

    private MarineUnitBuilder() => 
        _unit = new MarineUnit();

    public static INameSetter Initialize() => 
        new MarineUnitBuilder();

    public IUnitIntendedUseSetter WithUnitName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Unit name is required, otherwise it will bring bad luck !");

        _unit.UnitName = name;

        return this;
    }

    public IDimensionsSetter WithIntendedUse(UnitIntendedUse unitIntendedUse)
    {
        //validity checks

        _unit.UnitIntendedUse = unitIntendedUse;

        return this;
    }

    public IMechanicalInstallationSetter WithDimensions(Dimensions dimensions)
    {
        //validity checks

        _unit.Dimensions = dimensions;

        return this;
    }

    
    public IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation)
    {
        //validity checks

        _unit.MechanicalInstallation = mechanicalInstallation;

        return this;
    }

    public IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation)
    {
        //validity checks

        _unit.VersatileInstallation = versatileInstallation;

        return this;
    }

    public IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation)
    {
        //validity checks

        _electricalInstallations.Add(electricalInstallation);

        return this;
    }

    public IBrandAndModelSetter WithNoMoreElectricalInstallation()
    {
        _unit.ElectricalInstallation = _electricalInstallations.ToArray();

        return this;
    }

    public IMarineUnitBuilder WithBrandAndModel(string brand, string model)
    {
        //validity checks

        _unit.Brand = brand;
        _unit.Model = model;

        return this;
    }

    public MarineUnit Build() => _unit;
}

public interface INameSetter
{
    IUnitIntendedUseSetter WithUnitName(string name);
}

public interface IUnitIntendedUseSetter
{
    IDimensionsSetter WithIntendedUse(UnitIntendedUse unitIntendedUse);
}

public interface IDimensionsSetter
{
    IMechanicalInstallationSetter WithDimensions(Dimensions dimensions);
}

public interface IMechanicalInstallationSetter
{
    IVersatileInstallationSetter WithMechanicalInstallation(MechanicalInstallation mechanicalInstallation);
}

public interface IVersatileInstallationSetter
{
    IElectricalInstallationSetter WithVersatileInstallation(VersatileInstallation versatileInstallation);
}

public interface IElectricalInstallationSetter
{
    IElectricalInstallationSetter WithElectricalInstallation(ElectricalInstallation electricalInstallation);

    IBrandAndModelSetter WithNoMoreElectricalInstallation();
}

public interface IBrandAndModelSetter
{
    IMarineUnitBuilder WithBrandAndModel(string brand, string model);
}

public interface IMarineUnitBuilder
{
    MarineUnit Build();
}