using gladOS.Core.Models;

namespace gladOS.Core.Services
{
    public interface IPersonProperties
    {
        Person CreatePerson();

        Person CreatePerson(string name, string number, string employer,
                                       string email);
        Person CreatePerson(string id, string name, string number, string employer,
                               string email);
    }
}
