using GladOS.Core.Models;


namespace GladOS.Core.Services
{
    public interface IPersonServices
    {
        Person CreatePerson(string name, string number, string picture, string employer,
                                       string email);

    }
}
