using AutoMapper;
using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Application.Menus.Queries.GetMenus;
using Dinner.Contracts.Menu;
using MediatR;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace Dinner.Api.Controllers
{

    [AllowAnonymous]
    public class MenuController : BaseController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public MenuController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("CreateMenue/{hostId}")]
        public async Task<IActionResult> CreateMenue(string hostId, CreateMenuRequest request)
        {
            var command = _mapper.Map<CreateMenuCommand>(request);
            //command.HostId = hostId;
            command.HostId = Guid.NewGuid().ToString();
            var res = await _sender.Send(command);

            return res.Match(
            success => Ok(_mapper.Map<MenuResponse>(res.AsT0)),
            error => Problem(res.AsT1));
 
        }

        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var res = await _sender.Send(new GetMenusQuery());

            return res.Match(
            success => Ok(_mapper.Map<List<MenuResponse>>(res.AsT0)),
            error => Problem(res.AsT1));

        }

    }
}
