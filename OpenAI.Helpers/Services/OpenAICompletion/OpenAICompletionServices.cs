using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.Helpers.Articles.Response;

namespace OpenAI.Helpers.Services.OpenAICompletion
{
    public interface IOpenAICompletionServices
    {
        Task<GetOneResult<CompletionCreateResponse>> CreateChatCompletion(string promptData);
    }
    public class OpenAICompletionServices : IOpenAICompletionServices
    {
        readonly IOpenAIService _openAIService;

        public OpenAICompletionServices(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<GetOneResult<CompletionCreateResponse>> CreateChatCompletion(string promptData)
        {
            CompletionCreateResponse chatCompletionCreateResponse = new();
            try
            {
                chatCompletionCreateResponse = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = promptData,
                    MaxTokens = 2500
                }, Models.TextDavinciV3);
                return new GetOneResult<CompletionCreateResponse>
                {
                    Entity = chatCompletionCreateResponse,
                    IsSuccess = chatCompletionCreateResponse.Successful,
                    Message = chatCompletionCreateResponse.Choices[0].Text
                };
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message + " " + ex.InnerException?.Message;
                return new GetOneResult<CompletionCreateResponse>{
                    IsSuccess = false,
                    Message = exceptionMessage + " " + chatCompletionCreateResponse.Error
                };
            }
            
        }
    }
}
