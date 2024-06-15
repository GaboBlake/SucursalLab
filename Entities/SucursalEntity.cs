
public class SucursalEntity
{
    public SucursalEntity()
    {
    }

    public int Id { get; set;}
    public string Name { get; set;}=null!;
    public string Empresa { get; set;}=null!;
    public string Location { get; set;}=null!;
    public int NumEmpleados { get; set;}
    public decimal Presupuesto { get; set;}
}