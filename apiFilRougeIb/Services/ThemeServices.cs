using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiFilRougeIb.Services
{
    public class ThemeServices
    {

        private Repositories.ThemeRepository _themeRepository;

        public ThemeServices()
        {
            this._themeRepository = new Repositories.ThemeRepository(new Utils.QueryBuilder());
        }

        /// <summary>
        ///  Permet de récupérer une liste de themes
        /// </summary>
        /// <returns>List<Models.todo></returns>
        public List<Dto.FindAll.FindAllThemesDto> GetThemes()
        {
            List<Models.Theme> themes = this._themeRepository.FindAll();
            List<Dto.FindAll.FindAllThemesDto> themesDto = new List<Dto.FindAll.FindAllThemesDto>();
            themes.ForEach(theme =>
            {
                themesDto.Add(TransformModelToDto(theme));
            });
            return themesDto;
        }

        /// <summary>
        ///     Retourne un theme
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Models.Todo</returns>
        internal Dto.FindAll.FindAllThemesDto GetTheme(long id)
        {
            Models.Theme theme = this._themeRepository.Find(id);
            Dto.FindAll.FindAllThemesDto themeDto = TransformModelToDto(theme);
            return themeDto;
        }

        /// <summary>
        ///     Persister un theme
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateThemeDto PostTheme(Dto.Create.CreateThemeDto theme)
        {
            Models.Theme themeModel = TransformDtoToModel(theme);
            Models.Theme themeModelCreated = this._themeRepository.Create(themeModel);
            return TransformModelToAfterCreateDto(themeModelCreated, true);
        }

        /// <summary>
        ///     Mets à jours un theme
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTodo"></param>
        /// <returns></returns>
        internal Dto.AfterCreate.AfterCreateThemeDto PutTheme(long id, Dto.Create.CreateThemeDto newTheme)
        {
            Models.Theme themeModel = TransformDtoToModel(newTheme);
            Models.Theme themeModelUpdated = this._themeRepository.Update(id, themeModel);
            return TransformModelToAfterCreateDto(themeModelUpdated, true);
        }
        /// <summary>
        ///     Supprime un theme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal int Delete(long id)
        {
            return this._themeRepository.Delete(id);
        }
        private Dto.FindAll.FindAllThemesDto TransformModelToDto(Models.Theme theme)
        {
            return new Dto.FindAll.FindAllThemesDto(theme.Category, theme.IdTheme);
        }
        private Models.Theme TransformDtoToModel(Dto.Create.CreateThemeDto theme)
        {
            return new Models.Theme(theme.Category);
        }
        private Dto.AfterCreate.AfterCreateThemeDto TransformModelToAfterCreateDto(Models.Theme theme, bool isCreated)
        {
            return new Dto.AfterCreate.AfterCreateThemeDto(theme.Category, isCreated, theme.IdTheme);
        }


    }
}
