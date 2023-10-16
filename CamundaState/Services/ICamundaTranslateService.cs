using CamundaState.Models;
using CamundaState.Models.dto;

namespace CamundaState.Services;

public interface ICamundaTranslateService
{
	Task<BaseResponseDto<IEnumerable<ProjectWf>>> CheckIsTranslate();

	Task<bool> InvokeTask(IEnumerable<ProjectWf> projects);
}