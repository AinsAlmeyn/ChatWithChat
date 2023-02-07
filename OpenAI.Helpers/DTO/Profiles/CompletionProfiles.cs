using AutoMapper;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Helpers.DTO.Profiles
{
    public class CompletionProfiles : Profile
    {
        public CompletionProfiles()
        {
            CreateMap<CompletionCreateRequest, CompletionRequestDto>().ReverseMap();
            CreateMap<CompletionCreateResponse, CompletionResponseDto>().ReverseMap();
        }
    }
}
