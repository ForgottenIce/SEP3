using Application.LogicInterfaces;
using Shared.Models;

namespace Application.Logic;

public class PackageLogic: IPackageLogic
{
    public async Task<List<Package>> GetAllAsync()
    {
        List<Package> packages = new List<Package>();
        Package package1 = new Package
        {
            Destination = "Horsens", Id = 2, OrderId = 1, TimeStamp = new DateTime()
        };
        Package package2 = new Package
        {
            Destination = "Odense", Id = 2, OrderId = 1, TimeStamp = new DateTime()
        };
        Package package3 = new Package
        {
            Destination = "Aarhus", Id = 2, OrderId = 1, TimeStamp = new DateTime()
        };
        packages.Add(package1);
        packages.Add(package2);
        packages.Add(package3);
        return packages;
    }
}