using KraevedAPI.Models;

namespace KraevedAPI.Repository {
    interface IRolesRepository
    {
        Role GetRoleById(int roleId);
        Role GetRoleByName(string name);
    }
}