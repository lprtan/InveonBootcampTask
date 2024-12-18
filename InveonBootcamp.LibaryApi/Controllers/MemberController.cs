﻿using InveonBootcamp.LibaryApi.Caching.Interfaces;
using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.ErrorOrSuccessMessage;
using InveonBootcamp.LibaryApi.Models.Pagination;
using InveonBootcamp.LibaryApi.Models.Repositories.Context;
using InveonBootcamp.LibaryApi.Models.Services.Abstract;
using InveonBootcamp.LibaryApi.Models.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace InveonBootcamp.LibaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IRedisCacheService _redisCacheService;
        public MemberController(IMemberService memberService, IRedisCacheService redisCacheService)
        {
            _memberService = memberService;
            _redisCacheService = redisCacheService;
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedMembers(int pageNumber, int pageSize)
        {
            var cacheKey = $"members_page_{pageNumber}_size_{pageSize}";

            var cacheMembersData = await _redisCacheService.GetValueAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheMembersData))
            {
                var members = JsonConvert.DeserializeObject<List<Member>>(cacheMembersData);
                return Ok(ServiceResult<object>.Success(members, 200));
            }

            var query = await _memberService.GetQueryableMemberPagination(pageNumber, pageSize);

            var result = await PaginationHelper<Member>.GetPagedResultAsync(query, pageNumber, pageSize);
            var data = result.Items;

            if (data == null)
            {
                return BadRequest(ServiceResult<IEnumerable<Member>>.Fail("Kitap listesi boş.", 404));
            }

            var serializedResult = JsonConvert.SerializeObject(result.Items);
            await _redisCacheService.SetValueAsync(cacheKey, serializedResult);

            return Ok(ServiceResult<object>.Success(result, 200));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            var cacheKey = "members_all";

            var cacheMembersData = await _redisCacheService.GetValueAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheMembersData))
            {
                var membersData = JsonConvert.DeserializeObject<IEnumerable<Member>>(cacheMembersData);
                return Ok(ServiceResult<object>.Success(membersData, 200));
            }

            var members =  _memberService.GetAllList();

            if (members == null)
            {
                return BadRequest(ServiceResult<IEnumerable<Member>>.Fail("üye listesi boş.", 404));
            }

            var serializedResult = JsonConvert.SerializeObject(members);
            await _redisCacheService.SetValueAsync(cacheKey, serializedResult);

            return Ok(ServiceResult<IEnumerable<Member>>.Success(members, 200));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = _memberService.GetByID(id);

            if (member == null)
            {
                return NotFound(ServiceResult<Member>.Fail("üye bulunamadı.", 404));
            }

            return Ok(ServiceResult<Member>.Success(member, 200));
        }

        [HttpPost]
        public async Task<ActionResult<Member>> CreateMember([FromBody] Member member)
        {
            if (member == null)
            {
                return BadRequest(ServiceResult<Member>.Fail("Geçersiz üye verisi.", 400));
            }

            _memberService.AddMember(member);

            return CreatedAtAction(
                nameof(GetMember),
                new { id = member.Id },
                ServiceResult<Member>.Success(member, 201)
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] Member member)
        {
            var MemberId = _memberService.GetByID(id).Id;

            if (MemberId != id)
            {
                return NotFound(ServiceResult<Member>.Fail("Üye bulunamadı.", 404));
            }

            member.Id = id;
            _memberService.UpdateMember(member);

            return Ok(ServiceResult<Member>.Success(member, 200));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = _memberService.GetByID(id);

            if (member == null)
            {
                return NotFound(ServiceResult<Book>.Fail("Üye bulunamadı.", 404));
            }

            _memberService.DeleteMember(member);

            return Ok(ServiceResult<string>.Success("Üye başarıyla silindi.", 200));
        }
    }
}
