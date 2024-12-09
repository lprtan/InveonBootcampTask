using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using InveonBootcamp.LibaryApi.Models.Services.Abstract;

namespace InveonBootcamp.LibaryApi.Models.Services.Concrete
{
    public class MemberService : IMemberService
    {
        IMemberRepository _member;

        public MemberService(IMemberRepository member)
        {
            _member = member;
        }

        public void AddMember(Member member)
        {
            _member.Insert(member);
        }

        public void DeleteMember(Member member)
        {
            _member.Delete(member);
        }

        public List<Member> GetAllList()
        {
            return _member.GetListAll();
        }

        public Member GetByID(int id)
        {
            return _member.GetByID(id);   
        }

        public Task<IQueryable<Member>> GetQueryableMemberPagination(int pageNumber, int pageSize)
        {
            return _member.GetQueryable(pageNumber, pageSize);
        }

        public void UpdateMember(Member member)
        {
            _member.Update(member);
        }
    }
}
