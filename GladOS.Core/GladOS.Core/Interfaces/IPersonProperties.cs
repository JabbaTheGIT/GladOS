using GladOS.Core.Models;

namespace GladOS.Core.Services
{
    public interface IPersonProperties
    {
        Person CreatePerson();

        Person CreatePerson(string name, string number, string employer,
                                       string email);

    }
}
