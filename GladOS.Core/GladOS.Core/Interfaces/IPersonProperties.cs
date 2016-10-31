using gladOS.Core.Models;

namespace gladOS.Core.Services
{
    public interface IPersonProperties
    {
        PersonInfo CreatePerson();
        PersonInfo CreatePerson(string name, string number, string employer,
                                       string email);
        PersonInfo CreatePerson(string id, string name, string number, string employer,
                               string email);
    }
}
