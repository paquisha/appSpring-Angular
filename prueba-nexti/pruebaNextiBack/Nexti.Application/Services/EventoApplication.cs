using AutoMapper;
using Nexti.Application.Commons.Base;
using Nexti.Application.Dtos.Request;
using Nexti.Application.Dtos.Response;
using Nexti.Application.Interfaces;
using Nexti.Application.Validators.Eventos;
using Nexti.Domain.Entities;
using Nexti.Infrastructure.Commons.Bases.Request;
using Nexti.Infrastructure.Commons.Bases.Response;
using Nexti.Infrastructure.Persistences.Interfaces;
using Nexti.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Application.Services
{
    public class EventoApplication : IEventoApplication
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly EventValidator _validatioReles;

        public EventoApplication(IUnitOfWork unitOfWork, IMapper mapper, EventValidator validationRules)
        {
            _unitofWork = unitOfWork;
            _mapper = mapper;
            _validatioReles = validationRules;
        }

        public async Task<BaseResponse<bool>> EditEvento(int id, EventoRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var eventoEdit = await EventoById(id);

            if(eventoEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            var evento = _mapper.Map<Evento>(requestDto);
            evento.Id = id;
            response.Data = await _unitofWork.Category.EditEvento(evento);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_Failed;
            }

            return response;
        }

        public async Task<BaseResponse<EventoResponseDto>> EventoById(int id)
        {
            var response = new BaseResponse<EventoResponseDto>();
            var eventos = await _unitofWork.Category.EventoById(id);

            if(eventos is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<EventoResponseDto>(eventos);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public Task<BaseResponse<BaseEntityResponse<EventoResponseDto>>> ListEventos(BaseFilterRequest filters)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<EventoSelectResponseDto>>> ListSelectEventos()
        {
            var response = new BaseResponse<IEnumerable<EventoSelectResponseDto>>();
            var eventos = await _unitofWork.Category.ListSelectEvento();

            if(eventos is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<EventoSelectResponseDto>>(eventos);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterEvento(EventoRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationresul = await _validatioReles.ValidateAsync(requestDto);

            if (!validationresul.IsValid)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationresul.Errors;
                return response;
            }

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_Failed;

            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveEvento(int id)
        {
            var response = new BaseResponse<bool>();
            var evento = await EventoById(id);

            if(evento.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitofWork.Category.RemoveEvento(id);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_Failed;
            }
            return response;
        }
    }
}
