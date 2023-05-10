using Nexti.Application.Commons.Base;
using Nexti.Application.Dtos.Request;
using Nexti.Application.Dtos.Response;
using Nexti.Infrastructure.Commons.Bases.Request;
using Nexti.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Application.Interfaces
{
    public interface IEventoApplication
    {
        Task<BaseResponse<BaseEntityResponse<EventoResponseDto>>> ListEventos(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<EventoSelectResponseDto>>> ListSelectEventos();
        Task<BaseResponse<EventoResponseDto>> EventoById(int id);
        Task<BaseResponse<bool>> RegisterEvento(EventoRequestDto requestDto);
        Task<BaseResponse<bool>> EditEvento(int id, EventoRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveEvento(int id);
    }
}
