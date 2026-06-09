using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using MusicStore.Services.Interface;
using System.Net.Http.Headers;


namespace MusicStore.Services.Implementation
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository repository;
        private readonly ILogger<ConcertService> logger;
        private readonly IMapper mapper;


        public ConcertService(IConcertRepository repository, ILogger<ConcertService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<BaseResponseGeneric<ICollection<ConcertResponseDto>>> GetAsync(string? title)
        {
            var response = new BaseResponseGeneric<ICollection<ConcertResponseDto>>();
            try
            {
                var data = await repository.GetAsync(title);
                //TODO: Map data to ConcertResponseDto
                response.Data = mapper.Map<ICollection<ConcertResponseDto>>(data);  
                response.Success = data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error retrieving information.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
                response.Success = false;
            }
            return response;
        }

        public async Task<BaseResponseGeneric<ConcertResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<ConcertResponseDto>();
            try
            {
                var data = await repository.GetAsync(id);
                response.Data = mapper.Map<ConcertResponseDto>(data);
                response.Success = data !=null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error retrieving information.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
                response.Success = false;
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ConcertRequestDto concertReq)
        {
            var response = new BaseResponse();
            try
            {
                var data = await repository.GetAsync(id);
                if (data is null)
                {
                    response.ErrorMessage = "Data not found";
                    return response;
                }
                mapper.Map(concertReq, data);
                await repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error updating information.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(ConcertRequestDto concertReq)
        {
            var response = new BaseResponseGeneric<int>();
            try
            {
                var data = mapper.Map<Concert>(concertReq);
                var id = await repository.AddAsync(data);
                response.Data = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error adding information.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                await repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error deleting information.";
                logger.LogError(ex, "{ErrorMessage} {Message}", response.ErrorMessage, ex.Message);
                response.Success = false;
            }
            return response;
        }

        public async Task<BaseResponse> FinalizeAsync(int id)
        {
            var respomse = new BaseResponse();
            try
            {
                await repository.FinalizeAsync(id);
                respomse.Success = true;
            }
            catch (Exception ex)
            {
                respomse.ErrorMessage = "Error finalizing concert.";
                logger.LogError(ex, "{ErrorMessage} {Message}", respomse.ErrorMessage, ex.Message);
                respomse.Success = false;
            }
            return respomse;
        }
    }
}
