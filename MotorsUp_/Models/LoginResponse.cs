using Newtonsoft.Json;

namespace MotorsUp_.Models
{
		public class LoginResponse
		{
		[JsonProperty("token")]
		public string Token { get; set; }

		[JsonProperty("refreshToken")]
		public string RefreshToken { get; set; }

		[JsonProperty("resultado")]
		public bool Resultado { get; set; }

		[JsonProperty("mensaje")]
		public string Mensaje { get; set; }

	}

}
