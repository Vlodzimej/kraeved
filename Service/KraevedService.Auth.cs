using KraevedAPI.Constants;
using KraevedAPI.Models;
using Microsoft.Net.Http.Headers;

namespace KraevedAPI.Service
{
    public partial class KraevedService : IKraevedService
    {
        /// <summary>
        /// Генерация кода подтверждения по номеру телефона 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<Boolean> SendSms(string phone)
        {
            var random = new Random();
            var smsCode = random.Next(100000, 999999);

            var smsCodeEntry = new SmsCode() {
                Phone = phone, 
                Code = smsCode.ToString(), 
                StartDate = DateTime.Now
            };

            _unitOfWork.SmsCodesRepository.Insert(smsCodeEntry);
            await _unitOfWork.SaveAsync();

            var apiKey = "MJ6BR436N7IW5VX97R1JIM36CO8N548L0ZOJ755X6127X0E3EJ9789YU50CMAYU";
            var url = $"https://smspilot.ru/api.php?send={smsCode}&to={phone}&apikey={apiKey}&debug=amel-07@mail.ru&test=1";
            //var url = $"https://smspilot.ru/api.php?balance=rur&apikey={apiKey}";

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers = {
                    { HeaderNames.Accept, "application/json" },
                    { HeaderNames.UserAgent, "KraevedAPI/1.0" },
                    { HeaderNames.AcceptCharset, "utf-8" }
                }
            };

            // var httpClient = _httpClientFactory.CreateClient();
            // var httpResponse = await httpClient.SendAsync(httpRequestMessage);

            
            // if (httpResponse.IsSuccessStatusCode)
            // {
            //     var contentString = await httpResponse.Content.ReadAsStringAsync();
            //     return true;
            // } 
            return false;
        }

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="loginDto">Данные для входа</param>
        public async Task<User> Login(LoginDto loginDto) {
            var smsCode = _unitOfWork.SmsCodesRepository.Get(x => x.Phone == loginDto.Phone && x.Code == loginDto.Code);

            if (smsCode.Count() == 0) {
                throw new Exception(ServiceConstants.Exception.NotFound);
            }

            removeSmsCodesOfUser();
            
            var user = _unitOfWork.UsersRepository.Get(x => x.Phone == loginDto.Phone).FirstOrDefault() ?? await createUser(loginDto.Phone);
            return user;
        }

        /// <summary>
        /// Создание нового пользователя по номеру телефона 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        private async Task<User> createUser(String phone) {
            var user = new User() {
                Phone = phone,
                Name = "",
                Surname = ""
            };

            _unitOfWork.UsersRepository.Insert(user);
            await _unitOfWork.SaveAsync();
            return user;
        }

        /// <summary>
        /// Удаление всех кодов подтверждения пользователя, которые были созданы более 5 минут назад
        /// </summary>
        /// <returns></returns>
        private async void removeSmsCodesOfUser() {
            var smsCodes = _unitOfWork.SmsCodesRepository.Get(x => x.StartDate < DateTime.Now.AddMinutes(-5));
            foreach (var smsCode in smsCodes) {
                _unitOfWork.SmsCodesRepository.Delete(smsCode.Id);
            }
            await _unitOfWork.SaveAsync();
        }
    }
}