using KraevedAPI.DAL;
using KraevedAPI.DAL.Repository;
using KraevedAPI.Models;

namespace KraevedAPI.Repository
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(KraevedContext _GenealogyContext) : base(_GenealogyContext)
        { }

        public Role GetRoleById(int roleId)
        {
            return context.Roles.Where(role => role.Id == roleId).FirstOrDefault() ?? Role.unknown;
        }

        public Role GetRoleByName(string name)
        {
            return context.Roles.Where(role => role.Name == name).FirstOrDefault() ?? Role.unknown;
        }
    }
}