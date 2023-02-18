using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;
using OpenAI.Helpers.Articles.Response;

namespace OpenAI.Helpers.Services.OpenAICompletion;


public interface IOpenAIImageServices
{
    Task<GetOneResult<ImageCreateResponse>> CreateImageCompletion(string promptData);
}
public class OpenAIImageServices : IOpenAIImageServices
{
    private readonly IOpenAIService _openAıService;

    public OpenAIImageServices(IOpenAIService openAıService)
    {
        _openAıService = openAıService;
    }

    public async Task<GetOneResult<ImageCreateResponse>> CreateImageCompletion(string promptData)
    {
        ImageCreateResponse imageCreateResponse = new();
        try
        {
            imageCreateResponse = await _openAıService.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = promptData,
                N = 2,
                Size = StaticValues.ImageStatics.Size.Size256,
                User = "default",
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url
            });
            return new GetOneResult<ImageCreateResponse>()
            {
                IsSuccess = true,
                Message = string.Join("\n", imageCreateResponse.Results.Select(x => x.Url))
            };
        }
        catch (Exception ex)
        {
            string exceptionMessage = ex.Message + " " + ex.InnerException?.Message;
            return new GetOneResult<ImageCreateResponse>{
                IsSuccess = false,
                Message = exceptionMessage + " " + imageCreateResponse.Error
            };
        }
    }
}