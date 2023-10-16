namespace CamundaState.Models.dto
{
	public class BaseResponseDto<T>
	{
		public T data;
		public bool status;
		public string message;
	}
}
