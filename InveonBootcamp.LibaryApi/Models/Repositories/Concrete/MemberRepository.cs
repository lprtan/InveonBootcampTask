using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace InveonBootcamp.LibaryApi.Models.Repositories.Concrete
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        
    }
}
