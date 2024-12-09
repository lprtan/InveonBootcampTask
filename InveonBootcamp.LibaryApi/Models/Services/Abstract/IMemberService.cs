using InveonBootcamp.LibaryApi.Models.Entities;

namespace InveonBootcamp.LibaryApi.Models.Services.Abstract
{
    public interface IMemberService
    {
        void AddMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);
        List<Member> GetAllList();
        Member GetByID(int id);
        Task<IQueryable<Member>> GetQueryableMemberPagination(int pageNumber, int pageSize);
    }
}
