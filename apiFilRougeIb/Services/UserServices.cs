using apiFilRougeIb.Dto.FindAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class UserServices
    {

        private Repositories.UserRepository _userRepository;

        public UserServices()
        {
            this._userRepository = new Repositories.UserRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de themes
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllUsersDto> GetUsers()
        {
            List<Models.User> users = this._userRepository.FindAll();
            List<Dto.FindAll.FindAllUsersDto> usersDto = new List<Dto.FindAll.FindAllUsersDto>();
            users.ForEach(user =>
            {
                usersDto.Add(TransformModelToDto(user));
            });
            return usersDto;
        }
        internal FindAllUsersDto GetUser(long id, string join)
        {
            switch (join)
            {
                case "useranswers":
                    return GetUserJoinUserAnwsers(id);
                case "level":
                    return GetUserJoinLevel(id);
                case "quizz":
                    return GetUserJoinQuizz(id);
                default:
                    return GetUser(id);
            }
        }

        public FindAllUsersDto GetUserJoinLevel(long id)
        {
            Models.User user = this._userRepository.Find(id);
            Dto.FindAll.FindAllUsersDto userDto = TransformModelToDto(user);

            FindAllUsersDto userjoinleveldto = new FindAllUsersJoinLevelsDto(userDto);
            //Console.WriteLine(userjoinleveldto.Level);
            return userjoinleveldto;
        }

        

        private FindAllUsersDto GetUserJoinQuizz(long id)
        {
            Models.User user = this._userRepository.Find(id);
            Dto.FindAll.FindAllUsersDto userDto = TransformModelToDto(user);

            FindAllUsersDto userjoinquizzdto = new FindAllUsersJoinQuizzDto(userDto);
            //Console.WriteLine(userjoinleveldto.Level);
            return userjoinquizzdto;
        }

        public FindAllUsersDto GetUserJoinUserAnwsers(long id)
        {
            Models.User user = this._userRepository.Find(id);
            FindAllUsersDto userDto = TransformModelToDto(user);

            //FindAllUsersJoinUserAnswersDto u = new FindAllUsersJoinUserAnswersDto(userDto);

            FindAllUsersDto userjoinluseranswerdto = new FindAllUsersJoinUserAnswersDto(userDto);
            
            //Console.WriteLine(userjoinleveldto.Level);
            return userjoinluseranswerdto;
        }
        /// <summary>
        ///     Retourne un theme
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllUsersDto GetUser(long id)
        {
            Models.User user = this._userRepository.Find(id);
            Dto.FindAll.FindAllUsersDto userDto = TransformModelToDto(user);
            return userDto;
        }

        /// <summary>
        ///     Persister un theme
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateUserDto PostUser(Dto.Create.CreateUserDto user)
        {
            Models.User userModel = TransformDtoToModel(user);
            Models.User userModelCreated = this._userRepository.Create(userModel);
            return TransformModelToAfterCreateDto(userModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un theme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateUserDto PutUser(long id, Dto.Create.CreateUserDto newUser)
        {
            Models.User userModel = TransformDtoToModel(newUser);
            Models.User userModelUpdated = this._userRepository.Update(id, userModel);
            return TransformModelToAfterCreateDto(userModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un theme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._userRepository.Delete(id);
        }
        private Dto.FindAll.FindAllUsersDto TransformModelToDto(Models.User user)
        {
            return new Dto.FindAll.FindAllUsersDto(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password, user.IsAdmin, user.IsCreator, user.Level_idLevel, user.IdUser);
        }
        private Models.User TransformDtoToModel(Dto.Create.CreateUserDto user)
        {
            return new Models.User(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password, user.IsAdmin, user.IsCreator, user.Level_idLevel);
        }
        private Dto.AfterCreate.AfterCreateUserDto TransformModelToAfterCreateDto(Models.User user, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateUserDto(user.FirstName, user.LastName, user.Username, user.Adress, user.Mail, user.Password, user.IsAdmin, user.IsCreator, user.Level_idLevel, isCreated, user.IdUser);
        }


    }
}
