using Altiora.Dtos;
using Altiora.Utils;

namespace Altiora.Helpers
{
    public static class ResponseValidatorUtil
    {
        public static GeneralResponseDto EvaluateResponse<TSource, TDestination>(GeneralResponseDto generalResponseDto)
            where TDestination : new()
        {
            if (generalResponseDto.state)
            {
                TDestination destinationDto = MapperUtil.Map<TSource,TDestination>(generalResponseDto.entity);
                generalResponseDto.entity = destinationDto ?? new TDestination();
            }
            else
            {
                TDestination destinationDto = new();
                generalResponseDto.entity = destinationDto;
                generalResponseDto.state = false;
            }

            return generalResponseDto;
        }
        public static GeneralResponseDto EvaluateListResponse<TSource, TDestination>(GeneralResponseDto generalResponseDto)
            where TDestination : new()
        {
            if (generalResponseDto.state)
            {
                var destinationDto = MapperUtil.MapList<TSource, TDestination>(generalResponseDto.entity);
                generalResponseDto.entity = destinationDto ?? new List<TDestination>();
            }
            else
            {
                TDestination destinationDto = new();
                generalResponseDto.entity = destinationDto;
                generalResponseDto.state = false;
            }

            return generalResponseDto;
        }
    }
}
